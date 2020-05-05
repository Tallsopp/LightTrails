using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour {

    private string levelProgression = "Level";
    private string tutorialProgression = "Tutorial";
    private string skips = "Skips";

    public int tutorialCompleted;
    public int currentSkips;

	void Awake () {
        if(PlayerPrefs.GetInt("Level") <= 1)
            PlayerPrefs.SetInt(levelProgression, 1);

        PlayerPrefs.SetInt(tutorialProgression, tutorialCompleted);

        PlayerPrefs.SetInt(skips, currentSkips);
    }
}
