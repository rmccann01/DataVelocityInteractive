using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class EndingSceneButtons : MonoBehaviour
{
    public Button restartButton;
    public Button exitGameButton;

    public Image[] mosaicsAtEnd;
    public int[] ballsCaughtEnd = new int[5];
    public Text[] ballsCaughtText;

    //Add listeners for buttons and show images for levels
    void Start()
    {
        restartButton.onClick.AddListener(RestartClick);
        exitGameButton.onClick.AddListener(ExitGameClick);
        UpdateStats();
    }
    //Restart From beginning
    void RestartClick()
    {
        SceneManager.LoadScene("SampleScene");
        //Application.LoadLevel("SampleScene");
    }
    //End game
    void ExitGameClick()
    {
        EditorApplication.isPlaying = false;
        Application.Quit();
        //Application.Unload();
    }
    //Display images and score for each level
    void UpdateStats()
    {
        for(int i=0; i < 5; i++)
        {
            mosaicsAtEnd[i].sprite = SpawnData.endMosaics[i];
            ballsCaughtEnd[i] = SpawnData.endBallsCaught[i];
            ballsCaughtText[i].text= string.Concat("Balls Caught: ", ballsCaughtEnd[i].ToString(), " /10");
        }
    }
}
