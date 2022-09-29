using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect_Collision : MonoBehaviour
{

    private Rigidbody rb;
    private Transform tf;
    Collider thisCollider;
    Collider otherCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        print("C_Enter");
        thisCollider = collision.GetContact(0).thisCollider;
        otherCollider = collision.GetContact(0).otherCollider;

        print(thisCollider);
        print(otherCollider);
    }

    void OnCollisionExit(Collision collision)
    {
        print("C_Exit");
        thisCollider = collision.GetContact(0).thisCollider;
        otherCollider = collision.GetContact(0).otherCollider;

        print(thisCollider);
        print(otherCollider);
    }

    void OnTriggerEnter(Collider collider)
    {
        print("T_Enter");

        print(collider);
    }

    void OnTriggerExit(Collider collider)
    {
        print("T_Exit");

        print(collider);
        
    }
}
