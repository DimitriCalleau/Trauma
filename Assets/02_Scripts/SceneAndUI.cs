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
    public bool end;
    private bool isPaused;
    static private bool hasStarted;
    public GameObject pausePanel;
    public GameObject startPanel;
    public GameObject endPanel;
    public GameObject player;

    public GameObject[] Checkpoints;
    public int nbCheckpoints = 0;

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
        endPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            pause = !pause;
        }
        if (pause == true)
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            if (isPaused == false)
            {
                pausePanel.SetActive(true);
                isPaused = true;
            }
        }
        else
        {
            if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            if (isPaused == true)
            {
                pausePanel.SetActive(false);
                isPaused = false;
            }
        }
    }

    public void SceneLoader(string sceneName)
    {
        activeScene = sceneName;
        SceneManager.LoadScene(sceneName);
    }

    public void ActiveScene(string activeSceneName)
    {
        activeScene = activeSceneName;
    }

    public void Retry()
    {
        player.transform.position = Checkpoints[nbCheckpoints].gameObject.transform.position;
        //SceneManager.LoadScene(activeScene);
    }

    public void Play()
    {
        pause = false;
        hasStarted = true;
        startPanel.SetActive(false);

    }

    public void MainMenu()
    {
        if (hasStarted == true)
        {
            if (startPanel != null)
            {
                startPanel.SetActive(true);
            }
            hasStarted = false;
        }
        isPaused = false;
        pausePanel.SetActive(false);
    }

    public void Recommencer()
    {
        PlayerPrefs.DeleteAll();
        SceneLoader("Maison");
    }

    public void Resume()
    {
        pause = false;
    }

    public void End()
    {
        end = true;
        endPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void Continue()
    {
        end = false;
        endPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
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