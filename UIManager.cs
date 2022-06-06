using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    private Player player;
    public TextMeshProUGUI betText;
    public TextMeshProUGUI balanceText;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Start()
    {
        UpdateBetText();
        UpdateBalanceText();
    }

    public void UpdateBetText()
    {
        Debug.Log("Updating Bet Text");
        betText.text = "BET $ " + player.GetBet();
    }

    public void UpdateBalanceText()
    {
        Debug.Log("Updating Balance Text");
        balanceText.text = "BALANCE $ " + player.GetBalance();
    }
}
