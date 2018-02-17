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
        balloonManager.Generate(m);
        avatarScriptHelper.talkFor(m, 1);

        // WE ALSO NEED TO WAIT FOR X SECONDS, CAUSE THIS SCRIPT KEEPS GOING
        yield return new WaitForSeconds(2);
        //

        t = 2.0f;
        balloonManager.text = "Good day.";
        balloonManager.timeToWait = t;
        balloonManager.Generate(j);
        avatarScriptHelper.talkFor(j, 1.5f);

        yield return new WaitForSeconds(3f);

        //TODO
        //M Look J

        t = 5.0f;
        balloonManager.text = "We wanted to inform you that a new checkpoint is out for the Introdução à Programação.";
        balloonManager.timeToWait = t;
        balloonManager.Generate(j);
        avatarScriptHelper.talkFor(j, 3.5f);

        yield return new WaitForSeconds(5.5f);

        t = 6.0f;
        balloonManager.text = "We see that your performance in this class has been very good lately.";
        balloonManager.timeToWait = t;
        balloonManager.Generate(j);
        avatarScriptHelper.talkFor(j, 4f);

        yield return new WaitForSeconds(6.5f);

        balloonManager.FemaleMoodChange(MoodState.HAPPY_LOW);

        t = 5.0f;
        balloonManager.text = "You have a lot of completed assignments. Well done.";
        balloonManager.timeToWait = t;
        balloonManager.Generate(m);
        avatarScriptHelper.talkFor(m, 3.5f);

        yield return new WaitForSeconds(5.5f);

        t = 8.0f;
        balloonManager.text = "To continue the rhythm, I would ask you to please mark this new checkpoint in your calendar.";
        balloonManager.timeToWait = t;
        balloonManager.Generate(j);
        avatarScriptHelper.talkFor(j, 5f);

        yield return new WaitForSeconds(6f);


        balloonManager.optionsText_1 = "Mark checkpoint.";
        balloonManager.optionsText_2 = "Don't mark checkpoint.";
        balloonManager.timeToWait = 5.0f;
        balloonManager.Generate("Options");

        //avatarScriptHelper.express(m, 8);

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
