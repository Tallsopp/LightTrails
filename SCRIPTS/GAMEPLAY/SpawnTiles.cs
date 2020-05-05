using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnTiles : MonoBehaviour
{
    public GameObject bound;
    [HideInInspector]
    public List<GameObject> currentBounds;

    public int boundCount;
    private int applyVal;
    public int minTraps;
    public int maxTraps;

    private bool isHigher;

    private void Start()
    {
        currentBounds = new List<GameObject>();
        isHigher = true;
    }

    void CreateBounds()
    {
        float x = 20;
        float y = -50;
        RectTransform rt = bound.GetComponent<Image>().rectTransform;
        float imageWidth = rt.rect.width;
        float imageHeight = rt.rect.height;

        for (int i = 0; i < boundCount; i++)
        {
            Vector3 pos = new Vector3(x, y, 0f);

            currentBounds.Add(Instantiate(bound, pos, Quaternion.identity));
            currentBounds[i].transform.SetParent(transform, false);

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
}
