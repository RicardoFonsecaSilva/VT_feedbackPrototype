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

    bool cleanOptions = false;
	
    IEnumerator Script1()
    {
        float t = 2.0f;
        balloonManager.text = "Hello.";
        balloonManager.timeToWait = t;
        balloonManager.Generate(j);
        avatarScriptHelper.talkFor(j, 1);

        // WE ALSO NEED TO WAIT FOR X SECONDS, CAUSE THIS SCRIPT KEEPS GOING
        yield return new WaitForSeconds(t+1);
        //

        balloonManager.MaleMoodChange(MoodState.HAPPY_HIGH);
        balloonManager.FemaleMoodChange(MoodState.HAPPY_HIGH);
        balloonManager.optionsText_1 = "Hello.";
        balloonManager.optionsText_2 = "Hello.";
        balloonManager.timeToWait = 5.0f;
        balloonManager.Generate("Options");
        avatarScriptHelper.express(m, 8);

        yield return new WaitForSeconds(5);
        balloonManager.Clean(0.0f);

        yield return new WaitForSeconds(3);
    }

	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            balloonManager.Clean(0.5f);
        }
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
            StartCoroutine(Script1());
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
