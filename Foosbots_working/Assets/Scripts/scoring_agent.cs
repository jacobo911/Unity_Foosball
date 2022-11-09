using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using Random = UnityEngine.Random;

public class scoring_agent : Agent
{

    public Ball ball;
    public GameObject goal;
    public PlayerColor color;
    EnvironmentParameters ResetParams;

    public override void Initialize()
    {
        ResetParams = Academy.Instance.EnvironmentParameters;

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
        var actionRotate = 20f * Mathf.Clamp(actionBuffers.ContinuousActions[0], -1f, 1f);
        var actionLateral = .00005f * Mathf.Clamp(actionBuffers.ContinuousActions[1], -1f, 1f);

        gameObject.transform.Rotate(new Vector3(0, 0, 1), actionRotate);
        Vector3 moveAmount = new Vector3(0f, 0f, actionLateral);
        Vector3 moveLimit = gameObject.transform.localPosition + moveAmount;
        gameObject.transform.localPosition = moveLimit;

        
        if (gameObject.transform.localPosition.z < -0.00115f)
        {
            gameObject.transform.localPosition =new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 0.00115f);
        }
        if (gameObject.transform.localPosition.z > 0.00105f)
        {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, 0.00105f);
        }

        if (ball.inGoalColor != color && ball.inGoalColor != PlayerColor.none)
        {
            SetReward(1f);
            EndEpisode();
        }
        else
        {
            SetReward(-.1f);
        }
        
    }

    public override void OnEpisodeBegin()
    {
        ball.reset();
        gameObject.transform.localPosition = new Vector3(0.002214f, 0.0035f, Random.Range(-0.00114f, 0.00103f));
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continousActionsOut = actionsOut.ContinuousActions;
        continousActionsOut[0] = -Input.GetAxis("Vertical");
        continousActionsOut[1] = Input.GetAxis("Horizontal");
    }

}
