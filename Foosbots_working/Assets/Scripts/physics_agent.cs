using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using Random = UnityEngine.Random;

public class physics_agent : Agent
{
    public Ball ball;
    public GameObject goal;
    public PlayerColor color;
    public Rigidbody rBody;
    EnvironmentParameters ResetParams;
    /*    private float distanceToGoal;
        private float newDistance = 0f;*/
/*    public int maxSteps = 1000;*/
    private int counter = 0;

    public float oldRotation;
    public float newRotation;
    public int maxRotations;


    public override void Initialize()
    {
        ResetParams = Academy.Instance.EnvironmentParameters;
/*        distanceToGoal = Vector3.Distance(ball.gameObject.transform.localPosition, goal.gameObject.transform.localPosition);*/


    }

    public override void OnEpisodeBegin()
    {
        ball.reset();
        gameObject.transform.localPosition = new Vector3(0.002214f, 0.0035f, Random.Range(-0.00114f, 0.00103f));
        ball.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        ball.gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0f, 0f, 0f);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(gameObject.transform.localRotation.z); // 1 parameter
        sensor.AddObservation(gameObject.transform.localPosition); // 3 parameters
        sensor.AddObservation(ball.gameObject.transform.localPosition); // 3 parameters
        sensor.AddObservation(goal.gameObject.transform.localPosition); // 3 parameters
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        var actionRotate = .005f * Mathf.Clamp(actionBuffers.ContinuousActions[0], -1f, 1f);
        var actionLateral = .05f * Mathf.Clamp(actionBuffers.ContinuousActions[1], -1f, 1f);

        Vector3 controlForce = Vector3.zero;
        Vector3 controlTorque = Vector3.zero;

        controlForce = new Vector3(0f, 0f, actionLateral);
        controlTorque = new Vector3(0f, 0f, actionRotate);

        rBody.AddForce(controlForce);
        rBody.AddTorque(controlTorque);

/*        newDistance = Vector3.Distance(ball.gameObject.transform.localPosition, goal.gameObject.transform.localPosition);*/

        if (ball.inGoalColor != color && ball.inGoalColor != PlayerColor.none)
        {
            AddReward(100f);
            EndEpisode();
        }
/*        else if (ball.ballPenalty == Penalty.yes)
        {
            SetReward(-100f);
            EndEpisode();
        }*/
        else
        {
            AddReward(-.1f);
            counter++;
                if(counter >= 1000)
            {
                SetReward(-50f);
                counter = 0;
                EndEpisode();
            }
        }
        if (ball.gameObject.transform.localPosition.x < 0.00316f)
        {

        }
        else if (ball.gameObject.transform.localPosition.x < 0.00421f)
        {
            AddReward(.2f);
        }
        else if (ball.gameObject.transform.localPosition.x < 0.00503f)
        {
            AddReward(1.5f);
        }

    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Vertical");
        continuousActionsOut[1] = Input.GetAxis("Horizontal");
        newRotation = transform.rotation.z * (360 / Mathf.PI);
        if (newRotation > 0 && oldRotation < 0)
        {
            maxRotations += 1;
        }
        else if (newRotation < 0 && oldRotation > 0)
        {
            maxRotations -= 1;
        }
        oldRotation = newRotation;
        Debug.Log(maxRotations);
    }
}
