using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text[] scoreboard;

    public List<GameObject> tiles;
    public List<GameObject> selectedTiles;
    public GameObject nextLevelScreen;

    public int attempts;
    public int amount;

    private Tile[] tileScript;

    private int num = 1;
    private int maxAmount = 1;

    void Start()
    {
        tileScript = FindObjectsOfType<Tile>();


        if (nextLevelScreen != null)
            nextLevelScreen.SetActive(false);

        for (int i = 0; i < tileScript.Length; i++)
            tiles.Add(tileScript[i].gameObject);

        scoreboard[0].text = "0";
        scoreboard[1].text = "0";

        StartCoroutine(FadeTile(1f));
        GetAmount();
    }

    private void GetAmount()
    {
        foreach (GameObject tile in tiles)
        {
            if (tile.GetComponent<Tile>().tileIndex >= 1)
                maxAmount++;
        }
    }

    public void CheckAllTiles()
    {
        amount = 1;
        scoreboard[0].text = attempts.ToString();

        for (int i = 0; i < selectedTiles.Count; i++)
        {
            if (selectedTiles[i].GetComponent<Tile>().tileIndex == amount)
                amount++;
        }

        if (amount == maxAmount)
        {
            for (int i = 0; i < tiles.Count; i++)
                tiles[i].GetComponent<BoxCollider2D>().enabled = false;

            nextLevelScreen.SetActive(true);

            print("Winner");
        }
    }

    public void RevealPath()
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            tiles[i].GetComponent<Tile>().tileIndex = 0;
        }

        StartCoroutine(FadeTile(1f));
    }

    private IEnumerator FadeTile(float waitTime)
    {
        while (true)
        {
            for (int i = 0; i < tiles.Count; i++)
            {
                if (tiles[i].GetComponent<Tile>().tileIndex == num)
                {
                    yield return new WaitForSeconds(waitTime);
                    tiles[i].GetComponent<Tile>().isFading = true;
                    num++;
                }
            }
            if (num >= maxAmount) break;
        }
    }
}