using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class SceneAndUI : MonoBehaviour
{
    //SceneManagement
    string activeScene;

    //Ui
    public bool pause;
    private bool isPaused;
    public GameObject pausePanel;

    private void Start()
    {
        pause = false;
        isPaused = false;
        pausePanel.SetActive(false);
    }

    private void Update()
    {
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

    public void Resume()
    {
        pause = false;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SaveProgression()
    {
        Debug.Log("Save");
    }

    public void LoadLastSave()
    {
        Debug.Log("Load");
    }
}
