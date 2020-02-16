using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class SceneAndUI : MonoBehaviour
{
    //SceneManagement
    public string activeScene;

    //Ui
    public bool pause;
    private bool isPaused;
    static private bool hasStarted;
    public GameObject pausePanel;
    public GameObject startPanel;
    public GameObject player;

    private void Start()
    {
        if(hasStarted == false)
        {
            pause = true;
        }
        else if (hasStarted == true)
        {
            pause = false;
            if(startPanel != null)
            {
                startPanel.SetActive(false);
            }
        }
        isPaused = false;
        pausePanel.SetActive(false);
    }

    private void Update()
    {
        Debug.Log(hasStarted);
        if (Input.GetButtonDown("Cancel"))
        {
            pause = !pause;
        }
        if(pause == true)
        {
            if(isPaused == false)
            {
                pausePanel.SetActive(true);
                isPaused = true;
            }
        }
        else
        {
            if(isPaused == true)
            {
                pausePanel.SetActive(false);
                isPaused = false;
            }
        }
    }

    public void SceneLoader(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

        activeScene = sceneName;
    }

    public void Retry()
    {
        SceneManager.LoadScene(activeScene);
    }
    
    public void Play()
    {
        pause = false;
        hasStarted = true;
        startPanel.SetActive(false);
    }

    public void Resume()
    {
        pause = false;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Save()
    {
        player.GetComponent<PlayerController>().SaveTransform();
    }
    public void Load()
    {
        player.GetComponent<PlayerController>().LoadTransform();
    }
}
