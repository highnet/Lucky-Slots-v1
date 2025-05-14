using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SymbolCleaner : MonoBehaviour
{

    private SlotsAnchors slotsAnchors;
    private ActiveGameSymbols activeGameSymbols;
    private GameStateManager gameStateManager;
    private GameSymbolPool gameSymbolPool;

    private void Awake()
    {
        slotsAnchors = GameObject.FindGameObjectWithTag("Slots Anchors").GetComponent<SlotsAnchors>();
        activeGameSymbols = GameObject.FindGameObjectWithTag("Active Game Symbols").GetComponent<ActiveGameSymbols>();
        gameStateManager = GameObject.FindGameObjectWithTag("Game State Manager").GetComponent<GameStateManager>();
        gameSymbolPool = GameObject.FindGameObjectWithTag("Game Symbol Pool").GetComponent<GameSymbolPool>();

    }

    public void CleanSymbols()
    {
        StartCoroutine(CleanSymbolsCoroutine());

    }


    public IEnumerator SignalCleanEndAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameStateManager.SetTrigger("Cleaned Symbols");

    }

    public IEnumerator CleanSymbolsCoroutine()
    {

        if (activeGameSymbols.activeGameSymbolsIsPopulated)
        {
            float tweenDuration = 2.0f;
            float tweenDelay = .1f;
            StartCoroutine(SignalCleanEndAfterSeconds(0.5f));

            for (int i = 0; i < SlotsAttributes.NumberOfReels(); i++)
            {
                Debug.Log("Transport Symbols Coroutine");


                for (int j = 0; j < SlotsAttributes.NumberOfRows(); j++)
                {
                    activeGameSymbols.GetActiveGameSymbols()[j, i].transform.DOMove(slotsAnchors.Anchors()[j, i].transform.position - new Vector3(0f, 15f, 0f), tweenDuration);
                }
                yield return new WaitForSeconds(tweenDelay);

            }

            GameObject[,] gameSymbols = activeGameSymbols.GetActiveGameSymbols();
            GameObject[,] fakeSymbols = activeGameSymbols.GetFakeGameSymbols();



            
            for(int i = 0; i < SlotsAttributes.NumberOfReels(); i++)
            {
                for(int j = 0;  j < SlotsAttributes.NumberOfRows(); j++)
                {
                    Debug.Log("(" + j + "," + i + "): ");
                    GameObject go = gameSymbols[j, i];
                    GameSymbol gs = go.GetComponent<GameSymbol>();
                    gameSymbolPool.AddToPool((int)gs.GetSymbol(), go);
                    gameSymbols[j, i] = null;

                  
                }
            }

            for (int i = 0; i < SlotsAttributes.NumberOfReels(); i++)
            {
                for (int j = 0; j < SlotsAttributes.NumberOfRows(); j++)
                {
                    GameObject go = fakeSymbols[j, i];
                    gameSymbolPool.AddToPool(7, go);
                    fakeSymbols[j, i] = null;
                }
            }

            gameSymbolPool.ShuffleFakeSymbols();



        } else
        {
            gameStateManager.SetTrigger("Cleaned Symbols");

        }


    }
}
