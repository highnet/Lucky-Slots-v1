using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaylineSpawner : MonoBehaviour
{
    public List<GameObject> paylinePrefabs;
    public GameObject specialPaylinePrefab;

    [SerializeField]
    private List<GameObject> paylines;
    [SerializeField]
    private List<GameObject> specialPaylinesPool;
    [SerializeField]
    private List<GameObject> specialPaylines;

    private void Awake()
    {
        paylines = new List<GameObject>();
        specialPaylines = new List<GameObject>();
        specialPaylinesPool = new List<GameObject>();


        for (int i = 0; i < paylinePrefabs.Count; i++)
        {
          paylines.Add(GameObject.Instantiate(paylinePrefabs[i], new Vector3(-100f + i, -100f + i, 0f), Quaternion.identity));
        }

        for(int i = 0; i < 20; i++)
        {
            TakeBackToSpecialPaylinePool(
                GameObject.Instantiate(specialPaylinePrefab
                , new Vector3(-100f + i, -100f + i, 0f)
                , Quaternion.identity)
                );
        }
    }

    public GameObject FetchFromSpecialPaylinePool()
    {
        Debug.Log("Fetching From Special Payline Pool");
        GameObject go = specialPaylinesPool[0];
        specialPaylinesPool.RemoveAt(0);
        return go;
    }

    public void TakeBackToSpecialPaylinePool(GameObject go)
    {
        specialPaylines.Remove(go);
        specialPaylinesPool.Add(go);
    }

    public void AddToSpecialPaylines(GameObject go)
    {
        specialPaylines.Add(go);
    }


    public List<GameObject> GetSpecialPaylines()
    {
        return specialPaylines;
    }

    public List<GameObject> GetPayLines()
    {
        return paylines;
    }
    public int SpecialPayliensCount()
    {
        return specialPaylines.Count;
    }

    public int PayLinesCount()
    {
        return paylines.Count;
    }

   
}
