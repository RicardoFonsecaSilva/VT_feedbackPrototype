using BubbleSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoManager : MonoBehaviour {
    private string j = "Joao";
    private string m = "Maria";
    private string o = "Options";

    [SerializeField]
    private BubbleSystemManager bubbleSystemManager;
    [SerializeField]
    private avatarScriptManager avatarScriptHelper;

    private GameObject[] Buttons;
    public GameObject notification;

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
            bubbleSystemManager.Speak(m, Emotion.Default, 0.0f, new string[] { "Hello." }, t);
            avatarScriptHelper.talkFor(m, t - HALFSEC);
            yield return new WaitForSeconds(t);
        }

        t = 2.5f; t2 = 5f; t3 = 5.5f;
        {
            avatarScriptHelper.gazeFor(j, t+t2+t3, 1);
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(j, Emotion.Default, 0.0f, new string[] { "Good day." }, t);
            avatarScriptHelper.talkFor(j, t - HALFSEC);

            yield return new WaitForSeconds(t);

            t = t2;
            bubbleSystemManager.Speak(j, Emotion.Default, 0.0f, new string[] { "We wanted to inform you that a new checkpoint is out for the Introdução à Programação." }, t);
            avatarScriptHelper.talkFor(j, t - HALFSEC);

            avatarScriptHelper.gazeFor(m, 1f, 1);
            yield return new WaitForSeconds(t);
        
            t = t3;
            bubbleSystemManager.Speak(j, Emotion.Default, 0.0f, new string[] { "We see that your performance in this class has been very good lately." }, t);
            avatarScriptHelper.talkFor(j, t - HALFSEC);

            yield return new WaitForSeconds(t);
        }
        bubbleSystemManager.UpdateBackground(m, Emotion.Happiness, 0.2f, Reason.Grades);
        avatarScriptHelper.mood(m, (int)MoodState.HAPPY_LOW);

        t = 5.0f; 
        {
            avatarScriptHelper.gazeFor(m, t, 2);
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(m, Emotion.Happiness, 0.2f, new string[] { "You have a lot of completed assignments. Well done." }, t);
            avatarScriptHelper.talkFor(m, t - HALFSEC);

            avatarScriptHelper.gazeFor(j, 1f, 2);
            yield return new WaitForSeconds(t);
        }

        t = 8.0f;
        {
            avatarScriptHelper.gazeFor(j, t, 1);
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(j, Emotion.Default, 0.2f, new string[] { "To continue the rhythm, I would ask you to please mark this new checkpoint in your calendar." }, t);
            avatarScriptHelper.talkFor(j, t - HALFSEC);

            avatarScriptHelper.gazeFor(m, 1f, 1);
            yield return new WaitForSeconds(t);
        }

        bubbleSystemManager.UpdateOptions(new string[] { "Mark checkpoint.", "Don't mark checkpoint." });

        yield return new WaitForSeconds(5);
        bubbleSystemManager.HideBalloon(o);

        yield return new WaitForSeconds(3);
    }
    IEnumerator Script2()
    {
        t = 5.0f;
        {
            avatarScriptHelper.gazeFor(j, t, 1);
            yield return new WaitForSeconds(0.5f);
            avatarScriptHelper.express(m, (int)MoodState.HAPPY_LOW);
            bubbleSystemManager.Speak(j, Emotion.Default, 0.2f, new string[] { "I am glad that you decided to continue working hard for this class." }, t);
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
            bubbleSystemManager.Speak(j, Emotion.Default, 0.2f, new string[] { "We will talk further about this class next week." }, t);
            avatarScriptHelper.talkFor(j, t - HALFSEC);

            avatarScriptHelper.gazeFor(m, 1f, 1);
            yield return new WaitForSeconds(t);
        }

        t = 2.0f;
        bubbleSystemManager.Speak(m, Emotion.Happiness, 0.2f, new string[] { "Agreed." }, t);
        avatarScriptHelper.talkFor(m, t - HALFSEC);
        yield return new WaitForSeconds(t);

        avatarScriptHelper.mood(m, (int)MoodState.NEUTRAL);
        bubbleSystemManager.UpdateBackground(m, Emotion.Default, 0.2f, Reason.Grades);

        t = 5.0f;
        {
            avatarScriptHelper.gazeFor(m, t, 2);
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(m, Emotion.Default, 0.2f, new string[] { "Now, I would like to talk about the “Análise Infinitesimal” class." }, t);
            avatarScriptHelper.talkFor(m, t - HALFSEC);

            avatarScriptHelper.gazeFor(j, 1f, 2);
            yield return new WaitForSeconds(t);
        }

        t = 7.0f;
        {
            avatarScriptHelper.gazeFor(j, t, 1);
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(j, Emotion.Default, 0.2f, new string[] { "We should. I would remind you that your performance in this class has not been the best." }, t);
            avatarScriptHelper.talkFor(j, t - HALFSEC);

            avatarScriptHelper.gazeFor(m, 1f, 1);
            yield return new WaitForSeconds(t);
        }

        t = 5.0f;
        t2 = 4.0f;
        {
            avatarScriptHelper.gazeFor(m, t + t2, 2);
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(m, Emotion.Default, 0.2f, new string[] { "The grades for the last checkpoint are now available." }, t);
            avatarScriptHelper.talkFor(m, t - HALFSEC);

            avatarScriptHelper.gazeFor(j, 1f, 2);
            yield return new WaitForSeconds(t);

            t = t2;
            bubbleSystemManager.Speak(m, Emotion.Default, 0.2f, new string[] { "Would you like to see how you did?" }, t);
            avatarScriptHelper.talkFor(m, t - HALFSEC);

            yield return new WaitForSeconds(t);
        }

        bubbleSystemManager.UpdateOptions(new string[] { "Check grades.", "Maybe later." });

        yield return new WaitForSeconds(5);
        bubbleSystemManager.HideBalloon(o);

        yield return new WaitForSeconds(3);
    }
    IEnumerator Script4()
    {
        avatarScriptHelper.mood(m, (int)MoodState.SAD_LOW);
        avatarScriptHelper.mood(j, (int)MoodState.SAD_HIGH);
        bubbleSystemManager.UpdateBackground(m, Emotion.Sadness, 0.2f, Reason.Grades);
        bubbleSystemManager.UpdateBackground(j, Emotion.Sadness, 0.2f, Reason.None);

        t = 8.0f; talker = j; gazer = m;
        {
            avatarScriptHelper.gazeFor(talker, t, (talker == j ? 1 : 2));
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(talker, Emotion.Sadness, 0.2f, new string[] { "I see that your grade was lower than the one from the previous checkpoint." }, t);
            avatarScriptHelper.talkFor(talker, t - HALFSEC);
            avatarScriptHelper.gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);
        }


        t = 8.0f; talker = m; gazer = j;
        {
            avatarScriptHelper.gazeFor(talker, t, (talker == j ? 1 : 2));
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(talker, Emotion.Sadness, 0.2f, new string[] { "We know that you have been having difficulties with this class for the last few weeks." }, t);
            avatarScriptHelper.talkFor(talker, t - HALFSEC);
            avatarScriptHelper.gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);
        }

        t = 6.0f; talker = j; gazer = m;
        {
            avatarScriptHelper.gazeFor(talker, t, (talker == j ? 1 : 2));
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(talker, Emotion.Sadness, 0.2f, new string[] { "Your interest in this class is low, but the class is very important." }, t);
            avatarScriptHelper.talkFor(talker, t - HALFSEC);
            avatarScriptHelper.gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);
        }

        t = 5.0f; t2 = 5.0f; talker = m; gazer = j;
        {
            avatarScriptHelper.gazeFor(talker, t + t2, (talker == j ? 1 : 2));
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(talker, Emotion.Sadness, 0.2f, new string[] { "We feel our help might not be enough to help motivate you." }, t);
            avatarScriptHelper.talkFor(talker, t - HALFSEC);
            avatarScriptHelper.gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);

            t = t2;

            bubbleSystemManager.Speak(talker, Emotion.Sadness, 0.2f, new string[] { "I suggest that you, additionally, seek the advice of a human tutor." }, t);
            avatarScriptHelper.talkFor(talker, t - HALFSEC);
            avatarScriptHelper.gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);
        }

        avatarScriptHelper.mood(j, (int)MoodState.NEUTRAL);
        bubbleSystemManager.UpdateBackground(j, Emotion.Default, 0.2f, Reason.None);

        t = 5.0f; t2 = 7.0f; talker = j; gazer = m;
        {
            avatarScriptHelper.gazeFor(talker, t + t2, (talker == j ? 1 : 2));
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(talker, Emotion.Default, 0.0f, new string[] { "Yes, I agree. A human tutor might be able to further assist you." }, t);
            avatarScriptHelper.talkFor(talker, t - HALFSEC);
            avatarScriptHelper.gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);

            avatarScriptHelper.mood(m, (int)MoodState.NEUTRAL);
            bubbleSystemManager.UpdateBackground(m, Emotion.Default, 0.2f, Reason.Grades);

            t = t2;

            bubbleSystemManager.Speak(talker, Emotion.Default, 0.0f, new string[] { "We will talk again in a few days, to schedule further study periods for this class." }, t);
            avatarScriptHelper.talkFor(talker, t - HALFSEC);
            avatarScriptHelper.gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);
        }

        t = 7.0f; talker = m; gazer = j;
        {
            avatarScriptHelper.gazeFor(talker, t, (talker == j ? 1 : 2));
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(talker, Emotion.Default, 0.0f, new string[] { "Yes, those should help with mastering the material." }, t);
            avatarScriptHelper.talkFor(talker, t - HALFSEC);
            avatarScriptHelper.gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);
        }

        t = 4.0f; talker = j; gazer = m;
        {
            avatarScriptHelper.gazeFor(talker, t, (talker == j ? 1 : 2));
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(talker, Emotion.Default, 0.0f, new string[] { "We will see you next week then." }, t);
            avatarScriptHelper.talkFor(talker, t - HALFSEC);
            avatarScriptHelper.gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);
        }

        t = 4.0f; talker = m; gazer = j;
        {
            avatarScriptHelper.gazeFor(talker, t, (talker == j ? 1 : 2));
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(talker, Emotion.Default, 0.0f, new string[] { "Good luck on your studies." }, t);
            avatarScriptHelper.talkFor(talker, t - HALFSEC);
            avatarScriptHelper.gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);
        }

        avatarScriptHelper.express(m, (int)MoodState.HAPPY_LOW);

        yield return new WaitForSeconds(3);
    }
    IEnumerator fullScript()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(Script1());
        yield return new WaitForSeconds(35);
        yield return StartCoroutine(ShowNotification("Calendar not yet implemented."));
        StartCoroutine(Script2());
        yield return new WaitForSeconds(8);
        yield return StartCoroutine(ShowNotification("Análise Infinitesimal: Test 2 grades are out!"));
        StartCoroutine(Script3());
        yield return new WaitForSeconds(35);
        yield return StartCoroutine(ShowNotification("Moodle integration not yet implemented."));
        StartCoroutine(Script4());
        yield return new WaitForSeconds(65);
        foreach (GameObject button in Buttons)
            button.SetActive(true);
    }

    void Start(){
        if (Buttons == null)
            Buttons = GameObject.FindGameObjectsWithTag("button");

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            bubbleSystemManager.HideBalloon(o, 0.5f);
            //balloonManager.Clean(0.5f);
        }
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    StartCoroutine(Script1());
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    StartCoroutine(Script2());
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    StartCoroutine(Script3());
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha4))
        //{
        //    StartCoroutine(Script4());
        //}
    }

    IEnumerator ShowNotification(string text)
    {
        notification.GetComponentInChildren<Text>().text = text;
        notification.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        notification.SetActive(false);
    }

    public void _exitApp() {
        Application.Quit();
    }
    public void _startDemo()
    {
        foreach (GameObject button in Buttons)
            button.SetActive(false);

        StartCoroutine(fullScript());
    }
}
