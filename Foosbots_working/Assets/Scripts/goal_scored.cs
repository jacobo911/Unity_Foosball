using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal_scored : MonoBehaviour
{
    public PlayerColor GoalColor;
    public GameObject collisionTarget;

    public void OnTriggerEnter(Collider collisionData)
    {
        if (collisionData.gameObject.tag == "Ball")
        {
            collisionData.gameObject.GetComponent<Ball>().inGoalColor = GoalColor;
            //collisionData.gameObject.GetComponent<Ball>().reset();
        }
    }
}
