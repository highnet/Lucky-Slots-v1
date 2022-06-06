using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayoutCalculator : MonoBehaviour
{
    private Player player;
    private GameStateManager gameStateManager;

    private void Awake()
    {
        gameStateManager = GameObject.FindGameObjectWithTag("Game State Manager").GetComponent<GameStateManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void CalculatePayout()
    {
        Debug.Log("CALCULATING PAYOUT");

        float winnings = 0f;

        player.AwardBalance(winnings);

        if (winnings == 0)
        {
            gameStateManager.SetTrigger("Calculated Payout");
        } else
        {
            gameStateManager.SetTrigger("Animate Winnings");
        }


    }
}
