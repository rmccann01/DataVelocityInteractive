using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveDataBot : MonoBehaviour
{
	public int missedData = 0;
    private void OnTriggerEnter2D(Collider2D other) {
		Destroy(other.gameObject);
		missedData++;
	}
}
