using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookController : MonoBehaviour {

	public delegate void EventHandler(string source, int param);
	public static event EventHandler OnTalkRequest;
	public static event EventHandler OnMoodChange;

	void Start() { }
	
	void Update () { }

	public void _requestTalk(string source)
	{
		Debug.Log(gameObject.name + ": Sending \"Talk\" event ...");
		OnTalkRequest(source, 0);
	}

	public void _getNeutral(string target)
	{
		Debug.Log(gameObject.name + ": Sending \"Mood\" event ...");
		OnMoodChange(target, 0);
	}

	public void _getHappy(string target)
	{
		Debug.Log(gameObject.name + ": Sending \"Mood\" event ...");
		OnMoodChange(target, 1);
	}

	public void _getHappier(string target)
	{
		Debug.Log(gameObject.name + ": Sending \"Mood\" event ...");
		OnMoodChange(target, 2);
	}

	public void _getSad(string target)
	{
		Debug.Log(gameObject.name + ": Sending \"Mood\" event ...");
		OnMoodChange(target, -1);
	}

	public void _getSadder(string target)
	{
		Debug.Log(gameObject.name + ": Sending \"Mood\" event ...");
		OnMoodChange(target, -2);
	}

}
