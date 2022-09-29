using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubberStopper : MonoBehaviour
{

    private Rigidbody rb;

    // Blue RubberStoppers
    // Attack; Negative/Positive Z
    public bool b_a_c_nZ = false;
    public bool b_a_c_pZ = false;

    // Midfield; Negative/Positive Z
    public bool b_m_c_nZ = false;
    public bool b_m_c_pZ = false;

    // Defence; Negative/Positive Z
    public bool b_d_c_nZ = false;
    public bool b_d_c_pZ = false;

    // Goalkeeper; Negative/Positive Z
    public bool b_g_c_nZ = false;
    public bool b_g_c_pZ = false;

    // Red RubberStoppers
    // Attack; Negative/Positive Z
    public bool r_a_c_nZ = false;
    public bool r_a_c_pZ = false;

    // Midfield; Negative/Positive Z
    public bool r_m_c_nZ = false;
    public bool r_m_c_pZ = false;

    // Defence; Negative/Positive Z
    public bool r_d_c_nZ = false;
    public bool r_d_c_pZ = false;

    // Goalkeeper; Negative/Positive Z
    public bool r_g_c_nZ = false;
    public bool r_g_c_pZ = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Table_Body")
        {
            // Blue RubberStopper
            if (GetComponent<CustomTag>().HasTag("Blue"))
            {
                // Attack
                if (GetComponent<CustomTag>().HasTag("Attack"))
                {
                    // Negative Z
                    if (GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        b_a_c_nZ = true;
                    }
                    // Positive Z
                    else if (GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        b_a_c_pZ = true;
                    }
                }
                // Midfield
                else if (GetComponent<CustomTag>().HasTag("Midfield"))
                {
                    // Negative Z
                    if (GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        b_m_c_nZ = true;
                    }
                    // Positive Z
                    else if (GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        b_m_c_pZ = true;
                    }
                }
                // Defence
                else if (GetComponent<CustomTag>().HasTag("Defence"))
                {
                    // Negative Z
                    if (GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        b_d_c_nZ = true;
                    }
                    // Positive Z
                    else if (GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        b_d_c_pZ = true;
                    }
                }
                // Goalkeeper
                else if (GetComponent<CustomTag>().HasTag("Goalkeeper"))
                {
                    // Negative Z
                    if (GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        b_g_c_nZ = true;
                    }
                    // Positive Z
                    else if (GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        b_g_c_pZ = true;
                    }
                }
            }
            // Red RubberStopper
            else if (GetComponent<CustomTag>().HasTag("Red"))
            {
                // Attack
                if (GetComponent<CustomTag>().HasTag("Attack"))
                {
                    // Negative Z
                    if (GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        r_a_c_nZ = true;
                    }
                    // Positive Z
                    else if (GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        r_a_c_pZ = true;
                    }
                }
                // Midfield
                else if (GetComponent<CustomTag>().HasTag("Midfield"))
                {
                    // Negative Z
                    if (GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        r_m_c_nZ = true;
                    }
                    // Positive Z
                    else if (GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        r_m_c_pZ = true;
                    }
                }
                // Defence
                else if (GetComponent<CustomTag>().HasTag("Defence"))
                {
                    // Negative Z
                    if (GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        r_d_c_nZ = true;
                    }
                    // Positive Z
                    else if (GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        r_d_c_pZ = true;
                    }
                }
                // Goalkeeper
                else if (GetComponent<CustomTag>().HasTag("Goalkeeper"))
                {
                    // Negative Z
                    if (GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        r_g_c_nZ = true;
                    }
                    // Positive Z
                    else if (GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        r_g_c_pZ = true;
                    }
                }
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Table_Body")
        {
            // Blue RubberStopper
            if (GetComponent<CustomTag>().HasTag("Blue"))
            {
                // Attack
                if (GetComponent<CustomTag>().HasTag("Attack"))
                {
                    // Negative Z
                    if (GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        b_a_c_nZ = false;
                    }
                    // Positive Z
                    else if (GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        b_a_c_pZ = false;
                    }
                }
                // Midfield
                else if (GetComponent<CustomTag>().HasTag("Midfield"))
                {
                    // Negative Z
                    if (GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        b_m_c_nZ = false;
                    }
                    // Positive Z
                    else if (GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        b_m_c_pZ = false;
                    }
                }
                // Defence
                else if (GetComponent<CustomTag>().HasTag("Defence"))
                {
                    // Negative Z
                    if (GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        b_d_c_nZ = false;
                    }
                    // Positive Z
                    else if (GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        b_d_c_pZ = false;
                    }
                }
                // Goalkeeper
                else if (GetComponent<CustomTag>().HasTag("Goalkeeper"))
                {
                    // Negative Z
                    if (GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        b_g_c_nZ = false;
                    }
                    // Positive Z
                    else if (GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        b_g_c_pZ = false;
                    }
                }
            }
            // Red RubberStopper
            else if (GetComponent<CustomTag>().HasTag("Red"))
            {
                // Attack
                if (GetComponent<CustomTag>().HasTag("Attack"))
                {
                    // Negative Z
                    if (GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        r_a_c_nZ = false;
                    }
                    // Positive Z
                    else if (GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        r_a_c_pZ = false;
                    }
                }
                // Midfield
                else if (GetComponent<CustomTag>().HasTag("Midfield"))
                {
                    // Negative Z
                    if (GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        r_m_c_nZ = false;
                    }
                    // Positive Z
                    else if (GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        r_m_c_pZ = false;
                    }
                }
                // Defence
                else if (GetComponent<CustomTag>().HasTag("Defence"))
                {
                    // Negative Z
                    if (GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        r_d_c_nZ = false;
                    }
                    // Positive Z
                    else if (GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        r_d_c_pZ = false;
                    }
                }
                // Goalkeeper
                else if (GetComponent<CustomTag>().HasTag("Goalkeeper"))
                {
                    // Negative Z
                    if (GetComponent<CustomTag>().HasTag("NegZ"))
                    {
                        r_g_c_nZ = false;
                    }
                    // Positive Z
                    else if (GetComponent<CustomTag>().HasTag("PosZ"))
                    {
                        r_g_c_pZ = false;
                    }
                }
            }
        }
    }
}
