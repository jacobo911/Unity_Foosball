using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using Random = UnityEngine.Random;

public class FoosballAgent : Agent
{
    public Ball ball;
    public PlayerColor allyColor;

    public GameObject allyGoal;
    public GameObject allyAttack;
    public GameObject allyDefence;
    public GameObject allyGoalkeeper;
    public GameObject allyMidfield;

    public GameObject enemyGoal;
    public GameObject enemyAttack;
    public GameObject enemyDefence;
    public GameObject enemyGoalkeeper;
    public GameObject enemyMidfield;

    Rigidbody attackRod;
    Rigidbody defenceRod;
    Rigidbody goalkeeperRod;
    Rigidbody midfieldRod;
    Rigidbody ballBody;

    EnvironmentParameters ResetParams;

    private int counter = 0;

    public override void Initialize()
    {
        attackRod = allyAttack.gameObject.GetComponent<Rigidbody>();
        defenceRod = allyDefence.gameObject.GetComponent<Rigidbody>();
        goalkeeperRod = allyGoalkeeper.gameObject.GetComponent<Rigidbody>();
        midfieldRod = allyMidfield.gameObject.GetComponent<Rigidbody>();

        ballBody = ball.gameObject.GetComponent<Rigidbody>();

        ResetParams = Academy.Instance.EnvironmentParameters;
    }

