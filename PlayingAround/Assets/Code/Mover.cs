using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float Thrusting_speed = 100f;
    [SerializeField] float Rotation_speed = 100f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

     
    void Update()
    {
        Thrusting();
        Rotation();
    }

    void Thrusting()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * Thrusting_speed * Time.deltaTime);
        }
    }
    void Rotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Left_Rotation();
        }
        if (Input.GetKey(KeyCode.D))
        {
            Right_Rotation();
        }
    }

    void Right_Rotation()
    {
        transform.Rotate(Vector3.right * Rotation_speed * Time.deltaTime);
    }

    void Left_Rotation()
    {
        transform.Rotate(Vector3.left * Rotation_speed * Time.deltaTime);
    }
}
