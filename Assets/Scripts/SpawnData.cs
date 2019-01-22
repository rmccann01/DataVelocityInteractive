using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnData : MonoBehaviour
{
    public UpdateMosaic um;

    public float spawnDelay = 1;
    public static int packetsLeft = 10;
    public static int level = 0;
    public Sprite[] mosaics;
    public GameObject[] data;
    public Transform[] spawnPoints;

    public float flashSpeed = 5f;
    public Color flashColour = new Color(.75f, .75f, .75f, 1f);
    public Image TransImage;
    public Text TransText;
    bool transition = false;
    bool spawning = true;
    bool begTrans = false;
    bool waitDone = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnDelay);
    }

    // Update is called once per frame
    void Spawn()
    {
        //ballsDropped++;
        if (packetsLeft > 0)
        {
            int sPIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(data[level], spawnPoints[sPIndex].position, spawnPoints[sPIndex].rotation);
            packetsLeft--;
            spawning = true;
        }
        else
        {
            spawning = false;
        }
    }

    void Update()
    {
        if (!spawning && !transition)
        {
            CancelInvoke("Spawn");
            transition = true;
            begTrans = true;
            Invoke("TransScreen", 2.0f);
        }
        else if (begTrans && transition && waitDone)
        {
            BeginTrans();
        }
    }

    void BeginTrans()
    {
        if (TransImage.color != flashColour)
        {
            TransImage.color = Color.Lerp(TransImage.color, flashColour, flashSpeed * Time.deltaTime);
        }
        else
        {
            begTrans = false;
            TransScreen();
        }
    }

    void TransScreen()
    {
        transition = true;
        waitDone = true;
        if (begTrans)
        {
            BeginTrans();
        }
        else
        {
            TransText.color = new Color(0f, 0f, 0f, 1f);
            Invoke("EndTrans", 10.0f);
        }

    }

    void EndTrans()
    {
        level++;
        packetsLeft = 10;
        transition = false;
        begTrans = false;
        spawning = true;
        waitDone = false;
        RemoveDataCup.ballsCaught = 0;
        um.ResetImage();
        TransText.color = Color.clear;
        TransImage.color = Color.clear;
        Start();
    }
}
