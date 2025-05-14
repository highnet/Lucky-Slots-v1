using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class GameSymbolPool : MonoBehaviour
{
    // Pooled Symbols: Wild, Ten, Jack, Queen, King, Ace, Bonus
    [SerializeField]
    private List<GameObject> wildsPool; // id 0
    [SerializeField]
    private List<GameObject> tensPool; // id 1
    [SerializeField]
    private List<GameObject> jacksPool; // id 2
    [SerializeField]
    private List<GameObject> queensPool; // id 3
    [SerializeField]
    private List<GameObject> kingsPool; // id 4
    [SerializeField]
    private List<GameObject> acesPool; // id 5
    [SerializeField]
    private List<GameObject> bonusPool; // id 6
    [SerializeField]
    private List<GameObject> fakePool; // id 7

    private System.Random rng = new();

    public void Shuffle(List<GameObject> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            GameObject value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    private void Awake()
    {
        wildsPool = new List<GameObject>();
        tensPool = new List<GameObject>();
        jacksPool = new List<GameObject>();
        queensPool = new List<GameObject>();
        kingsPool = new List<GameObject>();
        acesPool = new List<GameObject>();
        bonusPool = new List<GameObject>();
        fakePool = new List<GameObject>();


    }

    public void AddToPool(int poolID, GameObject objectToAdd)
    {
        switch (poolID)
        {
            case 0:
                Debug.Log("Adding Wild To Pool");
                wildsPool.Add(objectToAdd);
                break;
            case 1:
                Debug.Log("Adding Ten To Pool");
                tensPool.Add(objectToAdd);
                break;
            case 2:
                Debug.Log("Adding Jack To Pool");
                jacksPool.Add(objectToAdd);
                break;
            case 3:
                Debug.Log("Adding Queen To Pool");
                queensPool.Add(objectToAdd);
                break;
            case 4:
                Debug.Log("Adding King To Pool");
                kingsPool.Add(objectToAdd);
                break;
            case 5:
                Debug.Log("Adding Ace To Pool");
                acesPool.Add(objectToAdd);
                break;
            case 6:
                Debug.Log("Adding Bonus To Pool");
                bonusPool.Add(objectToAdd);
                break;
            case 7:
                Debug.Log("Adding Fake To Pool");
                fakePool.Add(objectToAdd);
                break;
        }
    }

    public GameObject FetchSymbol(int poolID)
    {
        GameObject fetchedGO = null;
        switch (poolID)
        {
            case 0:
                fetchedGO = wildsPool[0];
                wildsPool.RemoveAt(0);
                break;
            case 1:
                fetchedGO = tensPool[0];
                tensPool.RemoveAt(0);
                break;
            case 2:
                fetchedGO = jacksPool[0];
                jacksPool.RemoveAt(0);
                break;
            case 3:
                fetchedGO = queensPool[0];
                queensPool.RemoveAt(0);
                break;
            case 4:
                fetchedGO = kingsPool[0];
                kingsPool.RemoveAt(0);
                break;
            case 5:
                fetchedGO = acesPool[0];
                acesPool.RemoveAt(0);
                break;
            case 6:
                fetchedGO = bonusPool[0];
                bonusPool.RemoveAt(0);
                break;
            case 7:
                fetchedGO = fakePool[0];
                fakePool.RemoveAt(0);
                break;
        }

        return fetchedGO;
    }

    public void ShuffleFakeSymbols()
    {
        Shuffle(fakePool);
    }


}


