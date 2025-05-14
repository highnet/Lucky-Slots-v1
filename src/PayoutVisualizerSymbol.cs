using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayoutVisualizerSymbol : MonoBehaviour
{
    private Vector3 startPosition;
    private void Awake()
    {
        startPosition = transform.position;
    }
    public Vector3 GetStartPosition()
    {
        return startPosition;
    }
}
