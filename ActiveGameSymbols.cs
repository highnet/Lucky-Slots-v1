using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGameSymbols : MonoBehaviour
{
    private GameObject[,] activeGameSymbols;
    private GameObject[,] fakeGameSymbols;
    public bool activeGameSymbolsIsPopulated = false;


    private void Awake()
    {
        activeGameSymbols = new GameObject[SlotsAttributes.NumberOfRows(), SlotsAttributes.NumberOfReels()];
        fakeGameSymbols = new GameObject[SlotsAttributes.NumberOfRows(), SlotsAttributes.NumberOfReels()];
    }

    public GameObject[,] GetActiveGameSymbols()
    {
        return activeGameSymbols;
    }
    public GameObject[,] GetFakeGameSymbols()
    {
        return fakeGameSymbols;
    }

}
