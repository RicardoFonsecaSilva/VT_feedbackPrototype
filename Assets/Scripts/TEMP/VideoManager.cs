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
    float HALFSEC = 0.5f;
    float t,t2,t3;
    string talker, gazer;

    IEnumerator Script1()
    {

        t = 1.5f;
        {
            avatarScriptHelper.gazeFor(m, t + 1f, 2);
            yield return new WaitForSeconds(HALFSEC);
            balloonManager.text = "Hello.";
            balloonManager.timeToWait = t;
            balloonManager.Generate(m);
            avatarScriptHelper.talkFor(m, t - HALFSEC);
            yield return new WaitForSeconds(t);
        }

        t = 2.5f; t2 = 5f; t3 = 5.5f;
        {
            avatarScriptHelper.gazeFor(j, t+t2+t3, 1);
            yield return new WaitForSeconds(HALFSEC);
            balloonManager.text = "Good day.";
            balloonManager.timeToWait = t;
            balloonManager.Generate(j);
            avatarScriptHelper.talkFor(j, t - HALFSEC);

            yield return new WaitForSeconds(t);

            t = t2;
            balloonManager.text = "We wanted to inform you that a new checkpoint is out for the Introdução à Programação.";
            balloonManager.timeToWait = t;
            balloonManager.Generate(j);
            avatarScriptHelper.talkFor(j, t - HALFSEC);

            avatarScriptHelper.gazeFor(m, 1f, 1);
            yield return new WaitForSeconds(t);
        
            t = t3;
            balloonManager.text = "We see that your performance in this class has been very good lately.";
            balloonManager.timeToWait = t;
            balloonManager.Generate(j);
            avatarScriptHelper.talkFor(j, t - HALFSEC);

            yield return new WaitForSeconds(t);
        }
        balloonManager.FemaleMoodChange(MoodState.HAPPY_LOW);
        avatarScriptHelper.mood(m, (int)MoodState.HAPPY_LOW);

        t = 5.0f; 
        {
            avatarScriptHelper.gazeFor(m, t, 2);
            yield return new WaitForSeconds(HALFSEC);
            balloonManager.text = "You have a lot of completed assignments. Well done.";
            balloonManager.timeToWait = t;
            balloonManager.Generate(m);
            avatarScriptHelper.talkFor(m, t - HALFSEC);

            avatarScriptHelper.gazeFor(j, 1f, 2);
            yield return new WaitForSeconds(t);
        }

        t = 8.0f;
        {
            avatarScriptHelper.gazeFor(j, t, 1);
            yield return new WaitForSeconds(HALFSEC);
            balloonManager.text = "To continue the rhythm, I would ask you to please mark this new checkpoint in your calendar.";
            balloonManager.timeToWait = t;
            balloonManager.Generate(j);
            avatarScriptHelper.talkFor(j, t - HALFSEC);

            avatarScriptHelper.gazeFor(m, 1f, 1);
            yield return new WaitForSeconds(t);
        }

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
        t = 5.0f;
        {
            avatarScriptHelper.gazeFor(j, t, 1);
            yield return new WaitForSeconds(0.5f);
            avatarScriptHelper.express(m, (int)MoodState.HAPPY_LOW);
            balloonManager.text = "I am glad that you decided to continue working hard for this class.";
            balloonManager.timeToWait = t;
            balloonManager.Generate(j);
            avatarScriptHelper.talkFor(j, t - HALFSEC);

            avatarScriptHelper.gazeFor(m, 1f, 1);
            yield return new WaitForSeconds(t);
        }
    }
    IEnumerator Script3()
    {
        avatarScriptHelper.express(m, (int)ExpressionState.SURPRISE_HIGH);
        avatarScriptHelper.express(j, (int)ExpressionState.SURPRISE_HIGH);
        yield return new WaitForSeconds(1f);

        t = 3.0f;
        {
            avatarScriptHelper.gazeFor(j, t, 1);
            yield return new WaitForSeconds(HALFSEC);
            balloonManager.text = "We will talk further about this class next week.";
            balloonManager.timeToWait = t;
            balloonManager.Generate(j);
            avatarScriptHelper.talkFor(j, t - HALFSEC);

            avatarScriptHelper.gazeFor(m, 1f, 1);
            yield return new WaitForSeconds(t);
        }

        t = 2.0f;
        balloonManager.text = "Agreed.";
        balloonManager.timeToWait = t;
        balloonManager.Generate(m);
        avatarScriptHelper.talkFor(m, t - HALFSEC);
        yield return new WaitForSeconds(t);

        avatarScriptHelper.mood(m, (int)MoodState.NEUTRAL);

        t = 5.0f;
        {
            avatarScriptHelper.gazeFor(m, t, 2);
            yield return new WaitForSeconds(HALFSEC);
            balloonManager.text = "Now, I would like to talk about the “Análise Infinitesimal” class.";
            balloonManager.timeToWait = t;
            balloonManager.Generate(m);
            avatarScriptHelper.talkFor(m, t - HALFSEC);

            avatarScriptHelper.gazeFor(j, 1f, 2);
            yield return new WaitForSeconds(t);
        }

        t = 7.0f;
        {
            avatarScriptHelper.gazeFor(j, t, 1);
            yield return new WaitForSeconds(HALFSEC);
            balloonManager.text = "We should. I would remind you that your performance in this class has not been the best.";
            balloonManager.timeToWait = t;
            balloonManager.Generate(j);
            avatarScriptHelper.talkFor(j, t - HALFSEC);

            avatarScriptHelper.gazeFor(m, 1f, 1);
            yield return new WaitForSeconds(t);
        }

        t = 5.0f;
        t2 = 4.0f;
        {
            avatarScriptHelper.gazeFor(m, t+t2, 2);
            yield return new WaitForSeconds(HALFSEC); 
            balloonManager.text = "The grades for the last checkpoint are now available.";
            balloonManager.timeToWait = t;
            balloonManager.Generate(m);
            avatarScriptHelper.talkFor(m, t - HALFSEC);

            avatarScriptHelper.gazeFor(j, 1f, 2);
            yield return new WaitForSeconds(t);

            t = t2; 
            balloonManager.text = "Would you like to see how you did?";
            balloonManager.timeToWait = t;
            balloonManager.Generate(m);
            avatarScriptHelper.talkFor(m, t - HALFSEC);

            yield return new WaitForSeconds(t);
        }

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
        avatarScriptHelper.mood(m, (int)MoodState.SAD_LOW);
        avatarScriptHelper.mood(j, (int)MoodState.SAD_HIGH);

        t = 8.0f; talker = j; gazer = m;
        {
            avatarScriptHelper.gazeFor(talker, t, (talker == j ? 1 : 2));
            yield return new WaitForSeconds(HALFSEC);
            balloonManager.text = "I see that your grade was lower than the one from the previous checkpoint.";
            balloonManager.timeToWait = t;
            balloonManager.Generate(talker);
            avatarScriptHelper.talkFor(talker, t - HALFSEC);
            avatarScriptHelper.gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);
        }


        t = 8.0f; talker = m; gazer = j;
        {
            avatarScriptHelper.gazeFor(talker, t, (talker == j ? 1 : 2));
            yield return new WaitForSeconds(HALFSEC);
            balloonManager.text = "We know that you have been having difficulties with this class for the last few weeks.";
            balloonManager.timeToWait = t;
            balloonManager.Generate(talker);
            avatarScriptHelper.talkFor(talker, t - HALFSEC);
            avatarScriptHelper.gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);
        }

        t = 6.0f; talker = j; gazer = m;
        {
            avatarScriptHelper.gazeFor(talker, t, (talker == j ? 1 : 2));
            yield return new WaitForSeconds(HALFSEC);
            balloonManager.text = "Your interest in this class is low, but the class is very important.";
            balloonManager.timeToWait = t;
            balloonManager.Generate(talker);
            avatarScriptHelper.talkFor(talker, t - HALFSEC);
            avatarScriptHelper.gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);
        }

        t = 5.0f; t2 = 5.0f;  talker = m; gazer = j;
        {
            avatarScriptHelper.gazeFor(talker, t+t2, (talker == j ? 1 : 2));
            yield return new WaitForSeconds(HALFSEC);
            balloonManager.text = "We feel our help might not be enough to help motivate you.";
            balloonManager.timeToWait = t;
            balloonManager.Generate(talker);
            avatarScriptHelper.talkFor(talker, t - HALFSEC);
            avatarScriptHelper.gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);

            t = t2;

            balloonManager.text = "I suggest that you, additionally, seek the advice of a human tutor.";
            balloonManager.timeToWait = t;
            balloonManager.Generate(talker);
            avatarScriptHelper.talkFor(talker, t - HALFSEC);
            //avatarScriptHelper.gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);
        }

        avatarScriptHelper.mood(j, (int)MoodState.NEUTRAL);

        t = 5.0f; t2 = 7.0f; talker = j; gazer = m;
        {
            avatarScriptHelper.gazeFor(talker, t + t2, (talker == j ? 1 : 2));
            yield return new WaitForSeconds(HALFSEC);
            balloonManager.text = "Yes, I agree. A human tutor might be able to further assist you.";
             balloonManager.timeToWait = t;
            balloonManager.Generate(talker);
            avatarScriptHelper.talkFor(talker, t - HALFSEC);
            avatarScriptHelper.gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);

            avatarScriptHelper.mood(m, (int)MoodState.NEUTRAL);

            t = t2;

            balloonManager.text = "We will talk again in a few days, to schedule further study periods for this class.";
            balloonManager.timeToWait = t;
            balloonManager.Generate(talker);
            avatarScriptHelper.talkFor(talker, t - HALFSEC);
            //avatarScriptHelper.gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);
        }

        t = 7.0f; talker = m; gazer = j;
        {
            avatarScriptHelper.gazeFor(talker, t, (talker == j ? 1 : 2));
            yield return new WaitForSeconds(HALFSEC);
            balloonManager.text = "Yes, those should help with mastering the material.";
            balloonManager.timeToWait = t;
            balloonManager.Generate(talker);
            avatarScriptHelper.talkFor(talker, t - HALFSEC);
            avatarScriptHelper.gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);
        }

        t = 4.0f; talker = j; gazer = m;
        {
            avatarScriptHelper.gazeFor(talker, t, (talker == j ? 1 : 2));
            yield return new WaitForSeconds(HALFSEC);
            balloonManager.text = "We will see you next week then.";
            balloonManager.timeToWait = t;
            balloonManager.Generate(talker);
            avatarScriptHelper.talkFor(talker, t - HALFSEC);
            //avatarScriptHelper.gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);
        }

        t = 4.0f; talker = m; gazer = j;
        {
            avatarScriptHelper.gazeFor(talker, t, (talker == j ? 1 : 2));
            yield return new WaitForSeconds(HALFSEC);
            balloonManager.text = "Good luck on your studies.";
            balloonManager.timeToWait = t;
            balloonManager.Generate(talker);
            avatarScriptHelper.talkFor(talker, t - HALFSEC);
            //avatarScriptHelper.gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);
        }

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
