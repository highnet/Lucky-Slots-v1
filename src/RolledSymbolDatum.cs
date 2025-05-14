using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RolledSymbolDatum
{

    private Symbol[,] rolledSymbols;

    public RolledSymbolDatum()
    {
        rolledSymbols = GenerateRoll();
        PrintSymbols();
    }

    public Symbol[,] RolledSymbols()
    {
        return rolledSymbols;
    }

    public Symbol[,] GenerateRoll()
    {
        Debug.Log("Generating Roll");

        Symbol [,] symbols = new Symbol[SlotsAttributes.NumberOfRows(), SlotsAttributes.NumberOfReels()];


        for (int i = 0; i < SlotsAttributes.NumberOfRows(); i++)
        {
            for (int j = 0; j < SlotsAttributes.NumberOfReels(); j++)
            {
                symbols[i, j] = (Symbol) UnityEngine.Random.Range(0,SlotsAttributes.NumberOfSymbols());
            }
        }
        return symbols;
    }

    public void PrintSymbols()
    {
        Debug.Log("Printing Symbols");
        for(int i = 0; i < SlotsAttributes.NumberOfRows(); i++)
        {
            for (int j = 0; j < SlotsAttributes.NumberOfReels(); j++)
            {
                Debug.Log("(" + i + "," + j + "): " + rolledSymbols[i, j]);
            }
            Debug.Log("=======");
        }
    }

}
