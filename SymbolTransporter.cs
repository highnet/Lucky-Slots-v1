using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class SymbolTransporter : MonoBehaviour
{

    private SlotsAnchors slotsAnchors;
    private RolledSymbolGenerator rolledSymbolGenerator;
    private GameSymbolPool gameSymbolPool;
    private ActiveGameSymbols activeGameSymbols;
    private GameStateManager gameStateManager;


    private void Awake()
    {
        slotsAnchors = GameObject.FindGameObjectWithTag("Slots Anchors").GetComponent<SlotsAnchors>();
        rolledSymbolGenerator = GameObject.FindGameObjectWithTag("Rolled Symbol Generator").GetComponent<RolledSymbolGenerator>();
        gameSymbolPool = GameObject.FindGameObjectWithTag("Game Symbol Pool").GetComponent<GameSymbolPool>();
        activeGameSymbols = GameObject.FindGameObjectWithTag("Active Game Symbols").GetComponent<ActiveGameSymbols>();
        gameStateManager = GameObject.FindGameObjectWithTag("Game State Manager").GetComponent<GameStateManager>();

    }

    public void TransportSymbols()
    {
        Debug.Log("TRANSPORTING SYMBOLS");
        Symbol[,] rolledSymbols = rolledSymbolGenerator.Datum().RolledSymbols();

        for (int i = 0; i < SlotsAttributes.NumberOfRows(); i++)
        {
            for (int j = 0; j < SlotsAttributes.NumberOfReels(); j++)
            {
                activeGameSymbols.GetActiveGameSymbols()[i, j] = gameSymbolPool.FetchSymbol((int)rolledSymbols[i, j]);
                activeGameSymbols.GetActiveGameSymbols()[i, j].transform.position = slotsAnchors.Anchors()[i, j].transform.position - new Vector3(0f, -15f, 0f);

            }
        }
        activeGameSymbols.activeGameSymbolsIsPopulated = true;


        
        for (int i = 0; i < SlotsAttributes.NumberOfRows(); i++)
        {
            for (int j = 0; j < SlotsAttributes.NumberOfReels(); j++)
            {
                activeGameSymbols.GetFakeGameSymbols()[i, j] = gameSymbolPool.FetchSymbol(7);
                activeGameSymbols.GetFakeGameSymbols()[i, j].transform.position = slotsAnchors.Anchors()[i, j].transform.position - new Vector3(0f, -15f, 0f);

            }
        }

        StartCoroutine(TransportFakeSymbolCoroutine());
        


    }

    public IEnumerator TransportFakeSymbolCoroutine()
    {
        float tweenDuration = 2.0f;
        float tweenDelay = .1f;
        float fakeAnchorYOffset = (SlotsAttributes.NumberOfRows()) * SlotsAttributes.VerticalOffset();
        StartCoroutine(StartTransportSymbolsCouroutineAfterSeconds(.15f));


        for (int i = 0; i < SlotsAttributes.NumberOfReels(); i++)
        {
            Debug.Log("Transport Fake Symbols Coroutine");

            for (int j = 0; j < SlotsAttributes.NumberOfRows(); j++)
            {
                activeGameSymbols.GetFakeGameSymbols()[j, i].transform.DOMove(slotsAnchors.Anchors()[j, i].transform.position - new Vector3(0f, fakeAnchorYOffset, 0f), tweenDuration);
            }
            yield return new WaitForSeconds(tweenDelay);

        }
    }

    public IEnumerator StartTransportSymbolsCouroutineAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        StartCoroutine(TransportSymbolsCoroutine());

    }


    public IEnumerator SignalTransportEndAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameStateManager.SetTrigger("Symbols Transported");

    }

    public IEnumerator TransportSymbolsCoroutine()
    {
        float tweenDuration = 2.0f;
        float tweenDelay = .1f;
        StartCoroutine(SignalTransportEndAfterSeconds(SlotsAttributes.NumberOfRows() * tweenDelay));


        for(int i = 0; i < SlotsAttributes.NumberOfReels(); i++)
        {
            Debug.Log("Transport Symbols Coroutine");

            for (int j = 0; j < SlotsAttributes.NumberOfRows(); j++)
            {
                activeGameSymbols.GetActiveGameSymbols()[j, i].transform.DOMove(slotsAnchors.Anchors()[j, i].transform.position, tweenDuration);
            }
            yield return new WaitForSeconds(tweenDelay);

        }
    }
}
