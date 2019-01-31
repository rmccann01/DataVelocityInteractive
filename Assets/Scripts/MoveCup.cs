using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCup : MonoBehaviour
{
    public float speed;
    public float xMin, xMax; //Created to set the cup boundaries in Unity
    Rigidbody2D cup;
    Vector3 movement;

    void Awake()
    {
        cup = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float move = Input.GetAxisRaw("Horizontal");
        Move(move);
    }

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