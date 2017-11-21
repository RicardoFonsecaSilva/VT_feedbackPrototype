using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomIdleIndex : StateMachineBehaviour
{

    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {

        animator.SetInteger("IdleIndex", Random.Range(0, 4));
        animator.SetFloat("Blend", (float) Random.Range(25, 60)/100);

    }
}
