using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    private LevelLoad lvlLoad;
    public int level;
    private Text levelText;

    private void Start()
    {
        lvlLoad = FindObjectOfType<LevelLoad>();
        levelText = GetComponentInChildren<Text>();
        levelText.text = level.ToString();
    }

    public void OnMouseDown()
    {
        print("Clicked on: " + level);
        lvlLoad.StartGame();
    }
}