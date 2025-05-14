using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanSymbols : StateMachineBehaviour
{
    private SymbolCleaner symbolCleaner;
    private WinningsAnimator winningsAnimator;
    private PayoutVisualizer payoutVisualizer;


    private void Awake()
    {
        symbolCleaner = GameObject.FindGameObjectWithTag("Symbol Cleaner").GetComponent<SymbolCleaner>();
        winningsAnimator = GameObject.FindGameObjectWithTag("Winnings Animator").GetComponent<WinningsAnimator>();
        payoutVisualizer = GameObject.FindGameObjectWithTag("Payout Visualizer").GetComponent<PayoutVisualizer>();

    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        symbolCleaner.CleanSymbols();
        winningsAnimator.ResetPaylines();
        payoutVisualizer.ResetSymbols();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
