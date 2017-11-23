using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkInterrupt : StateMachineBehaviour {

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (animator.GetBool("beingTalkedTo"))
		{
			Debug.Log("CROSSFADING");
			animator.CrossFade("m_gaze_left", 0.3f);
		}

	}
}
