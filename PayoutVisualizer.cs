using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using DG.Tweening;

public class PayoutVisualizer : MonoBehaviour
{

    private PayoutCalculator payoutCalculator;
    [SerializeField]
    private GameObject[] wildSymbols;
    [SerializeField]
    private GameObject[] aceSymbols;
    [SerializeField]
    private GameObject[] kingSymbols;
    [SerializeField]
    private GameObject[] queenSymbols;
    [SerializeField]
    private GameObject[] jackSymbols;
    [SerializeField]
    private GameObject[] tenSymbols;
    private List<Tween> wildTweens;
    private List<Tween> aceTweens;
    private List<Tween> kingTweens;
    private List<Tween> queenTweens;
    private List<Tween> jackTweens;
    private List<Tween> tenTweens;


    private void Awake()
    {
        payoutCalculator = GameObject.FindGameObjectWithTag("Payout Calculator").GetComponent<PayoutCalculator>();
        ResetTweenLists();
    }

    public void ResetTweenLists()
    {
        wildTweens = new List<Tween>();
        aceTweens = new List<Tween>();
        kingTweens = new List<Tween>();
        queenTweens = new List<Tween>();
        jackTweens = new List<Tween>();
        tenTweens = new List<Tween>();
    }


    public void VisualizePayout()
    {
       List<string> payoutTally =  payoutCalculator.GetPayoutTally();

        Debug.Log("Visualizing Payout");
        for(int i = 0; i < payoutTally.Count; i++)
        {

            string payout = payoutTally[i];
            Debug.Log("Visualizing-> " + payout);

            int paylineSize = int.Parse(payout[0]+"");
            Debug.Log("Payline Size-> " + paylineSize);

            float tweenDuration = 1.5f;
            float delayDuration = .5f;
            StartCoroutine(TweenSymbols(payout, paylineSize, tweenDuration, delayDuration,i));

        }
    }

    public IEnumerator TweenSymbols(string payout, int paylineSize, float tweenDuration, float tweenDelay, int iteration)
    {
        yield return new WaitForSeconds(tweenDelay*(iteration+1));

        Regex wildsRegex = new Regex("[3-5] Wild");
        Regex aceRegex = new Regex("[3-5] Ace");
        Regex kingRegex = new Regex("[3-5] King");
        Regex queenRegex = new Regex("[3-5] Queen");
        Regex jackRegex = new Regex("[3-5] Jack");
        Regex tenRegex = new Regex("[3-5] Ten");

        Vector3 destination = new Vector3(0f, 5f - (.5f * (1 + iteration)), 0f);
        if (wildsRegex.IsMatch(payout))
        {
            for (int j = 0; j < paylineSize; j++)
            {
               wildTweens.Add(wildSymbols[j].transform.DOMove(wildSymbols[j].GetComponent<PayoutVisualizerSymbol>().GetStartPosition() + destination, tweenDuration));
            }
        }
        else if (aceRegex.IsMatch(payout))
        {
            for (int j = 0; j < paylineSize; j++)
            {
               aceTweens.Add(aceSymbols[j].transform.DOMove(aceSymbols[j].GetComponent<PayoutVisualizerSymbol>().GetStartPosition() + destination, tweenDuration));
            }
        }
        else if (kingRegex.IsMatch(payout))
        {
            for (int j = 0; j < paylineSize; j++)
            {
               kingTweens.Add(kingSymbols[j].transform.DOMove(kingSymbols[j].GetComponent<PayoutVisualizerSymbol>().GetStartPosition() + destination, tweenDuration));

            }
        }
        else if (queenRegex.IsMatch(payout))
        {
            for (int j = 0; j < paylineSize; j++)
            {
               queenTweens.Add(queenSymbols[j].transform.DOMove(queenSymbols[j].GetComponent<PayoutVisualizerSymbol>().GetStartPosition() + destination, tweenDuration));

            }
        }
        else if (jackRegex.IsMatch(payout))
        {
            for (int j = 0; j < paylineSize; j++)
            {
               jackTweens.Add(jackSymbols[j].transform.DOMove(jackSymbols[j].GetComponent<PayoutVisualizerSymbol>().GetStartPosition() + destination, tweenDuration));

            }
        }
        else if (tenRegex.IsMatch(payout))
        {
            for (int j = 0; j < paylineSize; j++)
            {
               tenTweens.Add(tenSymbols[j].transform.DOMove(tenSymbols[j].GetComponent<PayoutVisualizerSymbol>().GetStartPosition() + destination, tweenDuration));
            }
        }
    }

    public void ResetSymbols()
    {
        for (int i = 0; i < wildTweens.Count; i++)
        {
            wildTweens[i].Kill();
        }
        for (int i = 0; i < wildSymbols.Length; i++)
        {
            wildSymbols[i].transform.position = wildSymbols[i].GetComponent<PayoutVisualizerSymbol>().GetStartPosition();
        }

        for (int i = 0; i < aceTweens.Count; i++)
        {
            aceTweens[i].Kill();
        }
        for (int i = 0; i < aceSymbols.Length; i++)
        {
            aceSymbols[i].transform.position = aceSymbols[i].GetComponent<PayoutVisualizerSymbol>().GetStartPosition();
        }

        for (int i = 0; i < kingTweens.Count; i++)
        {
            kingTweens[i].Kill();
        }
        for (int i = 0; i < kingSymbols.Length; i++)
        {
            kingSymbols[i].transform.position = kingSymbols[i].GetComponent<PayoutVisualizerSymbol>().GetStartPosition();
        }

        for (int i = 0; i < queenTweens.Count; i++)
        {
            queenTweens[i].Kill();
        }
        for (int i = 0; i < queenSymbols.Length; i++)
        {
            queenSymbols[i].transform.position = queenSymbols[i].GetComponent<PayoutVisualizerSymbol>().GetStartPosition();
        }

        for (int i = 0; i < jackTweens.Count; i++)
        {
            jackTweens[i].Kill();
        }
        for (int i = 0; i < jackSymbols.Length; i++)
        {
            jackSymbols[i].transform.position = jackSymbols[i].GetComponent<PayoutVisualizerSymbol>().GetStartPosition();
        }

        for (int i = 0; i < tenTweens.Count; i++)
        {
            tenTweens[i].Kill();
        }
        for (int i = 0; i < tenSymbols.Length; i++)
        {
            tenSymbols[i].transform.position = tenSymbols[i].GetComponent<PayoutVisualizerSymbol>().GetStartPosition();
        }

        ResetTweenLists();

       }
}
