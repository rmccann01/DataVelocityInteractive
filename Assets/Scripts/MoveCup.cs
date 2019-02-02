using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCup : MonoBehaviour
{
    public float speed;
    public float xMin, xMax; //Created to set the cup boundaries in Unity
    Rigidbody2D cup;
    Vector3 movement;
    //Initialize cup's rigidbody
    void Awake()
    {
        cup = GetComponent<Rigidbody2D>();
    }
    //move cup per frame horizontally
    void FixedUpdate()
    {
        float move = Input.GetAxisRaw("Horizontal");
        Move(move);
    }
    //move cup based on input from update
    void Move(float dir)
    {
        Vector3 updatedMovement; //Created to clamp the movement

        movement.Set(dir, 0, 0);
        movement = movement.normalized * speed * Time.deltaTime;

        updatedMovement = transform.position + movement;
        updatedMovement.x = Mathf.Clamp(updatedMovement.x, xMin, xMax);
        cup.MovePosition(updatedMovement);
    }
}
