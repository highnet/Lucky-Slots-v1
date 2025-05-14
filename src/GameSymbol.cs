using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSymbol : MonoBehaviour
{
    [SerializeField]
    private Symbol symbol;

    public Symbol GetSymbol()
    {
        return symbol;
    }
}
