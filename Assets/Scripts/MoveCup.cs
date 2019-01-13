using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCup : MonoBehaviour
{
	public float speed = 5f;
	Rigidbody2D	cup;
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
	
	void Move(float dir) {
		movement.Set(dir, 0, 0);
		movement = movement.normalized * speed * Time.deltaTime;
		cup.MovePosition(transform.position + movement);
	}
}
