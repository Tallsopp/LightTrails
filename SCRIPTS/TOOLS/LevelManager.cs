using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    private int currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    public void Retry()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void LoadNextLevel()
    {
        PlayerPrefs.SetInt("Level", currentScene - 2);
        print("Current Level: " + PlayerPrefs.GetInt("Level"));

        int nextScene = currentScene + 1;
        SceneManager.LoadScene(nextScene);
    }

    public void LoadTutorial()
    {
        int completed = PlayerPrefs.GetInt("tutorialProgression");

        if (completed == 0)
        {
            SceneManager.LoadScene("Tutorial");
            PlayerPrefs.SetInt("tutorialProgression", 1);
        }
        else
            SceneManager.LoadScene("Level_Select");
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void QuitRequest()
    {
        Application.Quit();
    }
}
