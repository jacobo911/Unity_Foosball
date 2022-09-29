using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject rubberStopper_nZ;
    public GameObject rubberStopper_pZ;
    private Rigidbody rb;
    private Vector3 angularVelocity;
    private Vector3 lateralVelocity;
    private int rotation_speed = 1000;
    private int lateral_speed = 5;
    private RubberStopper rs_nZ;
    private RubberStopper rs_pZ;

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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rs_nZ = rubberStopper_nZ.GetComponent<RubberStopper>();
        rs_pZ = rubberStopper_pZ.GetComponent<RubberStopper>();
    }

    // Update is called once per frame
    void Update()
    {
        // Blue Rod
        if (GetComponent<CustomTag>().HasTag("Blue"))
        {
            // Attack
            if (GetComponent<CustomTag>().HasTag("Attack"))
            {
                // Lateral Movement
                if (Input.GetKey(b_a_lat_nZ))
                {
                    //print(!rs_nZ.b_a_c_nZ);
                    if (!rs_nZ.b_a_c_nZ)
                    {
                        lateralVelocity = new Vector3(0, 0, -1);
                        rb.MovePosition(transform.position + lateralVelocity * Time.deltaTime * lateral_speed);
                    }
                }
                else if (Input.GetKey(b_a_lat_pZ))
                {
                    if (!rs_pZ.b_a_c_pZ)
                    {
                        lateralVelocity = new Vector3(0, 0, 1);
                        rb.MovePosition(transform.position + lateralVelocity * Time.deltaTime * lateral_speed);
                    }
                }

                // Rotational Movement
                if (Input.GetKey(b_a_rot_nZ))
                {
                    angularVelocity = new Vector3(0, 0, -rotation_speed);
                    Quaternion deltaRotation = Quaternion.Euler(angularVelocity * Time.fixedDeltaTime);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }
                else if (Input.GetKey(b_a_rot_pZ))
                {
                    angularVelocity = new Vector3(0, 0, rotation_speed);
                    Quaternion deltaRotation = Quaternion.Euler(angularVelocity * Time.fixedDeltaTime);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }
            }
            // Midfield
            else if (GetComponent<CustomTag>().HasTag("Midfield"))
            {
                // Lateral Movement
                if (Input.GetKey(b_m_lat_nZ))
                {
                    if (!rs_nZ.b_m_c_nZ)
                    {
                        lateralVelocity = new Vector3(0, 0, -1);
                        rb.MovePosition(transform.position + lateralVelocity * Time.deltaTime * lateral_speed);
                    }
                }
                else if (Input.GetKey(b_m_lat_pZ))
                {
                    if (!rs_pZ.b_m_c_pZ)
                    {
                        lateralVelocity = new Vector3(0, 0, 1);
                        rb.MovePosition(transform.position + lateralVelocity * Time.deltaTime * lateral_speed);
                    }
                }

                // Rotational Movement
                if (Input.GetKey(b_m_rot_nZ))
                {
                    angularVelocity = new Vector3(0, 0, -rotation_speed);
                    Quaternion deltaRotation = Quaternion.Euler(angularVelocity * Time.fixedDeltaTime);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }
                else if (Input.GetKey(b_m_rot_pZ))
                {
                    angularVelocity = new Vector3(0, 0, rotation_speed);
                    Quaternion deltaRotation = Quaternion.Euler(angularVelocity * Time.fixedDeltaTime);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }
            }
            // Defence
            else if (GetComponent<CustomTag>().HasTag("Defence"))
            {
                // Lateral Movement
                if (Input.GetKey(b_d_lat_nZ))
                {
                    if (!rs_nZ.b_d_c_nZ)
                    {
                        lateralVelocity = new Vector3(0, 0, -1);
                        rb.MovePosition(transform.position + lateralVelocity * Time.deltaTime * lateral_speed);
                    }
                }
                else if (Input.GetKey(b_d_lat_pZ))
                {
                    if (!rs_pZ.b_d_c_pZ)
                    {
                        lateralVelocity = new Vector3(0, 0, 1);
                        rb.MovePosition(transform.position + lateralVelocity * Time.deltaTime * lateral_speed);
                    }
                }

                // Rotational Movement
                if (Input.GetKey(b_d_rot_nZ))
                {
                    angularVelocity = new Vector3(0, 0, -rotation_speed);
                    Quaternion deltaRotation = Quaternion.Euler(angularVelocity * Time.fixedDeltaTime);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }
                else if (Input.GetKey(b_d_rot_pZ))
                {
                    angularVelocity = new Vector3(0, 0, rotation_speed);
                    Quaternion deltaRotation = Quaternion.Euler(angularVelocity * Time.fixedDeltaTime);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }
            }
            // Goalkeeper
            else if (GetComponent<CustomTag>().HasTag("Goalkeeper"))
            {
                // Lateral Movement
                if (Input.GetKey(b_g_lat_nZ))
                {
                    if (!rs_nZ.b_g_c_nZ)
                    {
                        lateralVelocity = new Vector3(0, 0, -1);
                        rb.MovePosition(transform.position + lateralVelocity * Time.deltaTime * lateral_speed);
                    }
                }
                else if (Input.GetKey(b_g_lat_pZ))
                {
                    if (!rs_pZ.b_g_c_pZ)
                    {
                        lateralVelocity = new Vector3(0, 0, 1);
                        rb.MovePosition(transform.position + lateralVelocity * Time.deltaTime * lateral_speed);
                    }
                }

                // Rotational Movement
                if (Input.GetKey(b_g_rot_nZ))
                {
                    angularVelocity = new Vector3(0, 0, -rotation_speed);
                    Quaternion deltaRotation = Quaternion.Euler(angularVelocity * Time.fixedDeltaTime);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }
                else if (Input.GetKey(b_g_rot_pZ))
                {
                    angularVelocity = new Vector3(0, 0, rotation_speed);
                    Quaternion deltaRotation = Quaternion.Euler(angularVelocity * Time.fixedDeltaTime);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }
            }
        }
        // Red Rod
        else if (GetComponent<CustomTag>().HasTag("Red")) 
        {
            // Attack
            if (GetComponent<CustomTag>().HasTag("Attack"))
            {
                // Lateral Movement
                if (Input.GetKey(r_a_lat_nZ))
                {
                    if (!rs_nZ.r_a_c_nZ)
                    {
                        lateralVelocity = new Vector3(0, 0, -1);
                        rb.MovePosition(transform.position + lateralVelocity * Time.deltaTime * lateral_speed);
                    }
                }
                else if (Input.GetKey(r_a_lat_pZ))
                {
                    if (!rs_pZ.r_a_c_pZ)
                    {
                        lateralVelocity = new Vector3(0, 0, 1);
                        rb.MovePosition(transform.position + lateralVelocity * Time.deltaTime * lateral_speed);
                    }
                }

                // Rotational Movement
                if (Input.GetKey(r_a_rot_nZ))
                {
                    angularVelocity = new Vector3(0, 0, rotation_speed);
                    Quaternion deltaRotation = Quaternion.Euler(angularVelocity * Time.fixedDeltaTime);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }
                else if (Input.GetKey(r_a_rot_pZ))
                {
                    angularVelocity = new Vector3(0, 0, -rotation_speed);
                    Quaternion deltaRotation = Quaternion.Euler(angularVelocity * Time.fixedDeltaTime);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }
            }
            // Midfield
            else if (GetComponent<CustomTag>().HasTag("Midfield"))
            {
                // Lateral Movement
                if (Input.GetKey(r_m_lat_nZ))
                {
                    if (!rs_nZ.r_m_c_nZ)
                    {
                        lateralVelocity = new Vector3(0, 0, -1);
                        rb.MovePosition(transform.position + lateralVelocity * Time.deltaTime * lateral_speed);
                    }
                }
                else if (Input.GetKey(r_m_lat_pZ))
                {
                    if (!rs_pZ.r_m_c_pZ)
                    {
                        lateralVelocity = new Vector3(0, 0, 1);
                        rb.MovePosition(transform.position + lateralVelocity * Time.deltaTime * lateral_speed);
                    }
                }

                // Rotational Movement
                if (Input.GetKey(r_m_rot_nZ))
                {
                    angularVelocity = new Vector3(0, 0, rotation_speed);
                    Quaternion deltaRotation = Quaternion.Euler(angularVelocity * Time.fixedDeltaTime);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }
                else if (Input.GetKey(r_m_rot_pZ))
                {
                    angularVelocity = new Vector3(0, 0, -rotation_speed);
                    Quaternion deltaRotation = Quaternion.Euler(angularVelocity * Time.fixedDeltaTime);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }
            }
            // Defence
            else if (GetComponent<CustomTag>().HasTag("Defence"))
            {
                // Lateral Movement
                if (Input.GetKey(r_d_lat_nZ))
                {
                    if (!rs_nZ.r_d_c_nZ)
                    {
                        lateralVelocity = new Vector3(0, 0, -1);
                        rb.MovePosition(transform.position + lateralVelocity * Time.deltaTime * lateral_speed);
                    }
                }
                else if (Input.GetKey(r_d_lat_pZ))
                {
                    if (!rs_pZ.r_d_c_pZ)
                    {
                        lateralVelocity = new Vector3(0, 0, 1);
                        rb.MovePosition(transform.position + lateralVelocity * Time.deltaTime * lateral_speed);
                    }
                }

                // Rotational Movement
                if (Input.GetKey(r_d_rot_nZ))
                {
                    angularVelocity = new Vector3(0, 0, rotation_speed);
                    Quaternion deltaRotation = Quaternion.Euler(angularVelocity * Time.fixedDeltaTime);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }
                else if (Input.GetKey(r_d_rot_pZ))
                {
                    angularVelocity = new Vector3(0, 0, -rotation_speed);
                    Quaternion deltaRotation = Quaternion.Euler(angularVelocity * Time.fixedDeltaTime);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }
            }
            // Goalkeeper
            else if (GetComponent<CustomTag>().HasTag("Goalkeeper"))
            {
                // Lateral Movement
                if (Input.GetKey(r_g_lat_nZ))
                {
                    if (!rs_nZ.r_g_c_nZ)
                    {
                        lateralVelocity = new Vector3(0, 0, -1);
                        rb.MovePosition(transform.position + lateralVelocity * Time.deltaTime * lateral_speed);
                    }
                }
                else if (Input.GetKey(r_g_lat_pZ))
                {
                    if (!rs_pZ.r_g_c_pZ)
                    {
                        lateralVelocity = new Vector3(0, 0, 1);
                        rb.MovePosition(transform.position + lateralVelocity * Time.deltaTime * lateral_speed);
                    }
                }

                // Rotational Movement
                if (Input.GetKey(r_g_rot_nZ))
                {
                    angularVelocity = new Vector3(0, 0, rotation_speed);
                    Quaternion deltaRotation = Quaternion.Euler(angularVelocity * Time.fixedDeltaTime);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }
                else if (Input.GetKey(r_g_rot_pZ))
                {
                    angularVelocity = new Vector3(0, 0, -rotation_speed);
                    Quaternion deltaRotation = Quaternion.Euler(angularVelocity * Time.fixedDeltaTime);
                    rb.MoveRotation(rb.rotation * deltaRotation);
                }
            }
        }
    }
}
