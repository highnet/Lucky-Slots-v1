using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSymbolSpawner : MonoBehaviour
{

    private Vector3 spawnPoint;

    [SerializeField]
    private GameObject[] gameSymbolPrefabs;
    private GameSymbolPool gameSymbolPool;

    private void Awake()
    {
        gameSymbolPool = GameObject.FindGameObjectWithTag("Game Symbol Pool").GetComponent<GameSymbolPool>();
        spawnPoint = new Vector3(50, 50f, 0f);
        InstantiateAndPoolAllSymbols(spawnPoint);
    }

    private void InstantiateAndPoolAllSymbols(Vector3 spawnPoint)
    {

        for(int i = 0; i < gameSymbolPrefabs.Length; i++)
        {
            for (int j = 0; j < SlotsAttributes.NumberOfRows(); j++)
            {
                for (int k = 0; k < SlotsAttributes.NumberOfReels(); k++)
                {
                    GameObject spawnedsymbol = GameObject.Instantiate(gameSymbolPrefabs[i], spawnPoint + new Vector3(3 * i + (float)j, (float)k, 0f),Quaternion.identity);
                    gameSymbolPool.AddToPool(i, spawnedsymbol);
                }
            }
        }

        for(int i = 0; i < SlotsAttributes.NumberOfRows() * 2; i++)
        {
            for (int j = 0; j < SlotsAttributes.NumberOfReels() * 2; j++)
            {
                GameObject spawnedFakeSymbol = GameObject.Instantiate(gameSymbolPrefabs[UnityEngine.Random.Range(0,SlotsAttributes.NumberOfSymbols())], spawnPoint + new Vector3(i, 0f, 0f), Quaternion.identity);
                gameSymbolPool.AddToPool(7, spawnedFakeSymbol);
            }
        }
    }
}
