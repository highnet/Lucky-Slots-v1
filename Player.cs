using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private UIManager uiManager;

    [SerializeField]
    private float bet = 0.1f;
    [SerializeField]
    private float balance = 100f;


    private void Awake()
    {
        uiManager = GameObject.FindGameObjectWithTag("UI Manager").GetComponent<UIManager>();
    }

    internal void AwardBalance(float winnings)
    {
        balance += winnings;
        uiManager.UpdateBalanceText();
    }

    public float GetBet()
    {
        return bet;
    }

    public float GetBalance()
    {
        return balance;
    }

    public void PlaceBet()
    {
        Debug.Log("Placing Bet");
        balance -= bet;
        uiManager.UpdateBalanceText();
    }
}
