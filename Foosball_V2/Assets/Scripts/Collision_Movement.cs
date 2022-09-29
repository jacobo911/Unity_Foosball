using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Movement : MonoBehaviour
{

    // Public Variables
    public GameObject rotateAround;

    // Private Variables
    private Rigidbody parent_rigidbody;
    private Transform parent_transform;
    private float angularVelocity;
    private Vector3 lateral_nZ;
    private Vector3 lateral_pZ;
    private Vector3 angle_nZ;
    private Vector3 angle_pZ;
    private int rotation_speed = 500;
    private int lateral_speed = 1;

    Collider thisCollider;
    Collider otherCollider;

    // Blue Inputs
    // Attack; Negative/Positive Z
    // Lateral
    private KeyCode b_a_lat_nZ = KeyCode.Alpha1;
    private KeyCode b_a_lat_pZ = KeyCode.Alpha2;
    // Rotational
    private KeyCode b_a_rot_nZ = KeyCode.Alpha3;
    private KeyCode b_a_rot_pZ = KeyCode.Alpha4;

    // Midfield; Negative/Positive Z
    // Lateral
    private KeyCode b_m_lat_nZ = KeyCode.Q;
    private KeyCode b_m_lat_pZ = KeyCode.W;
    // Rotational
    private KeyCode b_m_rot_nZ = KeyCode.E;
    private KeyCode b_m_rot_pZ = KeyCode.R;

    // Defence; Negative/Positive Z
    // Lateral
    private KeyCode b_d_lat_nZ = KeyCode.A;
    private KeyCode b_d_lat_pZ = KeyCode.S;
    // Rotational
    private KeyCode b_d_rot_nZ = KeyCode.D;
    private KeyCode b_d_rot_pZ = KeyCode.F;

    // Goalkeeper; Negative/Positive Z
    // Lateral
    private KeyCode b_g_lat_nZ = KeyCode.Z;
    private KeyCode b_g_lat_pZ = KeyCode.X;
    // Rotational
    private KeyCode b_g_rot_nZ = KeyCode.C;
    private KeyCode b_g_rot_pZ = KeyCode.V;

    // Red Inputs
    // Attack; Negative/Positive Z
    // Lateral
    private KeyCode r_a_lat_nZ = KeyCode.Alpha7;
    private KeyCode r_a_lat_pZ = KeyCode.Alpha8;
    // Rotational
    private KeyCode r_a_rot_nZ = KeyCode.Alpha9;
    private KeyCode r_a_rot_pZ = KeyCode.Alpha0;

    // Midfield; Negative/Positive Z
    // Lateral
    private KeyCode r_m_lat_nZ = KeyCode.U;
    private KeyCode r_m_lat_pZ = KeyCode.I;
    // Rotational
    private KeyCode r_m_rot_nZ = KeyCode.O;
    private KeyCode r_m_rot_pZ = KeyCode.P;

    // Defence; Negative/Positive Z
    // Lateral
    private KeyCode r_d_lat_nZ = KeyCode.J;
    private KeyCode r_d_lat_pZ = KeyCode.K;
    // Rotational
    private KeyCode r_d_rot_nZ = KeyCode.L;
    private KeyCode r_d_rot_pZ = KeyCode.Semicolon;

    // Goalkeeper; Negative/Positive Z
    // Lateral
    private KeyCode r_g_lat_nZ = KeyCode.M;
    private KeyCode r_g_lat_pZ = KeyCode.Comma;
    // Rotational
    private KeyCode r_g_rot_nZ = KeyCode.Period;
    private KeyCode r_g_rot_pZ = KeyCode.Slash;

    // Blue RubberStoppers
    // Attack; Negative/Positive Z
    private bool b_a_c_nZ = false;
    private bool b_a_c_pZ = false;

    // Midfield; Negative/Positive Z
    private bool b_m_c_nZ = false;
    private bool b_m_c_pZ = false;

    // Defence; Negative/Positive Z
    private bool b_d_c_nZ = false;
    private bool b_d_c_pZ = false;

    // Goalkeeper; Negative/Positive Z
    private bool b_g_c_nZ = false;
    private bool b_g_c_pZ = false;

    // Red RubberStoppers
    // Attack; Negative/Positive Z
    private bool r_a_c_nZ = false;
    private bool r_a_c_pZ = false;

    // Midfield; Negative/Positive Z
    private bool r_m_c_nZ = false;
    private bool r_m_c_pZ = false;

    // Defence; Negative/Positive Z
    private bool r_d_c_nZ = false;
    private bool r_d_c_pZ = false;

    // Goalkeeper; Negative/Positive Z
    private bool r_g_c_nZ = false;
    private bool r_g_c_pZ = false;

    // Start is called before the first frame update
    void Start()
    {
        parent_rigidbody = GetComponent<Rigidbody>();
        parent_transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Blue Rod
        if (GetComponent<CustomTag>().HasTag("Blue"))
        {
            angle_nZ = new Vector3(0, 0, -1);
            angle_pZ = new Vector3(0, 0, 1);
            lateral_nZ = new Vector3(0, 0, -1);
            lateral_pZ = new Vector3(0, 0, 1);
            angularVelocity = (rotation_speed * Time.deltaTime);

            // Attack
            if (GetComponent<CustomTag>().HasTag("Attack"))
            {
                // Lateral Movement
                if (Input.GetKey(b_a_lat_nZ))
                {
                    if (!b_a_c_nZ)
                    {
                        parent_transform.Translate(lateral_nZ * lateral_speed * Time.deltaTime);
                    }
                }
                else if (Input.GetKey(b_a_lat_pZ))
                {
                    if (!b_a_c_pZ)
                    {
                        parent_transform.Translate(lateral_pZ * lateral_speed * Time.deltaTime);
                    }
                }

                // Rotational Movement
                if (Input.GetKey(b_a_rot_nZ))
                {
                    parent_transform.RotateAround(rotateAround.transform.position, angle_nZ, angularVelocity);
                }
                else if (Input.GetKey(b_a_rot_pZ))
                {
                    parent_transform.RotateAround(rotateAround.transform.position, angle_pZ, angularVelocity);
                }
            }
            // Midfield
            else if (GetComponent<CustomTag>().HasTag("Midfield"))
            {
                // Lateral Movement
                if (Input.GetKey(b_m_lat_nZ))
                {
                    if (!b_m_c_nZ)
                    {
                        parent_transform.Translate(lateral_nZ * lateral_speed * Time.deltaTime);
                    }
                }
                else if (Input.GetKey(b_m_lat_pZ))
                {
                    if (!b_m_c_pZ)
                    {
                        parent_transform.Translate(lateral_pZ * lateral_speed * Time.deltaTime);
                    }
                }

                // Rotational Movement
                if (Input.GetKey(b_m_rot_nZ))
                {
                    parent_transform.RotateAround(rotateAround.transform.position, angle_nZ, angularVelocity);
                }
                else if (Input.GetKey(b_m_rot_pZ))
                {
                    parent_transform.RotateAround(rotateAround.transform.position, angle_pZ, angularVelocity);
                }
            }
            // Defence
            else if (GetComponent<CustomTag>().HasTag("Defence"))
            {
                // Lateral Movement
                if (Input.GetKey(b_d_lat_nZ))
                {
                    if (!b_d_c_nZ)
                    {
                        parent_transform.Translate(lateral_nZ * lateral_speed * Time.deltaTime);
                    }
                }
                else if (Input.GetKey(b_d_lat_pZ))
                {
                    if (!b_d_c_pZ)
                    {
                        parent_transform.Translate(lateral_pZ * lateral_speed * Time.deltaTime);
                    }
                }

                // Rotational Movement
                if (Input.GetKey(b_d_rot_nZ))
                {
                    parent_transform.RotateAround(rotateAround.transform.position, angle_nZ, angularVelocity);
                }
                else if (Input.GetKey(b_d_rot_pZ))
                {
                    parent_transform.RotateAround(rotateAround.transform.position, angle_pZ, angularVelocity);
                }
            }
            // Goalkeeper
            else if (GetComponent<CustomTag>().HasTag("Goalkeeper"))
            {
                // Lateral Movement
                if (Input.GetKey(b_g_lat_nZ))
                {
                    if (!b_g_c_nZ)
                    {
                        parent_transform.Translate(lateral_nZ * lateral_speed * Time.deltaTime);
                    }
                }
                else if (Input.GetKey(b_g_lat_pZ))
                {
                    if (!b_g_c_pZ)
                    {
                        parent_transform.Translate(lateral_pZ * lateral_speed * Time.deltaTime);
                    }
                }

                // Rotational Movement
                if (Input.GetKey(b_g_rot_nZ))
                {
                    parent_transform.RotateAround(rotateAround.transform.position, angle_nZ, angularVelocity);
                }
                else if (Input.GetKey(b_g_rot_pZ))
                {
                    parent_transform.RotateAround(rotateAround.transform.position, angle_pZ, angularVelocity);
                }
            }
        }
        // Red Rod
        else if (GetComponent<CustomTag>().HasTag("Red")) 
        {
            angle_nZ = new Vector3(0, 0, 1);
            angle_pZ = new Vector3(0, 0, -1);
            lateral_nZ = new Vector3(0, 0, -1);
            lateral_pZ = new Vector3(0, 0, 1);
            angularVelocity = (rotation_speed * Time.deltaTime);

            // Attack
            if (GetComponent<CustomTag>().HasTag("Attack"))
            {
                // Lateral Movement
                if (Input.GetKey(r_a_lat_nZ))
                {
                    if (!r_a_c_nZ)
                    {
                        parent_transform.Translate(lateral_nZ * lateral_speed * Time.deltaTime);
                    }
                }
                else if (Input.GetKey(r_a_lat_pZ))
                {
                    if (!r_a_c_pZ)
                    {
                        parent_transform.Translate(lateral_pZ * lateral_speed * Time.deltaTime);
                    }
                }

                // Rotational Movement
                if (Input.GetKey(r_a_rot_nZ))
                {
                    parent_transform.RotateAround(rotateAround.transform.position, angle_nZ, angularVelocity);
                }
                else if (Input.GetKey(r_a_rot_pZ))
                {
                    parent_transform.RotateAround(rotateAround.transform.position, angle_pZ, angularVelocity);
                }
            }
            // Midfield
            else if (GetComponent<CustomTag>().HasTag("Midfield"))
            {
                // Lateral Movement
                if (Input.GetKey(r_m_lat_nZ))
                {
                    if (!r_m_c_nZ)
                    {
                        parent_transform.Translate(lateral_nZ * lateral_speed * Time.deltaTime);
                    }
                }
                else if (Input.GetKey(r_m_lat_pZ))
                {
                    if (!r_m_c_pZ)
                    {
                        parent_transform.Translate(lateral_pZ * lateral_speed * Time.deltaTime);
                    }
                }

                // Rotational Movement
                if (Input.GetKey(r_m_rot_nZ))
                {
                    parent_transform.RotateAround(rotateAround.transform.position, angle_nZ, angularVelocity);
                }
                else if (Input.GetKey(r_m_rot_pZ))
                {
                    parent_transform.RotateAround(rotateAround.transform.position, angle_pZ, angularVelocity);
                }
            }
            // Defence
            else if (GetComponent<CustomTag>().HasTag("Defence"))
            {
                // Lateral Movement
                if (Input.GetKey(r_d_lat_nZ))
                {
                    if (!r_d_c_nZ)
                    {
                        parent_transform.Translate(lateral_nZ * lateral_speed * Time.deltaTime);
                    }
                }
                else if (Input.GetKey(r_d_lat_pZ))
                {
                    if (!r_d_c_pZ)
                    {
                        parent_transform.Translate(lateral_pZ * lateral_speed * Time.deltaTime);
                    }
                }

                // Rotational Movement
                if (Input.GetKey(r_d_rot_nZ))
                {
                    parent_transform.RotateAround(rotateAround.transform.position, angle_nZ, angularVelocity);
                }
                else if (Input.GetKey(r_d_rot_pZ))
                {
                    parent_transform.RotateAround(rotateAround.transform.position, angle_pZ, angularVelocity);
                }
            }
            // Goalkeeper
            else if (GetComponent<CustomTag>().HasTag("Goalkeeper"))
            {
                // Lateral Movement
                if (Input.GetKey(r_g_lat_nZ))
                {
                    if (!r_g_c_nZ)
                    {
                        parent_transform.Translate(lateral_nZ * lateral_speed * Time.deltaTime);
                    }
                }
                else if (Input.GetKey(r_g_lat_pZ))
                {
                    if (!r_g_c_pZ)
                    {
                        parent_transform.Translate(lateral_pZ * lateral_speed * Time.deltaTime);
                    }
                }

                // Rotational Movement
                if (Input.GetKey(r_g_rot_nZ))
                {
                    parent_transform.RotateAround(rotateAround.transform.position, angle_nZ, angularVelocity);
                }
                else if (Input.GetKey(r_g_rot_pZ))
                {
                    parent_transform.RotateAround(rotateAround.transform.position, angle_pZ, angularVelocity);
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        thisCollider = collision.GetContact(0).thisCollider;
        otherCollider = collision.GetContact(0).otherCollider;

        //print(thisCollider);
        //print(otherCollider);

        if (otherCollider.name == "Table_Body")
        {
            // Blue RubberStopper
            if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("Blue"))
            {
                // Attack
                if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("Attack"))
                {
                    // Negative Z
                    if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        b_a_c_nZ = true;
                    }
                    // Positive Z
                    else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        b_a_c_pZ = true;
                    }
                }
                // Midfield
                else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("Midfield"))
                {
                    // Negative Z
                    if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        b_m_c_nZ = true;
                    }
                    // Positive Z
                    else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        b_m_c_pZ = true;
                    }
                }
                // Defence
                else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("Defence"))
                {
                    // Negative Z
                    if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        b_d_c_nZ = true;
                    }
                    // Positive Z
                    else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        b_d_c_pZ = true;
                    }
                }
                // Goalkeeper
                else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("Goalkeeper"))
                {
                    // Negative Z
                    if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        b_g_c_nZ = true;
                    }
                    // Positive Z
                    else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        b_g_c_pZ = true;
                    }
                }
            }
            // Red RubberStopper
            else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("Red"))
            {
                // Attack
                if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("Attack"))
                {
                    // Negative Z
                    if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        r_a_c_nZ = true;
                    }
                    // Positive Z
                    else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        r_a_c_pZ = true;
                    }
                }
                // Midfield
                else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("Midfield"))
                {
                    // Negative Z
                    if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        r_m_c_nZ = true;
                    }
                    // Positive Z
                    else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        r_m_c_pZ = true;
                    }
                }
                // Defence
                else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("Defence"))
                {
                    // Negative Z
                    if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        r_d_c_nZ = true;
                    }
                    // Positive Z
                    else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        r_d_c_pZ = true;
                    }
                }
                // Goalkeeper
                else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("Goalkeeper"))
                {
                    // Negative Z
                    if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        r_g_c_nZ = true;
                    }
                    // Positive Z
                    else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        r_g_c_pZ = true;
                    }
                }
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {

        //thisCollider = collision.GetContact(0).thisCollider;
        //otherCollider = collision.GetContact(0).otherCollider;
        
        if (otherCollider.name == "Table_Body")
        {
            // Blue RubberStopper
            if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("Blue"))
            {
                // Attack
                if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("Attack"))
                {
                    // Negative Z
                    if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        b_a_c_nZ = false;
                    }
                    // Positive Z
                    else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        b_a_c_pZ = false;
                    }
                }
                // Midfield
                else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("Midfield"))
                {
                    // Negative Z
                    if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        b_m_c_nZ = false;
                    }
                    // Positive Z
                    else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        b_m_c_pZ = false;
                    }
                }
                // Defence
                else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("Defence"))
                {
                    // Negative Z
                    if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        b_d_c_nZ = false;
                    }
                    // Positive Z
                    else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        b_d_c_pZ = false;
                    }
                }
                // Goalkeeper
                else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("Goalkeeper"))
                {
                    // Negative Z
                    if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        b_g_c_nZ = false;
                    }
                    // Positive Z
                    else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        b_g_c_pZ = false;
                    }
                }
            }
            // Red RubberStopper
            else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("Red"))
            {
                // Attack
                if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("Attack"))
                {
                    // Negative Z
                    if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        r_a_c_nZ = false;
                    }
                    // Positive Z
                    else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        r_a_c_pZ = false;
                    }
                }
                // Midfield
                else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("Midfield"))
                {
                    // Negative Z
                    if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        r_m_c_nZ = false;
                    }
                    // Positive Z
                    else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        r_m_c_pZ = false;
                    }
                }
                // Defence
                else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("Defence"))
                {
                    // Negative Z
                    if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        r_d_c_nZ = false;
                    }
                    // Positive Z
                    else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        r_d_c_pZ = false;
                    }
                }
                // Goalkeeper
                else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("Goalkeeper"))
                {
                    // Negative Z
                    if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        r_g_c_nZ = false;
                    }
                    // Positive Z
                    else if (thisCollider.gameObject.GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        r_g_c_pZ = false;
                    }
                }
            }
        }
    }
}
