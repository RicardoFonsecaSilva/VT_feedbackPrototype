using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkInterrupt : StateMachineBehaviour {

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (animator.GetBool("beingTalkedTo"))
		{
			Debug.Log("CROSSFADING");
			animator.CrossFade("Look At", 0.3f);
		}

	}
}