    public override void OnEpisodeBegin()
    {
        ball.reset();
        ballBody.velocity = new Vector3(0f, 0f, 0f);
        ballBody.angularVelocity = new Vector3(0f, 0f, 0f);

/*        allyAttack.gameObject.transform.localPosition = new Vector3(0.002214f, 0.003496999f, 0f);
        allyDefence.gameObject.transform.localPosition = new Vector3(-0.003690998f, 0.003497f, 0f);
        allyGoalkeeper.gameObject.transform.localPosition = new Vector3(-0.005167f, 0.003497f, 0f);
        allyMidfield.gameObject.transform.localPosition = new Vector3(-0.000738f, 0.003497f, 0f);*/
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Ball Observations: 5 observations
        sensor.AddObservation(ball.gameObject.transform.localPosition.x);
        sensor.AddObservation(ball.gameObject.transform.localPosition.z);
        sensor.AddObservation(ballBody.velocity); // 3 observations

        // Ally Observations: 14 observations
        sensor.AddObservation(allyGoal.gameObject.transform.localPosition.x);
        sensor.AddObservation(allyGoal.gameObject.transform.localPosition.z);

        sensor.AddObservation(allyAttack.gameObject.transform.localPosition.x);
        sensor.AddObservation(allyAttack.gameObject.transform.localPosition.z);
        sensor.AddObservation(allyAttack.gameObject.transform.localRotation.z);

        sensor.AddObservation(allyDefence.gameObject.transform.localPosition.x);
        sensor.AddObservation(allyDefence.gameObject.transform.localPosition.z);
        sensor.AddObservation(allyDefence.gameObject.transform.localRotation.z);

        sensor.AddObservation(allyGoalkeeper.gameObject.transform.localPosition.x);
        sensor.AddObservation(allyGoalkeeper.gameObject.transform.localPosition.z);
        sensor.AddObservation(allyGoalkeeper.gameObject.transform.localRotation.z);

        sensor.AddObservation(allyMidfield.gameObject.transform.localPosition.x);
        sensor.AddObservation(allyMidfield.gameObject.transform.localPosition.z);
        sensor.AddObservation(allyMidfield.gameObject.transform.localRotation.z);

        // Enemy Observations: 14 observations
        sensor.AddObservation(enemyGoal.gameObject.transform.localPosition.x);
        sensor.AddObservation(enemyGoal.gameObject.transform.localPosition.z);

        sensor.AddObservation(enemyAttack.gameObject.transform.localPosition.x);
        sensor.AddObservation(enemyAttack.gameObject.transform.localPosition.z);
        sensor.AddObservation(enemyAttack.gameObject.transform.localRotation.z);

        sensor.AddObservation(enemyDefence.gameObject.transform.localPosition.x);
        sensor.AddObservation(enemyDefence.gameObject.transform.localPosition.z);
        sensor.AddObservation(enemyDefence.gameObject.transform.localRotation.z);

        sensor.AddObservation(enemyGoalkeeper.gameObject.transform.localPosition.x);
        sensor.AddObservation(enemyGoalkeeper.gameObject.transform.localPosition.z);
        sensor.AddObservation(enemyGoalkeeper.gameObject.transform.localRotation.z);

        sensor.AddObservation(enemyMidfield.gameObject.transform.localPosition.x);
        sensor.AddObservation(enemyMidfield.gameObject.transform.localPosition.z);
        sensor.AddObservation(enemyMidfield.gameObject.transform.localRotation.z);
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // obtain outputs from network
        var attackActionRotate = 10f * Mathf.Clamp(actionBuffers.ContinuousActions[0], -1f, 1f);
        var attackActionLateral = 10f * Mathf.Clamp(actionBuffers.ContinuousActions[1], -1f, 1f);
        var defenceActionRotate = 10f * Mathf.Clamp(actionBuffers.ContinuousActions[2], -1f, 1f);
        var defenceActionLateral = 10f * Mathf.Clamp(actionBuffers.ContinuousActions[3], -1f, 1f);
        var goalkeeperActionRotate = 10f * Mathf.Clamp(actionBuffers.ContinuousActions[4], -1f, 1f);
        var goalkeeperActionLateral = 10f * Mathf.Clamp(actionBuffers.ContinuousActions[5], -1f, 1f);
        var midfieldActionRotate = 10f * Mathf.Clamp(actionBuffers.ContinuousActions[6], -1f, 1f);
        var midfieldActionLateral = 10f * Mathf.Clamp(actionBuffers.ContinuousActions[7], -1f, 1f);

        // initialize control vectors
        Vector3 attackControlForce = Vector3.zero;
        Vector3 attackControlTorque = Vector3.zero;
        Vector3 defenceControlForce = Vector3.zero;
        Vector3 defenceControlTorque = Vector3.zero;
        Vector3 goalkeeperControlForce = Vector3.zero;
        Vector3 goalkeeperControlTorque = Vector3.zero;
        Vector3 midfieldControlForce = Vector3.zero;
        Vector3 midfieldControlTorque = Vector3.zero;

        // use outputs to compute new control vectors
        attackControlForce = new Vector3(0f, 0f, attackActionLateral);
        attackControlTorque = new Vector3(0f, 0f, attackActionRotate);
        defenceControlForce = new Vector3(0f, 0f, defenceActionLateral);
        defenceControlTorque = new Vector3(0f, 0f, defenceActionRotate);
        goalkeeperControlForce = new Vector3(0f, 0f, goalkeeperActionLateral);
        goalkeeperControlTorque = new Vector3(0f, 0f, goalkeeperActionRotate);
        midfieldControlForce = new Vector3(0f, 0f, midfieldActionLateral);
        midfieldControlTorque = new Vector3(0f, 0f, midfieldActionRotate);

        // apply forces and torques according to control vectors
        attackRod.AddForce(attackControlForce);
        attackRod.AddTorque(attackControlTorque);
        defenceRod.AddForce(defenceControlForce);
        defenceRod.AddTorque(defenceControlTorque);
        goalkeeperRod.AddForce(goalkeeperControlForce);
        goalkeeperRod.AddTorque(goalkeeperControlTorque);
        midfieldRod.AddForce(midfieldControlForce);
        midfieldRod.AddTorque(midfieldControlTorque);

        // reward scoring against enemy
        if (ball.inGoalColor != allyColor && ball.inGoalColor != PlayerColor.none)
        {
            AddReward(1000f);
            EndEpisode();
        }
        
        // penalize being scored on
        else if (ball.inGoalColor == allyColor)
        {
            AddReward(-1000f);
            EndEpisode();
        }

        // reward/penalize based on zone
        else
        {
            // closest to enemy (red) goal
            if (ball.gameObject.transform.localPosition.x > 0.002996f)
            {
                AddReward(20f);
                // counter logic to put hard cap on episode length
                if (counter >= 1000)
                {
                    EndEpisode();
                }
                counter++;
            }
            // in between midfield and farthest forward zone
            else if (ball.gameObject.transform.localPosition.x > 0f)
            {
                AddReward(10f);
                if (counter >= 1000)
                {
                    EndEpisode();
                }
                counter++;
            }
            // in between midfield and farthest back zone
            else if (ball.gameObject.transform.localPosition.x > -0.002996f)
            {
                AddReward(-10f);
                if (counter >= 1000)
                {
                    EndEpisode();
                }
                counter++;
            }
            // closest to ally (blue) goal
            else
            {
                AddReward(-20f);
                if (counter >= 1000)
                {
                    EndEpisode();
                }
                counter++;
            }
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Horizontal");
        continuousActionsOut[1] = Input.GetAxis("Vertical");
        continuousActionsOut[2] = Input.GetAxis("Horizontal");
        continuousActionsOut[3] = Input.GetAxis("Vertical");
        continuousActionsOut[4] = Input.GetAxis("Horizontal");
        continuousActionsOut[5] = Input.GetAxis("Vertical");
        continuousActionsOut[6] = Input.GetAxis("Horizontal");
        continuousActionsOut[7] = Input.GetAxis("Vertical");
    }
}
