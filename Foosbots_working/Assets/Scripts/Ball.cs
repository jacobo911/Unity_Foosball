using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Penalty ballPenalty;
    public PlayerColor inGoalColor;
    Vector3 ballReset = new Vector3(0.00275f, 0.00349f, 0f);
    public float speed = .01f;
    public SphereCollider sphereCollider;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sphereCollider.material.bounciness -= .01f;
            Debug.Log(sphereCollider.material.bounciness);

        }
    }

    void FixedUpdate()
    {
/*        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        gameObject.GetComponent<Rigidbody>().AddForce(movement * speed);*/
    }

    public void reset()
    {
        inGoalColor = PlayerColor.none;
        ballPenalty = Penalty.no;
        gameObject.transform.localPosition = ballReset;
    }

}
