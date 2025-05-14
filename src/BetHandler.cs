using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetHandler : MonoBehaviour
{
    private GameStateManager gameStateManager;
    private Player player;

    private void Awake()
    {
        gameStateManager = GameObject.FindGameObjectWithTag("Game State Manager").GetComponent<GameStateManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void HandleBet()
    {
        Debug.Log("Handling Bet");
        player.PlaceBet();
    }


    // Update is called once per frame
    void Update()
    {
        gameStateManager.SetBool("Bets Open", player.GetBet() <= player.GetBalance());

    }
}
