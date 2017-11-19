using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookController : MonoBehaviour {

	public delegate void TalkRequest();
	public static event TalkRequest OnTalkRequest;

	void Start() { }
	
	void Update () { }

	public void requestTalk(string dialog)
	{
		Debug.Log(gameObject.name + ": Sending event ...");
		OnTalkRequest();
	}

}
