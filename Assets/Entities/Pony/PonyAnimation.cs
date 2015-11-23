using UnityEngine;
using System.Collections;
using System;

public class PonyAnimation : ObjectAnimationController
{
    int MoveHash = Animator.StringToHash("RunStateTrigger");
    int StopHash = Animator.StringToHash("StopStateTrigger");
    int WinHash = Animator.StringToHash("WinStateTrigger");
    public Animator animator;
    public void ResetAnimations()
    {
        animator.playbackTime = 0;
        animator.Rebind();
        
    }
    public override void Move()
    {
        animator.SetBool(MoveHash, true);
    }

    public override void Stop()
    {
        animator.SetTrigger(StopHash);
        animator.SetBool(MoveHash, false);
    }

    public override void Win()
    {
        animator.SetTrigger(WinHash);
        animator.SetBool(MoveHash, false);
    }
}
