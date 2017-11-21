using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookController : MonoBehaviour {

	public delegate void TalkRequest(string s);
	public static event TalkRequest OnTalkRequest;

	void Start() { }
	
	void Update () { }

	public void requestTalk(string avatar)
	{
		Debug.Log(gameObject.name + ": Sending \"Talk\" event ...");
		OnTalkRequest(avatar);
	}

}
