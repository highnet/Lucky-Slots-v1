using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private GameStateManager gameStateManager;

    private void Awake()
    {
        gameStateManager = GameObject.FindGameObjectWithTag("Game State Manager").GetComponent<GameStateManager>();

    }


    public void SpinInput()
    {
        gameStateManager.SetTrigger("Player Pressed Enter");

    }

}
