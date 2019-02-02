using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveDataBot : MonoBehaviour
{
    public int missedData = 0;
    //Remove data when it reaches bottom of screen
    private void OnTriggerEnter2D(Collider2D other) {
	Destroy(other.gameObject);
	missedData++;
    }
}
