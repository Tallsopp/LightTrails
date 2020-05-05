using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public bool unlocked;

    void Start()
    {
        Button m_Button = GetComponent<Button>();
        m_Button.interactable = unlocked;
    }
}