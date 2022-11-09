using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penalty_collision : MonoBehaviour
{
    public Penalty isPenalty;
    public GameObject collisionTarget;

    public void OnTriggerEnter(Collider collisionData)
    {
        if (collisionData.gameObject.tag == "Ball")
        {
/*            collisionData.gameObject.GetComponent<Ball>().ballPenalty = isPenalty;
            collisionData.gameObject.GetComponent<Ball>().reset();*/
        }
    }
}
