using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    private int m_unlockedLevels;

    public List<GameObject> allLevels;

    void Start()
    {
        m_unlockedLevels = PlayerPrefs.GetInt("Level");

        foreach (Transform child in transform)
            allLevels.Add(child.gameObject);

        for (int i = 0; i < allLevels.Count; i++)
        {
            if (i <= m_unlockedLevels)
                allLevels[i].GetComponent<LevelButton>().unlocked = true;
            else
                allLevels[i].GetComponent<LevelButton>().unlocked = false;
        }
    }
}
