using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public Button startButton;

    void Start()
    {
        startButton.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        SceneManager.LoadScene("SampleScene");
        //SceneManager.UnloadSceneAsync("IntroScene");
    }
}
