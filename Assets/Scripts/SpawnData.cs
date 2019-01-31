using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnData : MonoBehaviour
{
    public UpdateMosaic um;

    public float spawnDelay = 1.5f;
    public static int packetsLeft = 10;
    public float spawnDistance = 2;
    private int level = 0;
    public GameObject[] data;
    public Transform[] spawnPoints;
    public GameObject cup;

    public float flashSpeed = 10f;
    public Color flashColour = new Color(.75f, .75f, .75f, 1f);
    public Color clearColour = new Color(.75f, .75f, .75f, 0f);
    public Image TransImage;
    public Text TransText;

    bool spawning = true;
    bool transition = false;
    bool begTrans = false;
    bool endTrans = false;
    bool waitDone = false;

    public static Sprite[] endMosaics = new Sprite[5];
    public static int[] endBallsCaught = new int[5];

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1f, spawnDelay);
    }

    //update is called every frame
    void Update()
    {
        if (!spawning && !transition)
        {
            CancelInvoke("Spawn");
            transition = true;
            begTrans = true;
            Invoke("TransScreen", 2.2f);
            level++;
        }
        else if (begTrans && transition && waitDone)
        {
            BeginTrans();
        }
        else if (endTrans && transition && waitDone)
        {
            EndTrans();
        }
    }

    void Spawn()
    {
        //ballsDropped++;
        if (packetsLeft > 0)
        {
            Vector3 cupPos = cup.transform.position;
            int sPIndex = Random.Range(0, spawnPoints.Length);
            while(Mathf.Abs(spawnPoints[sPIndex].position.magnitude - cupPos.magnitude) < spawnDistance)
            {
                sPIndex = Random.Range(0, spawnPoints.Length);
            }
            Instantiate(data[level], spawnPoints[sPIndex].position, spawnPoints[sPIndex].rotation);
            packetsLeft--;
            spawning = true;
        }
        else
        {
            spawning = false;
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
            TransText.text = string.Concat("Level ", level.ToString(), " Completed");
            waitDone = false;
            endTrans = true;
            LevelManager();
        }

    }

    void EndTrans()
    {
        waitDone = true;
        TransText.color = Color.clear;
        RemoveDataCup.ballsCaught = 0;
        //um.ResetImage();

        if (TransImage.color != clearColour)
        {
            TransImage.color = Color.Lerp(TransImage.color, clearColour, (flashSpeed-7f) * Time.deltaTime);
        }
        else
        {
            packetsLeft = 10;
            transition = false;
            begTrans = false;
            endTrans = false;
            spawning = true;
            waitDone = false;
            um.ResetImage();
            Start();
        }
    }

    void LevelManager()
    {
        if(level == 1)
        {
            endMosaics[level - 1] = um.mosaics[RemoveDataCup.ballsCaught];
            endBallsCaught[level - 1] = RemoveDataCup.ballsCaught;
            spawnDelay = 1.25f;
            Invoke("EndTrans", 3.0f);
        }
        else if(level == 2)
        {
            endMosaics[level - 1] = um.mosaics[10+ RemoveDataCup.ballsCaught];
            endBallsCaught[level - 1] = RemoveDataCup.ballsCaught;
            spawnDelay = 0.8f;
            Invoke("EndTrans", 3.0f);
        }
        else if (level == 3)
        {
            endMosaics[level - 1] = um.mosaics[20+ RemoveDataCup.ballsCaught];
            endBallsCaught[level - 1] = RemoveDataCup.ballsCaught;
            spawnDelay = .6f;
            Invoke("EndTrans", 3.0f);
        }
        else if (level == 4)
        {
            endMosaics[level - 1] = um.mosaics[30+ RemoveDataCup.ballsCaught];
            endBallsCaught[level - 1] = RemoveDataCup.ballsCaught;
            spawnDelay = .1f;
            Invoke("EndTrans", 3.0f);
        }
        else if (level == 5)
        {
            endMosaics[level - 1] = um.mosaics[40+ RemoveDataCup.ballsCaught];
            endBallsCaught[level - 1] = RemoveDataCup.ballsCaught;
            Invoke("ToEndGame", 3.0f);
        }

    }

    void ToEndGame()
    {
        TransText.color = Color.clear;
        RemoveDataCup.ballsCaught = 0;
        um.ResetImage();
        level = 0;
        packetsLeft = 10;

        SceneManager.LoadScene("EndingScene");
    }
}
