using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public PlayerColor inGoalColor;
    Vector3 ballReset = new Vector3(0.00275f, 0.00349f, 0f);

    public void reset()
    {
        inGoalColor = PlayerColor.none;
/*        gameObject.transform.localPosition = ballReset;*/
    }

}