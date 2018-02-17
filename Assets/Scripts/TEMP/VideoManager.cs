using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoManager : MonoBehaviour {
	private string j = "Joao";
	private string m = "Maria";
	
	[SerializeField]
	private ButtonsController balloonManager;
	[SerializeField]
	private avatarScriptManager avatarScriptHelper;
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			float t = 2.0f;
			balloonManager.text = "Hello.";
			balloonManager.timeToWait = t;
			balloonManager.Generate(j);
			avatarScriptHelper.talkFor(j, 1);
			// WE ALSO NEED TO WAIT FOR X SECONDS, CAUSE THIS SCRIPT KEEPS GOING
			StartCoroutine(wait(t));
			//
			balloonManager.MaleMoodChange(MoodState.HAPPY_HIGH);
			balloonManager.FemaleMoodChange(MoodState.HAPPY_HIGH);
			balloonManager.optionsText_1 = "Hello.";
			balloonManager.optionsText_2 = "Hello.";
			balloonManager.Generate("Options");
			avatarScriptHelper.express(m, 8);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{

		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{

		}
		else if (Input.GetKeyDown(KeyCode.Alpha4))
		{

		}
		else if (Input.GetKeyDown(KeyCode.Alpha5))
		{

		}
		else if (Input.GetKeyDown(KeyCode.Alpha6))
		{

		}
		else if (Input.GetKeyDown(KeyCode.Alpha7))
		{

		}
	}

	IEnumerator wait(float t)
	{
		yield return new WaitForSeconds(t);
	}
}
