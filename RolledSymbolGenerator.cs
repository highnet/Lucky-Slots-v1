using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RolledSymbolGenerator : MonoBehaviour
{
    private RolledSymbolDatum datum;

    public RolledSymbolDatum Datum()
    {
        return datum;
    }

    public void GenerateDatum()
    {
        Debug.Log("Generating Datum");
        datum = new RolledSymbolDatum();
    }
}
