using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PulseTile : MonoBehaviour
{
    //[HideInInspector]
    public int m_levelVal;

    private Image image;
    public Color originColor;
    public Color newColor;
    public float timer;

    void Start()
    {
        image = GetComponent<Image>();
    }

    public IEnumerator WaitAndPulse(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        image.CrossFadeColor(newColor, waitTime, false, true);
        yield return new WaitForSeconds(waitTime);
        image.CrossFadeColor(originColor, waitTime, false, true);
    }
}
