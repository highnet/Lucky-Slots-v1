using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayoutCalculator : MonoBehaviour
{
    private Player player;
    private GameStateManager gameStateManager;
    private ActiveGameSymbols activeGameSymbols;
    private PaylineSpawner paylineSpawner;
    private List<string> tally;
    private WinningsAnimator winningsAnimator;

    private void Awake()
    {
        gameStateManager = GameObject.FindGameObjectWithTag("Game State Manager").GetComponent<GameStateManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        activeGameSymbols = GameObject.FindGameObjectWithTag("Active Game Symbols").GetComponent<ActiveGameSymbols>();
        paylineSpawner = GameObject.FindGameObjectWithTag("Payline Spawner").GetComponent<PaylineSpawner>();
        winningsAnimator = GameObject.FindGameObjectWithTag("Winnings Animator").GetComponent<WinningsAnimator>();
        tally = new List<string>();
    }

    public void CalculatePayout()
    {
        Debug.Log("CALCULATING PAYOUT");
        GameObject[,] symbols = activeGameSymbols.GetActiveGameSymbols();


        List<GameObject> paylines = paylineSpawner.GetPayLines();
        bool hasWinner = false;

        for (int paylineID = 0; paylineID < paylineSpawner.PayLinesCount() ; paylineID++)
        {
            int matchedLength = 1;
            Payline payline = paylines[paylineID].GetComponent<Payline>();
            List<Vector2> path = payline.GetPath();
            int row = (int)path[0].x;
            int reel = (int)path[0].y;
            GameSymbol gameSymbol = symbols[row, reel].GetComponent<GameSymbol>();
            Symbol paylineSymbol = gameSymbol.GetSymbol();
            Debug.Log("Payline: " + row + ", " + reel + "->" + paylineSymbol);

            bool paylineCopyNextSymbol = false;
            if (paylineSymbol == Symbol.Bonus)
            {
                Debug.Log("Found bonus, skipping payline check");
                continue;
            } else if (paylineSymbol == Symbol.Wild)
            {
                paylineCopyNextSymbol = true;
            }
            for (int i = 1; i < path.Count; i++)
            {
                row = (int)path[i].x;
                reel = (int)path[i].y;
                GameSymbol nextGameSymbol = symbols[row, reel].GetComponent<GameSymbol>();
                Symbol nextPaylineSymbol = nextGameSymbol.GetSymbol();
                if (paylineCopyNextSymbol)
                {
                    if (nextPaylineSymbol != Symbol.Wild && nextPaylineSymbol != Symbol.Bonus)
                    {
                        paylineSymbol = nextPaylineSymbol;
                        paylineCopyNextSymbol = false;
                    }

                }
                Debug.Log("Payline: " + row + ", " + reel + "->" + nextPaylineSymbol);

                if ((paylineSymbol == nextPaylineSymbol) || (nextPaylineSymbol == Symbol.Wild) && (nextPaylineSymbol != Symbol.Bonus))
                {
                    Debug.Log("Match");
                    matchedLength++;
                }
                else
                {
                    Debug.Log("No Match");
                    break;
                }

                if (matchedLength == payline.GetPayLineLength())
                {
                    payline.FlagAsWinner();
                    if (!hasWinner)
                    {
                        hasWinner = true;
                    }
                    payline.SetWinningSymbol(paylineSymbol);
                }
            }
        }
        tally = new List<string>();
        CalculatePaylinesOf4And5();
        TallyPaylines();

        if (!hasWinner)
        {
            gameStateManager.SetTrigger("Calculated Payout(=0)");
        }
        else
        {
            gameStateManager.SetTrigger("Calculated Payout(>0)");
        }


    }

    public void TallyPaylines()
    {
        Debug.Log("Tallying Paylines");

        List<Payline> winningPaylines = new List<Payline>();

        for (int i = 0; i < paylineSpawner.GetPayLines().Count; i++)
        {
            if (paylineSpawner.GetPayLines()[i].GetComponent<Payline>().GetWinner())
            {
                winningPaylines.Add(paylineSpawner.GetPayLines()[i].GetComponent<Payline>());
            }
        }

        while (winningPaylines.Count > 0)
        {
            Payline payline = winningPaylines[0];
            winningPaylines.RemoveAt(0);
            if (!tally.Contains("4 " + payline.GetWinningSymbol().ToString()) &&
                !tally.Contains("5 " + payline.GetWinningSymbol().ToString()) &&
                !tally.Contains("3 " + payline.GetWinningSymbol().ToString())){
                tally.Add(3 + " " + payline.GetWinningSymbol().ToString());
                winningsAnimator.AddToWinningSymbolCoordinates(payline.GetPath());
                
            }
        }

        for (int i = 0; i < tally.Count; i++)
        {
            Debug.Log(tally[i]);
        }
    }


    public void CalculatePaylinesOf4And5()
    {
        Debug.Log("Merging Winning Payline Combinations");
        List<Payline> winningPaylines = new List<Payline>();

        for (int i = 0; i < paylineSpawner.GetPayLines().Count; i++)
        {
            if (paylineSpawner.GetPayLines()[i].GetComponent<Payline>().GetWinner())
            {
                winningPaylines.Add(paylineSpawner.GetPayLines()[i].GetComponent<Payline>());
            }
        }

        while (winningPaylines.Count > 0)
        {

            Payline payline = winningPaylines[0];
            winningPaylines.RemoveAt(0);
            List<Payline> clusteredPayLines = new List<Payline>();
            clusteredPayLines.Add(payline);
            for (int i = 0; i < winningPaylines.Count; i++)
            {
                Payline otherPayline = winningPaylines[i];
                if (payline.GetWinningSymbol() == otherPayline.GetWinningSymbol())
                {
                    Debug.Log(payline.GetPaylineID() + "(" + payline.GetWinningSymbol() + ")" + "-> " + winningPaylines[i].GetPaylineID() + "(" + winningPaylines[i].GetWinningSymbol() + ")");

                    int sharedVertices = 0;
                    for (int j = 0; j < 3; j++)
                    {
                        Vector2 vertex = payline.GetPath()[j];
                        for (int k = 0; k < 3; k++)
                        {
                            Vector2 otherVertex = otherPayline.GetPath()[k];
                            if (vertex == otherVertex)
                            {
                                sharedVertices++;
                            }
                        }
                    }
                    if (sharedVertices < 1)
                    {
                        Debug.Log("no shared vertices, skipping");
                        continue;
                    }
                    else
                    {
                        clusteredPayLines.Add(otherPayline);
                    }
                }
            }

            List<Vector2> specialPaylinePath = new List<Vector2>();
            Vector2 firstVertex = new Vector2(100, 100);

            for (int i = 0; i < clusteredPayLines.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Vector2 vertex = clusteredPayLines[i].GetPath()[j];
                    Debug.Log("Clustered Vertex-> " + vertex);

                    if (vertex.y < firstVertex.y)
                    {
                        firstVertex = vertex;
                    }
                }
            }
            Debug.Log("Lowest Y Vertex-> "+ firstVertex);

            bool traversalTerminated = false;
            Vector2 scanVertex = firstVertex;
            while (!traversalTerminated)
            {
                specialPaylinePath.Add(scanVertex);
                if (ListOfPaylinesContainsVertex(clusteredPayLines, scanVertex) && !specialPaylinePath.Contains(scanVertex))
                {
                    specialPaylinePath.Add(scanVertex);
                }
                Vector2 rightUp = new Vector2(scanVertex.x - 1, scanVertex.y + 1);
                Vector2 right = new Vector2(scanVertex.x, scanVertex.y + 1);
                Vector2 rightDown = new Vector2(scanVertex.x + 1, scanVertex.y + 1);

                if (ListOfPaylinesContainsVertex(clusteredPayLines, right))
                {
                    scanVertex = right;
                } else if (ListOfPaylinesContainsVertex(clusteredPayLines, rightUp))
                {
                    scanVertex = rightUp;
                } else if (ListOfPaylinesContainsVertex(clusteredPayLines, rightDown))
                {
                    scanVertex = rightDown;
                } else
                {
                    traversalTerminated = true;
                }
            }



            // add the traced path to special paylines
            if (specialPaylinePath.Count > 3)
            {
                for (int i = 0; i < specialPaylinePath.Count; i++)
                {
                    Debug.Log("Special Payline Path: " + specialPaylinePath[i].x + specialPaylinePath[i].y);
                }

                GameObject specialPaylineGO = paylineSpawner.FetchFromSpecialPaylinePool();
                Payline specialPayline = specialPaylineGO.GetComponent<Payline>();
                specialPayline.SetPath(specialPaylinePath);
                specialPayline.FlagAsWinner();
                paylineSpawner.AddToSpecialPaylines(specialPaylineGO);

                tally.Add(specialPaylinePath.Count.ToString() + " " + payline.GetWinningSymbol().ToString());
                winningsAnimator.AddToWinningSymbolCoordinates(specialPaylinePath);

                for (int i = 0; i < clusteredPayLines.Count; i++)
                {
                    winningPaylines.Remove(clusteredPayLines[i]);
                    clusteredPayLines[i].ResetWinner();
                }

            }
            else if (specialPaylinePath.Count == 3 && clusteredPayLines.Count > 1)
            {
                for (int i = 1; i < clusteredPayLines.Count; i++)
                {
                    winningPaylines.Remove(clusteredPayLines[i]);
                    clusteredPayLines[i].ResetWinner();
                }
            }
            Debug.Log("===========");
        }

    }

    private bool ListOfPaylinesContainsVertex(List<Payline> clusteredPayLines, Vector2 vertex)
    {
        for(int i = 0; i < clusteredPayLines.Count; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                  if (clusteredPayLines[i].GetPath()[j] == vertex)
                {
                    return true;
                }
            }
        }
        return false;
    }
}


