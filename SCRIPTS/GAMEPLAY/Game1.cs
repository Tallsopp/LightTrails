using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game1 : MonoBehaviour
{
    private SpawnTiles c_SpawnTiles;

    private enum gameState { eMenu, eTutorial, eMain, eEndless, eTimer };
    private gameState status = gameState.eMenu;

    private enum shapes { eCircle, eDiagonal, eTriangle, eDiamond}
    private shapes Eform = shapes.eCircle;

    private List<GameObject> bounds;
    public List<GameObject> tiles;
    private List<GameObject> traps;

    public float pulseTime;
    public int counter;
    private int checker;

    public int[] circlePattern, diaganolPattern, trianglePattern, eDiamond;

    public GameObject nextObj;

    private void Start()
    {
        tiles = new List<GameObject>();
        traps = new List<GameObject>();

        checker = 0;

        int currentScene = SceneManager.GetActiveScene().buildIndex;

        switch (currentScene)
        {
            case 0:
                status = gameState.eMenu;
                break;
            case 1:
                status = gameState.eTutorial;
                break;
            case 2:
                status = gameState.eMain;
                AssignLists();
                break;
            case 3:
                status = gameState.eEndless;
                AssignLists();
                break;
            case 4:
                status = gameState.eTimer;
                AssignLists();
                break;
            default:
                print("Not a game state!");
                break;
        }
    }

    public void AssignLists()
    {
        c_SpawnTiles = FindObjectOfType<SpawnTiles>();

        if (c_SpawnTiles != null)
        {
            bounds = c_SpawnTiles.currentBounds;
            StartCoroutine(CreatePattern(pulseTime));
        }
    }

    IEnumerator CreatePattern(float waitTime)
    {
        int selectedTile;
        int value = 0;
        print(status);

        switch (status)
        {
            case gameState.eMenu:
                print("Welcome to Light Trails!");
                break;
            case gameState.eTutorial:
                print("Tutorial");
                break;
            case gameState.eMain:
                print("Main game");

                switch (Eform)
                {
                    case shapes.eCircle:
                        for (int i = 0; i < circlePattern.Length; i++)
                        {
                            selectedTile = circlePattern[i];
                            bounds[selectedTile].GetComponent<PulseTile>().m_levelVal += ++value;
                            StartCoroutine(bounds[selectedTile].GetComponent<PulseTile>().WaitAndPulse(1f));
                            tiles.Add(bounds[selectedTile]);
                            yield return new WaitForSeconds(waitTime);
                        }
                        break;
                    case shapes.eDiagonal:
                        break;
                    case shapes.eDiamond:
                        break;
                    case shapes.eTriangle:
                        break;
                }
                print(Eform);
                break;
            case gameState.eEndless:
                print("Endless");
                for (int i = 0; i < circlePattern.Length; i++)
                {
                    selectedTile = circlePattern[i];
                    bounds[selectedTile].GetComponent<PulseTile>().m_levelVal += ++value;
                    StartCoroutine(bounds[selectedTile].GetComponent<PulseTile>().WaitAndPulse(1f));
                    tiles.Add(bounds[selectedTile]);
                    yield return new WaitForSeconds(waitTime);
                }
                break;
            case gameState.eTimer:
                print("Timer");
                for (int i = 0; i < circlePattern.Length; i++)
                {
                    selectedTile = circlePattern[i];
                    bounds[selectedTile].GetComponent<PulseTile>().m_levelVal += ++value;
                    StartCoroutine(bounds[selectedTile].GetComponent<PulseTile>().WaitAndPulse(1f));
                    tiles.Add(bounds[selectedTile]);
                    yield return new WaitForSeconds(waitTime);
                }
                break;
        }
    }

    public void Progression()
    {
        if (counter == circlePattern.Length && nextObj != null)
        {
            print("Winner winner chicken dinner!");
            nextObj.SetActive(true);
        }
    }

}
