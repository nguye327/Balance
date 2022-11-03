using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPageScript : MonoBehaviour
{

    public void GoToSettings()
    {
        SceneManager.LoadScene("SettingsScene");


    }

    public void GoToGame()
    {
        SceneManager.LoadScene("Level1");
    }
    // Scripts to navigate to either game scene or settings scene


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
