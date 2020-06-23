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

    //Affichage texte de mort
    public GameObject[] texteHistoire;
    bool text1;
    bool text2;
    bool text3;

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
        if (endPanel != null)
        {
            endPanel.SetActive(false);
        }

    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            pause = !pause;
        }
        if(end == false)
        {
            if (pause == true)
            {
                if (Cursor.lockState == CursorLockMode.Locked)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
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
                    Cursor.visible = false;
                }
                if (isPaused == true)
                {
                    pausePanel.SetActive(false);
                    isPaused = false;
                }
            }
        }
        else
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
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
        if(end == true)
        {
            end = false;
            endPanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            pause = true;
        }
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
        Cursor.visible = true;
    }

    public void Continue()
    {
        end = false;
        endPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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