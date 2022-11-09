using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScored : MonoBehaviour
{
    public PlayerColor GoalColor;
    public GameObject collisionTarget;

    public void OnTriggerEnter(Collider collisionData)
    {
        if (collisionData.gameObject.tag == "Ball")
        {
            collisionData.gameObject.GetComponent<Ball>().inGoalColor = GoalColor;
        }
    }
}

