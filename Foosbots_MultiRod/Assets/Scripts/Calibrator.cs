using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calibrator : MonoBehaviour
{
    public float Force;
    public float Torque;
    public GameObject Rod;
    Rigidbody rBody;

    private int counter = 0;

    Vector3 controlForce = Vector3.zero;
    Vector3 controlTorque = Vector3.zero;

    void Start()
    {
        rBody = Rod.gameObject.GetComponent<Rigidbody>();
        controlForce = new Vector3(0f, 0f, Force);
        controlTorque = new Vector3(0f, 0f, Torque);
    }

    void FixedUpdate()
    {
        if (counter == 0)
        {
            rBody.AddForce(controlForce);
            rBody.AddTorque(controlTorque);
            counter++;
        }
    }
}
