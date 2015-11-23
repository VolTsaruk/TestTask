using UnityEngine;
using System.Collections;
using System;

public class PonyAnimation : ObjectAnimationController
{
    static int MoveHash = Animator.StringToHash("RunStateTrigger");
    static int StopHash = Animator.StringToHash("StopStateTrigger");
    static int WinHash = Animator.StringToHash("WinStateTrigger");
    public Animator animator;
    public GameObject ponyDefaultPrefab;
    public void ResetAnimations()
    {
        int ChildCount = transform.childCount;
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
