using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkInterrupt : StateMachineBehaviour {

	public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
	{
		animator.SetBool("isDoneTalking", false);
	}
	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (animator.GetBool("beingTalkedTo"))
		{
			Debug.Log("Crossfading to \"Look At\"");
			animator.CrossFade("Look At", 0.3f);
		}
		if (animator.GetBool("isTalking"))
		{
			Debug.Log("Crossfading to \"Talk\"");
			animator.CrossFade("Talk", 0.3f);
		}
	}

}
