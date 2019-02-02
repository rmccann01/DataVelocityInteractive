using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public Button startButton;
    //Add listener for buttons
    void Start()
    {
        startButton.onClick.AddListener(OnClick);
    }
    //Load game from first menu on click
    void OnClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
