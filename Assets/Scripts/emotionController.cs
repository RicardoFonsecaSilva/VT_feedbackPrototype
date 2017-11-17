using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class emotionController : MonoBehaviour {

	public Text emotionText;
	public GameObject avatar;
	private string emotion;
	private Animator anim;

	void Start ()
	{
		emotion = "No Emotion";
		anim = avatar.GetComponent<Animator>();
		//anim.Stop();
	}
	
	void Update ()
	{
		emotionText.text = emotion;
	}

	public void playAnimation(string s)
	{
		emotion = s;
		anim.Play(s, -1, 0f);
	}
}
