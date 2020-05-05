using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoad : MonoBehaviour
{
    public GameObject hud;
    public GameObject game;
    public GameObject level;

    [HideInInspector]
    public List<GameObject> currentLevels;
    public int boundCount;
    private bool isHigher;

    private void Start()
    {
        currentLevels = new List<GameObject>();
        isHigher = true;

        if (gameObject.activeInHierarchy)
            CreateLevels();
    }

    private void CreateLevels()
    {
        float x = 20;
        float y = -50;
        RectTransform rt = level.GetComponent<Image>().rectTransform;
        float imageWidth = rt.rect.width;
        float imageHeight = rt.rect.height;
        int val = 1;

        for (int i = 0; i < boundCount; i++)
        {
            Vector3 pos = new Vector3(x, y, 0f);

            currentLevels.Add(Instantiate(level, pos, Quaternion.identity));
            currentLevels[i].transform.SetParent(transform, false);
            currentLevels[i].GetComponent<LevelSelector>().level += val++;

            x += imageWidth;

            if (isHigher)
                y += imageHeight / 4;
            if (!isHigher)
                y -= imageHeight / 4;

            isHigher = !isHigher;

            if (x >= 275)
            {
                isHigher = !isHigher;
                x = 20;
                y -= (imageHeight * 1.25f);
            }
        }
    }

    public void StartGame()
    {
        hud.SetActive(true);
        game.SetActive(true);
        gameObject.SetActive(false);
    }
}
