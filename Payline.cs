using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Payline : MonoBehaviour
{
    private SlotsAnchors slotsAnchors;

    [SerializeField]
    private int paylineID;
    [SerializeField]
    private List<Vector2> path;
    [SerializeField]
    private LineRenderer lineRenderer;
    [SerializeField]
    private bool winner;
    [SerializeField]
    private int payLineLength;
    [SerializeField]
    private Symbol winningSymbol;


    public void SetWinningSymbol(Symbol symbol)
    {
        winningSymbol = symbol;
    }
    public Symbol GetWinningSymbol()
    {
        return winningSymbol;
    }

    public int GetPaylineID()
    {
        return paylineID;
    }
    public int GetPayLineLength()
    {
        return payLineLength;
    }
    public List<Vector2> GetPath()
    {
        return path;
    }

    public void SetPath(List<Vector2> newPath)
    {
        path = newPath;
        payLineLength = path.Count;
    }

    private void Awake()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
        lineRenderer = GetComponent<LineRenderer>();
        slotsAnchors = GameObject.FindGameObjectWithTag("Slots Anchors").GetComponent<SlotsAnchors>();
        switch (paylineID)
        {
            // 00
            case 0:
                path.Add(new Vector3(0, 0));
                path.Add(new Vector3(0, 1));
                path.Add(new Vector3(0, 2));
                break;
            case 1:
                path.Add(new Vector3(0, 0));
                path.Add(new Vector3(0, 1));
                path.Add(new Vector3(1, 2));
                break;
            case 2:
                path.Add(new Vector3(0, 0));
                path.Add(new Vector3(1, 1));
                path.Add(new Vector3(0, 2));
                break;
            case 3:
                path.Add(new Vector3(0, 0));
                path.Add(new Vector3(1, 1));
                path.Add(new Vector3(1, 2));
                break;
            case 4:
                path.Add(new Vector3(0, 0));
                path.Add(new Vector3(1, 1));
                path.Add(new Vector3(2, 2));
                break;
            case 5:
                path.Add(new Vector3(0, 0));
                path.Add(new Vector3(1, 1));
                path.Add(new Vector3(2, 2));
                break;

                // 01
            case 6:
                path.Add(new Vector3(0, 1));
                path.Add(new Vector3(0, 2));
                path.Add(new Vector3(0, 3));
                break;
            case 7:
                path.Add(new Vector3(0, 1));
                path.Add(new Vector3(0, 2));
                path.Add(new Vector3(1, 3));
                break;
            case 8:
                path.Add(new Vector3(0, 1));
                path.Add(new Vector3(1, 2));
                path.Add(new Vector3(0, 3));
                break;
            case 9:
                path.Add(new Vector3(0, 1));
                path.Add(new Vector3(1, 2));
                path.Add(new Vector3(1, 3));
                break;
            case 10:
                path.Add(new Vector3(0, 1));
                path.Add(new Vector3(1, 2));
                path.Add(new Vector3(2, 3));
                break;

            // 02

            case 11:
                path.Add(new Vector3(0, 2));
                path.Add(new Vector3(0, 3));
                path.Add(new Vector3(0, 4));
                break;
            case 12:
                path.Add(new Vector3(0, 2));
                path.Add(new Vector3(0, 3));
                path.Add(new Vector3(1, 4));
                break;
            case 13:
                path.Add(new Vector3(0, 2));
                path.Add(new Vector3(1, 3));
                path.Add(new Vector3(0, 4));
                break;
            case 14:
                path.Add(new Vector3(0, 2));
                path.Add(new Vector3(1, 3));
                path.Add(new Vector3(1, 4));
                break;
            case 15:
                path.Add(new Vector3(0, 2));
                path.Add(new Vector3(1, 3));
                path.Add(new Vector3(2, 4));
                break;
            // 10
            case 16:
                path.Add(new Vector3(1, 0));
                path.Add(new Vector3(0, 1));
                path.Add(new Vector3(0, 2));
                break;
            case 17:
                path.Add(new Vector3(1, 0));
                path.Add(new Vector3(0, 1));
                path.Add(new Vector3(1, 2));
                break;
            case 18:
                path.Add(new Vector3(1, 0));
                path.Add(new Vector3(1, 1));
                path.Add(new Vector3(0, 2));
                break;
            case 19:
                path.Add(new Vector3(1, 0));
                path.Add(new Vector3(1, 1));
                path.Add(new Vector3(1, 2));
                break;
            case 20:
                path.Add(new Vector3(1, 0));
                path.Add(new Vector3(1, 1));
                path.Add(new Vector3(2, 2));
                break;
            case 21:
                path.Add(new Vector3(1, 0));
                path.Add(new Vector3(2, 1));
                path.Add(new Vector3(1, 2));
                break;
            case 22:
                path.Add(new Vector3(1, 0));
                path.Add(new Vector3(2, 1));
                path.Add(new Vector3(2, 2));
                break;
            // 11
            case 23:
                path.Add(new Vector3(1, 1));
                path.Add(new Vector3(0, 2));
                path.Add(new Vector3(0, 3));
                break;
            case 24:
                path.Add(new Vector3(1, 1));
                path.Add(new Vector3(0, 2));
                path.Add(new Vector3(1, 3));
                break;
            case 25:
                path.Add(new Vector3(1, 1));
                path.Add(new Vector3(1, 2));
                path.Add(new Vector3(0, 3));
                break;
            case 26:
                path.Add(new Vector3(1, 1));
                path.Add(new Vector3(1, 2));
                path.Add(new Vector3(1, 3));
                break;
            case 27:
                path.Add(new Vector3(1, 1));
                path.Add(new Vector3(1, 2));
                path.Add(new Vector3(2, 3));
                break;
            case 28:
                path.Add(new Vector3(1, 1));
                path.Add(new Vector3(2, 2));
                path.Add(new Vector3(1, 3));
                break;
            case 29:
                path.Add(new Vector3(1, 1));
                path.Add(new Vector3(2, 2));
                path.Add(new Vector3(2, 3));
                break;
            // 12
            case 30:
                path.Add(new Vector3(1, 2));
                path.Add(new Vector3(0, 3));
                path.Add(new Vector3(0, 4));
                break;
            case 31:
                path.Add(new Vector3(1, 2));
                path.Add(new Vector3(0, 3));
                path.Add(new Vector3(1, 4));
                break;
            case 32:
                path.Add(new Vector3(1, 2));
                path.Add(new Vector3(1, 3));
                path.Add(new Vector3(0, 4));
                break;
            case 33:
                path.Add(new Vector3(1, 2));
                path.Add(new Vector3(1, 3));
                path.Add(new Vector3(1, 4));
                break;
            case 34:
                path.Add(new Vector3(1, 2));
                path.Add(new Vector3(1, 3));
                path.Add(new Vector3(2, 4));
                break;
            case 35:
                path.Add(new Vector3(1, 2));
                path.Add(new Vector3(2, 3));
                path.Add(new Vector3(1, 4));
                break;
            case 36:
                path.Add(new Vector3(1, 2));
                path.Add(new Vector3(2, 3));
                path.Add(new Vector3(2, 4));
                break;

            // 20
            case 37:
                path.Add(new Vector3(2, 0));
                path.Add(new Vector3(1, 1));
                path.Add(new Vector3(0, 2));
                break;
            case 38:
                path.Add(new Vector3(2, 0));
                path.Add(new Vector3(1, 1));
                path.Add(new Vector3(1, 2));
                break;
            case 39:
                path.Add(new Vector3(2, 0));
                path.Add(new Vector3(1, 1));
                path.Add(new Vector3(1, 2));
                break;
            case 40:
                path.Add(new Vector3(2, 0));
                path.Add(new Vector3(2, 1));
                path.Add(new Vector3(1, 2));
                break;
            case 41:
                path.Add(new Vector3(2, 0));
                path.Add(new Vector3(2, 1));
                path.Add(new Vector3(2, 2));
                break;

            // 21
            case 42:
                path.Add(new Vector3(2, 1));
                path.Add(new Vector3(1, 2));
                path.Add(new Vector3(0, 3));
                break;
            case 43:
                path.Add(new Vector3(2, 1));
                path.Add(new Vector3(1, 2));
                path.Add(new Vector3(1, 3));
                break;
            case 44:
                path.Add(new Vector3(2, 1));
                path.Add(new Vector3(1, 2));
                path.Add(new Vector3(2, 3));
                break;
            case 45:
                path.Add(new Vector3(2, 1));
                path.Add(new Vector3(2, 2));
                path.Add(new Vector3(1, 3));
                break;
            case 46:
                path.Add(new Vector3(2, 1));
                path.Add(new Vector3(2, 2));
                path.Add(new Vector3(2, 3));
                break;
            // 22
            case 47:
                path.Add(new Vector3(2, 2));
                path.Add(new Vector3(1, 3));
                path.Add(new Vector3(0, 4));
                break;
            case 48:
                path.Add(new Vector3(2, 2));
                path.Add(new Vector3(1, 3));
                path.Add(new Vector3(1, 4));
                break;
            case 49:
                path.Add(new Vector3(2, 2));
                path.Add(new Vector3(1, 3));
                path.Add(new Vector3(2, 4));
                break;
            case 50:
                path.Add(new Vector3(2, 2));
                path.Add(new Vector3(2, 3));
                path.Add(new Vector3(1, 4));
                break;
            case 51:
                path.Add(new Vector3(2, 2));
                path.Add(new Vector3(2, 3));
                path.Add(new Vector3(2, 4));
                break;


        }
        payLineLength = path.Count;

    }

    public void RenderPayline()
    {
        Debug.Log("Animating Winning");
        lineRenderer.positionCount = payLineLength;
        for(int i = 0; i < payLineLength; i++)
        {
            lineRenderer.SetPosition(i, slotsAnchors.Anchors()[(int)path[i].x, (int)path[i].y].transform.position);
        }
    }


    public void FlagAsWinner()
    {
        winner = true;
    }

    public void ResetWinner()
    {
        winner = false;
    }

    public void ResetLineRenderer()
    {
        lineRenderer.positionCount = 0;
    }

    public void ResetPath()
    {
        path = new List<Vector2>();
    }

    public bool GetWinner()
    {
        return winner;
    }
}
