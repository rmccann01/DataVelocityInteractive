using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnData : MonoBehaviour
{
	public float spawnDelay = 1;
	public int packetsLeft = 10;
    //public int ballsDropped = 0;
    public int level = 0;
    public Sprite[] mosaics;
    public GameObject[] data;
	public Transform[] spawnPoints;
	
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnDelay);
    }

    // Update is called once per frame
    void Spawn()
    {
        //ballsDropped++;
       if(packetsLeft > 0) {
			int sPIndex = Random.Range(0, spawnPoints.Length);   
			Instantiate(data[level], spawnPoints[sPIndex].position, spawnPoints[sPIndex].rotation);
			packetsLeft--;
	   }
    }
}
