using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateWinnings : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state

    private WinningsAnimator winningsAnimator;
    private PayoutVisualizer payoutVisualizer;

    private void Awake()
    {
        winningsAnimator = GameObject.FindGameObjectWithTag("Winnings Animator").GetComponent<WinningsAnimator>();
        payoutVisualizer = GameObject.FindGameObjectWithTag("Payout Visualizer").GetComponent<PayoutVisualizer>();
    }
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        winningsAnimator.RenderAllPaylines();
        winningsAnimator.AnimateWinningSymbols();
        payoutVisualizer.VisualizePayout();
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
