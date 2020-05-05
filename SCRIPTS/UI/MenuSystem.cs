using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSystem : MonoBehaviour
{
    public GameObject[] canvases;

    void Start()
    {
        for (int i = 0; i < canvases.Length; i++)
            canvases[i].gameObject.SetActive(false);

        CheckLevel();
    }

    private void CheckLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        canvases[0].SetActive(true);

        switch (currentLevel)
        {
            case 0:
                canvases[0].SetActive(true);
                break;
        }
    }

    public void SettingsMenu(bool state)
    {
        for (int i = 0; i < canvases.Length; i++)
            canvases[i].SetActive(false);

        if (state == true)
            canvases[1].SetActive(true);
        else
            canvases[0].SetActive(true);
    }
}
