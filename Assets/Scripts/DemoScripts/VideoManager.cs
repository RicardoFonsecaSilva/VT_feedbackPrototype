using BubbleSystem;
using DeadMosquito.AndroidGoodies;
using System;
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
    private AvatarManager manager;

    private GameObject[] Buttons;
    public GameObject notification;

    bool cleanOptions = false;
    float HALFSEC = 0.5f;
    float t,t2,t3;
    string talker, gazer;

    void Start()
    {
        if (Buttons == null)
            Buttons = GameObject.FindGameObjectsWithTag("button");

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }
    void Update()
    {
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

    IEnumerator Script1()
    {

        t = 1.5f;
        {
            gazeFor(m, t + 1f, 2);
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(m, EmotionEnum.Neutral.ToString(), 0.0f, new string[] { "Hello." }, t);
            talkFor(m, t - HALFSEC);
            yield return new WaitForSeconds(t);
        }

        t = 2.5f; t2 = 5f; t3 = 5.5f;
        {
            gazeFor(j, t+t2+t3, 1);
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(j, EmotionEnum.Neutral.ToString(), 0.0f, new string[] { "Good day." }, t);
            talkFor(j, t - HALFSEC);

            yield return new WaitForSeconds(t);

            t = t2;
            bubbleSystemManager.Speak(j, EmotionEnum.Neutral.ToString(), 0.0f, new string[] { "We wanted to inform you that a new checkpoint is out for the Introdução à Programação." }, t);
            talkFor(j, t - HALFSEC);

            gazeFor(m, 1f, 1);
            yield return new WaitForSeconds(t);
        
            t = t3;
            bubbleSystemManager.Speak(j, EmotionEnum.Neutral.ToString(), 0.0f, new string[] { "We see that your performance in this class has been very good lately." }, t);
            talkFor(j, t - HALFSEC);

            yield return new WaitForSeconds(t);
        }
        bubbleSystemManager.UpdateBackground(m, EmotionEnum.Happiness.ToString(), 0.2f, Reason.Grades);
        mood(m, new Emotion(EmotionEnum.Happiness, 0.2f));

        t = 5.0f; 
        {
            gazeFor(m, t, 2);
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(m, EmotionEnum.Happiness.ToString(), 0.2f, new string[] { "You have a lot of completed assignments. Well done." }, t);
            talkFor(m, t - HALFSEC);

            gazeFor(j, 1f, 2);
            yield return new WaitForSeconds(t);
        }

        t = 8.0f;
        {
            gazeFor(j, t, 1);
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(j, EmotionEnum.Neutral.ToString(), 0.2f, new string[] { "To continue the rhythm, I would ask you to please mark this new checkpoint in your calendar." }, t);
            talkFor(j, t - HALFSEC);

            gazeFor(m, 1f, 1);
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
            gazeFor(j, t, 1);
            yield return new WaitForSeconds(0.5f);
            express(m, new Expression("Happy", "Low"));
            bubbleSystemManager.Speak(j, EmotionEnum.Neutral.ToString(), 0.2f, new string[] { "I am glad that you decided to continue working hard for this class." }, t);
            talkFor(j, t - HALFSEC);

            gazeFor(m, 1f, 1);
            yield return new WaitForSeconds(t);
        }
    }
    IEnumerator Script3()
    {
        express(m, new Expression("Surprise", "High"));
        express(j, new Expression("Surprise", "High"));
        yield return new WaitForSeconds(1f);

        t = 3.0f;
        {
            gazeFor(j, t, 1);
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(j, EmotionEnum.Neutral.ToString(), 0.2f, new string[] { "We will talk further about this class next week." }, t);
            talkFor(j, t - HALFSEC);

            gazeFor(m, 1f, 1);
            yield return new WaitForSeconds(t);
        }

        t = 2.0f;
        bubbleSystemManager.Speak(m, EmotionEnum.Happiness.ToString(), 0.2f, new string[] { "Agreed." }, t);
        talkFor(m, t - HALFSEC);
        yield return new WaitForSeconds(t);

        mood(m, new Emotion(EmotionEnum.Neutral, -1.0f));
        bubbleSystemManager.UpdateBackground(m, EmotionEnum.Neutral.ToString(), 0.2f, Reason.Grades);

        t = 5.0f;
        {
            gazeFor(m, t, 2);
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(m, EmotionEnum.Neutral.ToString(), 0.2f, new string[] { "Now, I would like to talk about the “Análise Infinitesimal” class." }, t);
            talkFor(m, t - HALFSEC);

            gazeFor(j, 1f, 2);
            yield return new WaitForSeconds(t);
        }

        t = 7.0f;
        {
            gazeFor(j, t, 1);
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(j, EmotionEnum.Neutral.ToString(), 0.2f, new string[] { "We should. I would remind you that your performance in this class has not been the best." }, t);
            talkFor(j, t - HALFSEC);

            gazeFor(m, 1f, 1);
            yield return new WaitForSeconds(t);
        }

        t = 5.0f;
        t2 = 4.0f;
        {
            gazeFor(m, t + t2, 2);
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(m, EmotionEnum.Neutral.ToString(), 0.2f, new string[] { "The grades for the last checkpoint are now available." }, t);
            talkFor(m, t - HALFSEC);

            gazeFor(j, 1f, 2);
            yield return new WaitForSeconds(t);

            t = t2;
            bubbleSystemManager.Speak(m, EmotionEnum.Neutral.ToString(), 0.2f, new string[] { "Would you like to see how you did?" }, t);
            talkFor(m, t - HALFSEC);

            yield return new WaitForSeconds(t);
        }

        bubbleSystemManager.UpdateOptions(new string[] { "Check grades.", "Maybe later." });

        yield return new WaitForSeconds(5);
        bubbleSystemManager.HideBalloon(o);

        yield return new WaitForSeconds(3);
    }
    IEnumerator Script4()
    {
        mood(m, new Emotion(EmotionEnum.Sadness, 0.2f));
        mood(j, new Emotion(EmotionEnum.Sadness, 0.8f));
        bubbleSystemManager.UpdateBackground(m, EmotionEnum.Sadness.ToString(), 0.2f, Reason.Grades);
        bubbleSystemManager.UpdateBackground(j, EmotionEnum.Sadness.ToString(), 0.2f, Reason.None);

        t = 8.0f; talker = j; gazer = m;
        {
            gazeFor(talker, t, (talker == j ? 1 : 2));
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(talker, EmotionEnum.Sadness.ToString(), 0.2f, new string[] { "I see that your grade was lower than the one from the previous checkpoint." }, t);
            talkFor(talker, t - HALFSEC);
            gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);
        }


        t = 8.0f; talker = m; gazer = j;
        {
            gazeFor(talker, t, (talker == j ? 1 : 2));
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(talker, EmotionEnum.Sadness.ToString(), 0.2f, new string[] { "We know that you have been having difficulties with this class for the last few weeks." }, t);
            talkFor(talker, t - HALFSEC);
            gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);
        }

        t = 6.0f; talker = j; gazer = m;
        {
            gazeFor(talker, t, (talker == j ? 1 : 2));
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(talker, EmotionEnum.Sadness.ToString(), 0.2f, new string[] { "Your interest in this class is low, but the class is very important." }, t);
            talkFor(talker, t - HALFSEC);
            gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);
        }

        t = 5.0f; t2 = 5.0f; talker = m; gazer = j;
        {
            gazeFor(talker, t + t2, (talker == j ? 1 : 2));
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(talker, EmotionEnum.Sadness.ToString(), 0.2f, new string[] { "We feel our help might not be enough to help motivate you." }, t);
            talkFor(talker, t - HALFSEC);
            gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);

            t = t2;

            bubbleSystemManager.Speak(talker, EmotionEnum.Sadness.ToString(), 0.2f, new string[] { "I suggest that you, additionally, seek the advice of a human tutor." }, t);
            talkFor(talker, t - HALFSEC);
            gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);
        }

        mood(j, new Emotion(EmotionEnum.Neutral, -1.0f));
        bubbleSystemManager.UpdateBackground(j, EmotionEnum.Neutral.ToString(), 0.2f, Reason.None);

        t = 5.0f; t2 = 7.0f; talker = j; gazer = m;
        {
            gazeFor(talker, t + t2, (talker == j ? 1 : 2));
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(talker, EmotionEnum.Neutral.ToString(), 0.0f, new string[] { "Yes, I agree. A human tutor might be able to further assist you." }, t);
            talkFor(talker, t - HALFSEC);
            gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);

            mood(m, new Emotion(EmotionEnum.Neutral, -1.0f));
            bubbleSystemManager.UpdateBackground(m, EmotionEnum.Neutral.ToString(), 0.2f, Reason.Grades);

            t = t2;

            bubbleSystemManager.Speak(talker, EmotionEnum.Neutral.ToString(), 0.0f, new string[] { "We will talk again in a few days, to schedule further study periods for this class." }, t);
            talkFor(talker, t - HALFSEC);
            gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);
        }

        t = 7.0f; talker = m; gazer = j;
        {
            gazeFor(talker, t, (talker == j ? 1 : 2));
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(talker, EmotionEnum.Neutral.ToString(), 0.0f, new string[] { "Yes, those should help with mastering the material." }, t);
            talkFor(talker, t - HALFSEC);
            gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);
        }

        t = 4.0f; talker = j; gazer = m;
        {
            gazeFor(talker, t, (talker == j ? 1 : 2));
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(talker, EmotionEnum.Neutral.ToString(), 0.0f, new string[] { "We will see you next week then." }, t);
            talkFor(talker, t - HALFSEC);
            gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);
        }

        t = 4.0f; talker = m; gazer = j;
        {
            gazeFor(talker, t, (talker == j ? 1 : 2));
            yield return new WaitForSeconds(HALFSEC);
            bubbleSystemManager.Speak(talker, EmotionEnum.Neutral.ToString(), 0.0f, new string[] { "Good luck on your studies." }, t);
            talkFor(talker, t - HALFSEC);
            gazeFor(gazer, 1f, (gazer == j ? 2 : 1));
            yield return new WaitForSeconds(t);
        }

        express(m, new Expression("Happy", "Low"));

        yield return new WaitForSeconds(3);
    }
    IEnumerator fullScript()
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(Script1());
        yield return new WaitForSeconds(35);
        //yield return StartCoroutine(ShowNotification("Calendar not yet implemented."));
        OpenCalendar();
        StartCoroutine(Script2());
        yield return new WaitForSeconds(8);
        //yield return StartCoroutine(ShowNotification("Análise Infinitesimal: Test 2 grades are out!"));
        CheckpointAlert();
        yield return new WaitForSeconds(4);
        StartCoroutine(Script3());
        yield return new WaitForSeconds(35);
        yield return StartCoroutine(ShowNotification("Moodle integration not yet implemented."));
        StartCoroutine(Script4());
        yield return new WaitForSeconds(65);
        foreach (GameObject button in Buttons)
            button.SetActive(true);
    }

    //AVATAR SCRIPT HELPER
    private enum GAZE_DIR
    {
        LEFT = 1,
        RIGHT = 2
    }

    public void express(string who, Expression expression)
    {
        manager.Express(new Tutor(who), expression);
    }
    public void mood(string who, Emotion emotion)
    {
        manager.Feel(new Tutor(who), emotion);
    }
    public void talkFor(string who, float sec)
    {
        StartCoroutine(avatarTalkFor(new Tutor(who), sec));
    }
    IEnumerator avatarTalkFor(Tutor tutor, float wait)
    {
        manager.Act(tutor, new HeadAction("Talk", ""));
        yield return new WaitForSeconds(wait);
        manager.Act(tutor, new HeadAction("Talk", "End"));
    }
    public void gazeFor(string who, float sec, int dir)
    {
        StartCoroutine(avatarGazeFor(new Tutor(who), sec, (GAZE_DIR)dir));
    }
    IEnumerator avatarGazeFor(Tutor tutor, float wait, GAZE_DIR gazeDir)
    {
        if (gazeDir == GAZE_DIR.LEFT)
        {
            manager.Act(tutor, new HeadAction("Gaze", "Middle to Left"));
            yield return new WaitForSeconds(wait + 1);
            manager.Act(tutor, new HeadAction("Gaze", "Left to Middle"));
        }
        if (gazeDir == GAZE_DIR.RIGHT)
        {
            manager.Act(tutor, new HeadAction("Gaze", "Middle to Right"));
            yield return new WaitForSeconds(wait + 1);
            manager.Act(tutor, new HeadAction("Gaze", "Right to Middle"));
        }
    }
    //end

    IEnumerator ShowNotification(string text)
    {
        notification.GetComponentInChildren<Text>().text = text;
        notification.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        notification.SetActive(false);
    }

    #region message_dialog
    public void CheckpointAlert()
    {
        AGAlertDialog.ShowMessageDialog("Checkpoint Notification", "Análise Infinitesimal: Test 2 grades are out!", "Ok",
            () => AGUIMisc.ShowToast(""), () => AGUIMisc.ShowToast(""),
            AGDialogTheme.Dark);
    }
    #endregion
    
    public void OpenCalendar()
    {
        AGCalendar.OpenCalendarForDate(DateTime.Now.AddDays(7));
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
