using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private Animator gameState;
    private void Awake()
    {
        gameState = GetComponent<Animator>();
    }

    public Animator GameState()
    {
        return gameState;
    }

    public void SetBool(string name, bool predicate)
    {
        gameState.SetBool("Bets Open", predicate);
    }

    public void SetTrigger(string triggerName)
    {
        Debug.Log("TRIGGER: " + triggerName);
        gameState.SetTrigger(triggerName);

    }
    public bool AssertStateName(string stateName)
    {
        return gameState.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }

}
