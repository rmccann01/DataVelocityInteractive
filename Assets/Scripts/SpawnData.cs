using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnData : MonoBehaviour
{
	public float spawnDelay = 1;
	public int packetsLeft = 10;
	public GameObject data;
	public Transform[] spawnPoints;
	
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnDelay);
    }

    // Update is called once per frame
    void Spawn()
    {
       if(packetsLeft > 0) {
			int sPIndex = Random.Range(0, spawnPoints.Length);   
			Instantiate(data, spawnPoints[sPIndex].position, spawnPoints[sPIndex].rotation);
			packetsLeft--;
	   }
    }
}
