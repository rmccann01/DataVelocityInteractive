using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnData : MonoBehaviour
{
    public UpdateMosaic um;//Script to update moasics

    public float spawnDelay = 1.5f;//time between ball dropping
    public static int packetsLeft = 10;//total packets
    public float spawnDistance = 2;//distance from cup to spawn data
    private int level = 0;
    public GameObject[] data;
    public Transform[] spawnPoints;
    public GameObject cup;

    //variables used to smooth transition screen between levels
    public float flashSpeed = 10f;
    public Color flashColour = new Color(.75f, .75f, .75f, 1f);
    public Color clearColour = new Color(.75f, .75f, .75f, 0f);
    public Image TransImage;
    public Text TransText;

    //booleans used to control when functions are called in update()
    bool spawning = true;
    bool transition = false;
    bool begTrans = false;
    bool endTrans = false;
    bool waitDone = false;

    //arrays to store results after each level
    public static Sprite[] endMosaics = new Sprite[5];
    public static int[] endBallsCaught = new int[5];

    //Start spawning data every spawnDelay seconds
    void Start()
    {
        InvokeRepeating("Spawn", 1f, spawnDelay);
    }

    //Transition if needed otherwise continue
    void Update()
    {
        if (!spawning && !transition)//calls transition function when balls are done spawning
        {
            CancelInvoke("Spawn");
            transition = true;
            begTrans = true;
            Invoke("TransScreen", 2.2f);
            level++;
        }
        else if (begTrans && transition && waitDone)//calls begin transition every frame after waiting for last ball to finish falling
        {
            BeginTrans();
        }
        else if (endTrans && transition && waitDone)//calls end transition every frame after waiting for words to display for long enough
        {
            EndTrans();
        }
    }
    //Spawn data if they still need to spawn
    void Spawn()
    {
        if (packetsLeft > 0)
        {
            Vector3 cupPos = cup.transform.position;//position of cup
            int sPIndex = Random.Range(0, spawnPoints.Length);//index of data spawn points
            while(Mathf.Abs(spawnPoints[sPIndex].position.magnitude - cupPos.magnitude) < spawnDistance)
            {
                sPIndex = Random.Range(0, spawnPoints.Length);//choose new spawn point if too close to cup
            }
            Instantiate(data[level], spawnPoints[sPIndex].position, spawnPoints[sPIndex].rotation);//spawn data
            packetsLeft--;
            spawning = true;
        }
        else
        {
            spawning = false;
        }
    }

    //Start the transitions between levels
    void BeginTrans()
    {
        if (TransImage.color != flashColour)//if screen isnt correct color continue fading to that color
        {
            TransImage.color = Color.Lerp(TransImage.color, flashColour, flashSpeed * Time.deltaTime);
        }
        else
        {
            begTrans = false;
            TransScreen();//transition
        }
    }

    //transition between levels
    void TransScreen()
    {
        transition = true;
        waitDone = true;

        //Makes the image black before the next level
        um.ClearImage();

        if (begTrans)//if hasn't begun transition do so
        {
            BeginTrans();
        }
        else//output level complete and prepare next level's data
        {
            TransText.color = new Color(0f, 0f, 0f, 1f);
            TransText.text = string.Concat("Level ", level.ToString(), " Completed");
            waitDone = false;
            endTrans = true;//end transition preparing to be called in update()
            LevelManager();
        }

    }

    //End transition between levels
    void EndTrans()
    {
        waitDone = true;//end transition called every frame in update()
        TransText.color = Color.clear;//makes displayed text disapear
        RemoveDataCup.ballsCaught = 0;//reset how many balls caught during level back to zero

        if (TransImage.color != clearColour)//if transition screen isnt clear continue fading to clear
        {
            TransImage.color = Color.Lerp(TransImage.color, clearColour, (flashSpeed-7f) * Time.deltaTime);
        }
        else//resets booleans and turns packets left to be dropped back to ten
        {
            packetsLeft = 10;
            transition = false;
            begTrans = false;
            endTrans = false;
            spawning = true;
            waitDone = false;
            um.ResetImage();//resets displayed mosaic to be completely covered
            Start();
        }
    }

    //change spawn delay based on level and transition to next level
    //store data for end of levels for last screen
    //then begins ending the transition and moves to next level
    void LevelManager()
    {
        if(level == 1)
        {
            if(RemoveDataCup.ballsCaught == 0)
            {
                endMosaics[level - 1] = um.mosaics[0];
            }
            else
            {
                endMosaics[level - 1] = um.mosaics[RemoveDataCup.ballsCaught];
            }
            endBallsCaught[level - 1] = RemoveDataCup.ballsCaught;
            spawnDelay = 1.25f;
            Invoke("EndTrans", 3.0f);
        }
        else if(level == 2)
        {
            if (RemoveDataCup.ballsCaught == 0)
            {
                endMosaics[level - 1] = um.mosaics[0];
            }
            else
            {
                endMosaics[level - 1] = um.mosaics[10 + RemoveDataCup.ballsCaught];
            }
            endBallsCaught[level - 1] = RemoveDataCup.ballsCaught;
            spawnDelay = 0.8f;
            Invoke("EndTrans", 3.0f);
        }
        else if (level == 3)
        {
            if (RemoveDataCup.ballsCaught == 0)
            {
                endMosaics[level - 1] = um.mosaics[0];
            }
            else
            {
                endMosaics[level - 1] = um.mosaics[20 + RemoveDataCup.ballsCaught];
            }
            endBallsCaught[level - 1] = RemoveDataCup.ballsCaught;
            spawnDelay = .6f;
            Invoke("EndTrans", 3.0f);
        }
        else if (level == 4)
        {
            if (RemoveDataCup.ballsCaught == 0)
            {
                endMosaics[level - 1] = um.mosaics[0];
            }
            else
            {
                endMosaics[level - 1] = um.mosaics[30 + RemoveDataCup.ballsCaught];
            }
            endBallsCaught[level - 1] = RemoveDataCup.ballsCaught;
            spawnDelay = .1f;
            Invoke("EndTrans", 3.0f);
        }
        else if (level == 5)
        {
            if (RemoveDataCup.ballsCaught == 0)
            {
                endMosaics[level - 1] = um.mosaics[0];
            }
            else
            {
                endMosaics[level - 1] = um.mosaics[40 + RemoveDataCup.ballsCaught];
            }
            endBallsCaught[level - 1] = RemoveDataCup.ballsCaught;
            Invoke("ToEndGame", 3.0f);//goes to end screen after 3 seconds
        }

    }

    //go to last screen
    void ToEndGame()
    {
        TransText.color = Color.clear;

        //resets variables in case user wants to play again
        RemoveDataCup.ballsCaught = 0;
        um.ResetImage();
        level = 0;
        packetsLeft = 10;

        SceneManager.LoadScene("EndingScene");
    }
}
