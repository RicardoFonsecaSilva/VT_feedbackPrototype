using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookController : MonoBehaviour {

	public delegate void EventHandler(string source, int param);
	public static event EventHandler OnTalkRequest;
	public static event EventHandler OnMoodChange;
	public static event EventHandler OnExpressionRequest;
	public static event EventHandler OnBlendToggle;

	//EVENT LIST
	public void _toggleBlend(string source)
	{
		OnBlendToggle(source, 0);
	}

	public void _requestTalk(string source)
	{
		//Debug.Log(gameObject.name + ": Sending \"Talk\" event ...");
		OnTalkRequest(source, 0);
	}

	public void _getNeutral(string target)
	{
		//Debug.Log(gameObject.name + ": Sending \"Mood\" event ...");
		OnMoodChange(target, 0);
	}
	public void _getHappy(string target)
	{
		//Debug.Log(gameObject.name + ": Sending \"Mood\" event ...");
		OnMoodChange(target, 1);
	}
	public void _getHappier(string target)
	{
		//Debug.Log(gameObject.name + ": Sending \"Mood\" event ...");
		OnMoodChange(target, 2);
	}
	public void _getSad(string target)
	{
		//Debug.Log(gameObject.name + ": Sending \"Mood\" event ...");
		OnMoodChange(target, -1);
	}
	public void _getSadder(string target)
	{
		//Debug.Log(gameObject.name + ": Sending \"Mood\" event ...");
		OnMoodChange(target, -2);
	}

	public void _expressFearL(string target)
	{
		//Debug.Log(gameObject.name + ": Sending \"Expression\" event ...");
		OnExpressionRequest(target, 1);
	}
	public void _expressFearH(string target)
	{
		//Debug.Log(gameObject.name + ": Sending \"Expression\" event ...");
		OnExpressionRequest(target, 2);
	}
	public void _expressRageL(string target)
	{
		//Debug.Log(gameObject.name + ": Sending \"Expression\" event ...");
		OnExpressionRequest(target, 3);
	}
	public void _expressRageH(string target)
	{
		////Debug.Log(gameObject.name + ": Sending \"Expression\" event ...");
		OnExpressionRequest(target, 4);
	}
	public void _expressDisgustL(string target)
	{
		//Debug.Log(gameObject.name + ": Sending \"Expression\" event ...");
		OnExpressionRequest(target, 5);
	}
	public void _expressDisgustH(string target)
	{
		//Debug.Log(gameObject.name + ": Sending \"Expression\" event ...");
		OnExpressionRequest(target, 6);
	}
	public void _expressSurpriseL(string target)
	{
		//Debug.Log(gameObject.name + ": Sending \"Expression\" event ...");
		OnExpressionRequest(target, 7);
	}
	public void _expressSurpriseH(string target)
	{
		//Debug.Log(gameObject.name + ": Sending \"Expression\" event ...");
		OnExpressionRequest(target, 8);
	}
	public void _expressSadnessL(string target)
	{
		//Debug.Log(gameObject.name + ": Sending \"Expression\" event ...");
		OnExpressionRequest(target, 9);
	}
	public void _expressSadnessH(string target)
	{
		//Debug.Log(gameObject.name + ": Sending \"Expression\" event ...");
		OnExpressionRequest(target, 10);
	}
	public void _expressHappinessL(string target)
	{
		//Debug.Log(gameObject.name + ": Sending \"Expression\" event ...");
		OnExpressionRequest(target, 11);
	}
	public void _expressHappinessH(string target)
	{
		//Debug.Log(gameObject.name + ": Sending \"Expression\" event ...");
		OnExpressionRequest(target, 12);
	}
}