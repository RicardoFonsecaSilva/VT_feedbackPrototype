using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomIdleIndex : StateMachineBehaviour
{
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {

        animator.SetInteger("IdleIndex", Random.Range(0, 5));

        if(animator.GetBool("blendActive"))
            animator.SetFloat("Blend", (float) Random.Range(0, 75)/100);
        else
            animator.SetFloat("Blend", 0.0f);
    }
}
