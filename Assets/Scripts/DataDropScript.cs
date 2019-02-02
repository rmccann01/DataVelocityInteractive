using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataDropScript : MonoBehaviour
{

    public float speed;
    public bool rotate;
    public float rotateSpeed;
    Rigidbody2D rb;

    //Initialize RigidBody of Data
    void Start()
    {
        rb = GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
    }

    //Move and rotate data during game
    void Update()
    {
        //Drops the data at an adjustable rate
        Vector2 moveDown = new Vector3(0, -1);
        rb.position += moveDown * speed * Time.deltaTime;

        //Rotates the data
        Vector3 eulers = new Vector3(0, 0, 1);
        if (rotate)
        {
            transform.Rotate(eulers * rotateSpeed);
        }
    }
}
