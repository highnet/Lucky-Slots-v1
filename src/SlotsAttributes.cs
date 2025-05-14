using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Symbol { Wild, Ten, Jack, Queen, King, Ace, Bonus };

public static class SlotsAttributes 
{
    private const int numberOfReels = 5;
    private const int numberOfRows = 3;
    private const int numberOfSymbols = 7;
    private const float verticalOffset = 2.0f;
    private const float horizontalOffset = 2.25f;


    public static float VerticalOffset()
    {
        return verticalOffset;
    }

    public static float HorizontalOffset()
    {
        return horizontalOffset;
    }
    public static int NumberOfSymbols()
    {
        return numberOfSymbols;
    }
    public static int NumberOfReels()
    {
        return numberOfReels;
    }

    public static int NumberOfRows()
    {
        return numberOfRows;
    }

}
