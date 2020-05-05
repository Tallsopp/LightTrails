using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileActivation : MonoBehaviour {

    private Game1 game;

    public enum tileState { eIdle, eActive, eWrong};
    public tileState currentState;
    private List<GameObject> bounds;

    public bool isActive;

    private void Start()
    {
        game = FindObjectOfType<Game1>();
        currentState = tileState.eIdle;
        isActive = false;
    }

    public void StateManager()
    {
        switch (currentState)
        {
            case tileState.eIdle:
                break;
            case tileState.eActive:
                break;
            case tileState.eWrong:
                game.counter = 0;
                break;
            default:
                print("Oh no!");
                break;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isActive = true;

            if (isActive == false)
                currentState = tileState.eIdle;
            else
                currentState = tileState.eActive;

            if (gameObject.GetComponent<PulseTile>().m_levelVal == 0)
                currentState = tileState.eWrong;
            else
                game.counter++;

            StateManager();
            game.Progression();
        }
    }
}
