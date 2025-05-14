using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WinningsAnimator : MonoBehaviour
{

    private PaylineSpawner paylineSpawner;
    private GameStateManager gameStateManager;
    private List<Vector2> winningSymbolCoordinates;
    private ActiveGameSymbols activeGameSymbols;



    private void Awake()
    {
        paylineSpawner = GameObject.FindGameObjectWithTag("Payline Spawner").GetComponent<PaylineSpawner>();
        gameStateManager = GameObject.FindGameObjectWithTag("Game State Manager").GetComponent<GameStateManager>();
        activeGameSymbols = GameObject.FindGameObjectWithTag("Active Game Symbols").GetComponent<ActiveGameSymbols>();
        winningSymbolCoordinates = new List<Vector2>();
    }

    public void AnimateWinningSymbols()
    {


        StartCoroutine(TweenAnimateSymbols());

    }

    public IEnumerator TweenAnimateSymbols()
    {

        yield return new WaitForSeconds(.25f);

        Debug.Log("Animating Winning Symbols");
        for (int i = 0; i < winningSymbolCoordinates.Count; i++)
        {
            Debug.Log("Winning Symbol at ->" + winningSymbolCoordinates[i].x + ", " + winningSymbolCoordinates[i].y);

            GameObject gameSymbol = activeGameSymbols.GetActiveGameSymbols()[(int)winningSymbolCoordinates[i].x, (int)winningSymbolCoordinates[i].y];

            gameSymbol.transform.DOPunchScale(new Vector3(.5f, .5f , .5f), .5f ,0,1f);
            yield return new WaitForSeconds(.025f * (i + 1));
        }


        winningSymbolCoordinates = new List<Vector2>();
    }

    public void AddToWinningSymbolCoordinates(List<Vector2> coordinates)
    {
        for(int i = 0; i < coordinates.Count; i++)
        {
            if (!winningSymbolCoordinates.Contains(coordinates[i]))
            {
                winningSymbolCoordinates.Add(coordinates[i]);

            }
        }
    }

    public void RenderAllPaylines()
    {
        Debug.Log("Animating Winnings");
        List<GameObject> paylines = paylineSpawner.GetPayLines();

        for (int i = 0; i < paylines.Count; i++)
        {
            Payline payline = paylines[i].GetComponent<Payline>();
            if (payline.GetWinner())
            {
                payline.RenderPayline();
            }
        }

        List<GameObject> specialPaylines = paylineSpawner.GetSpecialPaylines();

        for (int i = 0; i < specialPaylines.Count; i++)
        {
            Payline specialPayline = specialPaylines[i].GetComponent<Payline>();
            if (specialPayline.GetWinner())
            {
                specialPayline.RenderPayline();
            }
        }

        gameStateManager.SetTrigger("Animated Winnings");
    }

    public void ResetPaylines()
    {
        Debug.Log("Resetting Paylines");

        List<GameObject> paylines = paylineSpawner.GetPayLines();

        for (int i = 0; i < paylines.Count; i++)
        {
            Payline payline = paylines[i].GetComponent<Payline>();
            payline.ResetWinner();
            payline.ResetLineRenderer();

        }

        List<GameObject> specialPaylines = paylineSpawner.GetSpecialPaylines();

        while(specialPaylines.Count > 0)
        {
            Payline specialPayline = specialPaylines[0].GetComponent<Payline>();
            specialPayline.ResetWinner();
            specialPayline.ResetLineRenderer();
            specialPayline.ResetPath();

            paylineSpawner.TakeBackToSpecialPaylinePool(specialPayline.gameObject);

        }

        for (int i = 0; i < specialPaylines.Count; i++)
        {
        }
    }
}
