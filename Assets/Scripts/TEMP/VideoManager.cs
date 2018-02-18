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

        t = 5.0f;
        balloonManager.text = "We see that your performance in this class has been very good lately.";
        balloonManager.timeToWait = t;
        balloonManager.Generate(j);
        avatarScriptHelper.talkFor(j, 4f);

        yield return new WaitForSeconds(5.5f);

        balloonManager.FemaleMoodChange(MoodState.HAPPY_LOW);
        avatarScriptHelper.mood(m, (int)MoodState.HAPPY_LOW);

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

        yield return new WaitForSeconds(5);
        balloonManager.Clean(0.0f);

        yield return new WaitForSeconds(3);
    }

    IEnumerator Script2()
    {
        avatarScriptHelper.express(m, (int)MoodState.HAPPY_LOW);
        float t = 5.0f;
        balloonManager.text = "I am glad that you decided to continue working hard for this class.";
        balloonManager.timeToWait = t;
        balloonManager.Generate(j);
        avatarScriptHelper.talkFor(j, 4f);
        yield return new WaitForSeconds(5.5f);
    }

    IEnumerator Script3()
    {
        //Define States
        //avatarScriptHelper.express(m, (int)MoodState.SURPRISE_HIGH);
        //avatarScriptHelper.express(j, (int)MoodState.SURPRISE_HIGH);

        float t = 3.0f;
        balloonManager.text = "We will talk further about this class next week.";
        balloonManager.timeToWait = t;
        balloonManager.Generate(j);
        avatarScriptHelper.talkFor(j, 1.5f);
        yield return new WaitForSeconds(4f);


        t = 2.0f;
        balloonManager.text = "Agreed.";
        balloonManager.timeToWait = t;
        balloonManager.Generate(m);
        avatarScriptHelper.talkFor(m, 1f);
        yield return new WaitForSeconds(3f);

        avatarScriptHelper.mood(m, (int)MoodState.NEUTRAL);

        t = 5.0f;
        balloonManager.text = "Now, I would like to talk about the “Análise Infinitesimal” class.";
        balloonManager.timeToWait = t;
        balloonManager.Generate(m);
        avatarScriptHelper.talkFor(m, 3.5f);
        yield return new WaitForSeconds(5.5f);

        t = 7.0f;
        balloonManager.text = "We should. I would remind you that your performance in this class has not been the best.";
        balloonManager.timeToWait = t;
        balloonManager.Generate(j);
        avatarScriptHelper.talkFor(j, 5f);
        yield return new WaitForSeconds(7.5f);

        t = 5.0f;
        balloonManager.text = "The grades for the last checkpoint are now available.";
        balloonManager.timeToWait = t;
        balloonManager.Generate(m);
        avatarScriptHelper.talkFor(m, 3.5f);
        yield return new WaitForSeconds(5.5f);

        t = 4.0f;
        balloonManager.text = "Would you like to see how you did?";
        balloonManager.timeToWait = t;
        balloonManager.Generate(m);
        avatarScriptHelper.talkFor(m, 3f);
        yield return new WaitForSeconds(4.5f);

        balloonManager.optionsText_1 = "Check grades.";
        balloonManager.optionsText_2 = "Maybe later.";
        balloonManager.timeToWait = 5.0f;
        balloonManager.Generate("Options");

        yield return new WaitForSeconds(5);
        balloonManager.Clean(0.0f);

        yield return new WaitForSeconds(3);
    }

    IEnumerator Script4()
    {
        avatarScriptHelper.mood(m, (int)MoodState.SAD_HIGH);
        avatarScriptHelper.mood(j, (int)MoodState.SAD_LOW);

        float t = 8.0f;
        balloonManager.text = "I see that your grade was lower than the one from the previous checkpoint.";
        balloonManager.timeToWait = t;
        balloonManager.Generate(j);
        avatarScriptHelper.talkFor(j, 6f);

        //Maria Look Joao

        yield return new WaitForSeconds(9f);



        t = 8.0f;
        balloonManager.text = "We know that you have been having difficulties with this class for the last few weeks.";
        balloonManager.timeToWait = t;
        balloonManager.Generate(m);
        avatarScriptHelper.talkFor(m, 6f);
        yield return new WaitForSeconds(9f);

        t = 6.0f;
        balloonManager.text = "Your interest in this class is low, but the class is very important.";
        balloonManager.timeToWait = t;
        balloonManager.Generate(j);
        avatarScriptHelper.talkFor(j, 4f);

        //Joao Look Maria

        yield return new WaitForSeconds(7f);

        t = 5.0f;
        balloonManager.text = "We feel our help might not be enough to help motivate you.";
        balloonManager.timeToWait = t;
        balloonManager.Generate(m);
        avatarScriptHelper.talkFor(m, 4f);
        yield return new WaitForSeconds(6f);

        t = 5.0f;
        balloonManager.text = "I suggest that you, additionally, seek the advice of a human tutor.";
        balloonManager.timeToWait = t;
        balloonManager.Generate(m);
        avatarScriptHelper.talkFor(m, 4f);
        yield return new WaitForSeconds(6f);

        avatarScriptHelper.mood(j, (int)MoodState.NEUTRAL);

        t = 5.0f;
        balloonManager.text = "Yes, I agree. A human tutor might be able to further assist you.";
        balloonManager.timeToWait = t;
        balloonManager.Generate(j);
        avatarScriptHelper.talkFor(j, 4f);
        yield return new WaitForSeconds(6f);

        avatarScriptHelper.mood(m, (int)MoodState.NEUTRAL);

        t = 7.0f;
        balloonManager.text = "We will talk again in a few days, to schedule further study periods for this class.";
        balloonManager.timeToWait = t;
        balloonManager.Generate(j);
        avatarScriptHelper.talkFor(j, 6f);

        yield return new WaitForSeconds(8f);

        t = 7.0f;
        balloonManager.text = "Yes, those should help with mastering the material.";
        balloonManager.timeToWait = t;
        balloonManager.Generate(m);
        avatarScriptHelper.talkFor(m, 6f);

        yield return new WaitForSeconds(8f);

        t = 4.0f;
        balloonManager.text = "We will see you next week then.";
        balloonManager.timeToWait = t;
        balloonManager.Generate(j);
        avatarScriptHelper.talkFor(j, 2.5f);

        yield return new WaitForSeconds(5f);

        t = 4.0f;
        balloonManager.text = "Good luck on your studies.";
        balloonManager.timeToWait = t;
        balloonManager.Generate(m);
        avatarScriptHelper.talkFor(m, 2.5f);

        yield return new WaitForSeconds(5f);

        avatarScriptHelper.express(m, (int)MoodState.HAPPY_LOW);

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
            StartCoroutine(Script2());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartCoroutine(Script3());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            StartCoroutine(Script4());
        }
	}

	IEnumerator wait(float t)
	{
		yield return new WaitForSeconds(t);
	}
}
