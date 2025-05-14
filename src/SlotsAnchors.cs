using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsAnchors : MonoBehaviour
{

    [SerializeField]
    private GameObject anchorPrefab;
    [SerializeField]
    private GameObject[,] anchors;
    private Vector3 spawnPoint;


    private void Awake()
    {
        spawnPoint = new Vector3(-3.5f, 1.25f, 0f);
        

        anchors = new GameObject[SlotsAttributes.NumberOfRows(), SlotsAttributes.NumberOfReels()];

        for (int i = 0; i < SlotsAttributes.NumberOfRows(); i++)
        {
            for (int j = 0; j < SlotsAttributes.NumberOfReels(); j++)
            {
                GameObject spawnedAnchor = GameObject.Instantiate(anchorPrefab, spawnPoint + new Vector3(j * SlotsAttributes.HorizontalOffset(), -i * SlotsAttributes.VerticalOffset(),0f), Quaternion.identity);
                anchors[i, j] = spawnedAnchor;
            }
        }
    }

    public GameObject[,] Anchors()
    {
        return anchors;
    }
}
