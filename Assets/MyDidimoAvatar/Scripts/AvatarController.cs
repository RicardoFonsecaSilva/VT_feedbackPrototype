using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System.Linq;

[RequireComponent(typeof(Animator))]
public partial class AvatarController : MonoBehaviour
{
    private Animator animator;
    private AnimatorParameters animParams;

    void Start()
    {
        animator = GetComponent<Animator>();

        animParams.talkSpeed = new KeyValuePair<string, float>("Talk Speed", 1.0f);
        animParams.nodSpeed = new KeyValuePair<string, float>("Nod Speed", 1.0f);
        animParams.nodFrequency = 1.0f;
        animParams.gazeAtSpeed = new KeyValuePair<string, float>("Gaze At Speed", 1.0f);
        animParams.gazeBackSpeed = new KeyValuePair<string, float>("Gaze Back Speed", 1.0f);
        animParams.gazeFrequency = 1.0f;

        StartCoroutine("NoddingRoutine");
    }

    void FixedUpdate()
    {
        animator.SetFloat(animParams.talkSpeed.Key, animParams.talkSpeed.Value);
        animator.SetFloat(animParams.nodSpeed.Key, animParams.nodSpeed.Value);
        animator.SetFloat(animParams.gazeAtSpeed.Key, animParams.gazeAtSpeed.Value);
        animator.SetFloat(animParams.gazeBackSpeed.Key, animParams.gazeBackSpeed.Value);
    }

    public void ExpressEmotion(ExpressionState expression)
    {
        animator.SetInteger("Expression", (int)expression);
        animator.SetTrigger("Express");
    }

    public void SetMood(MoodState moodState)
    {
        animator.SetInteger("Mood", (int)moodState);
    }

    public void DoNodding(NodState nodState)
    {
        animator.SetInteger("Nod Style", (int)nodState);
        animator.SetTrigger("Nod");
    }

    IEnumerator NoddingRoutine()
    {
        //TODO: OFFER CALLMETHOD TO ALTER THE NOD FREQUENCY
        float frequency = 0;

        while (true)
        {
            if (animator.GetBool("Listening"))
            {
                DoNodding(NodState.NOD);
                //TODO: RETRIEVE NOD LENGTH FROM ANIMATOR
                yield return new WaitForSeconds(3.0f);
            }
            yield return new WaitForSeconds(frequency + 0.001f);
        }
    }

    public void DoTalking(TalkState talkState)
    {
        animator.SetInteger("Talk State", (int)talkState);
        animator.SetTrigger("Talk");
    }

    public void DoGazing(GazeState gazeState)
    {
        animator.SetInteger("Direction", (int)gazeState);
        if((int)gazeState % 2 != 0)
            animator.SetTrigger("Gaze");
    }

    public void toggleListeningState()
    {
        animator.SetBool("Listening", !animator.GetBool("Listening"));
    }

    public void setAnimationSpeed(string parameter, float value)
    {
        CultureInfo culture = CultureInfo.InvariantCulture;

        if (culture.CompareInfo.IndexOf(parameter, "nod", CompareOptions.IgnoreCase) >= 0)
            animParams.nodSpeed = new KeyValuePair<string, float>(animParams.nodSpeed.Key, value);

        if (culture.CompareInfo.IndexOf(parameter, "talk", CompareOptions.IgnoreCase) >= 0)
            animParams.talkSpeed = new KeyValuePair<string, float>(animParams.talkSpeed.Key, value);

        string[] matchStrings = { "gaze", "at" };
        if (matchStrings.All(parameter.ToLowerInvariant().Contains))
            animParams.gazeAtSpeed = new KeyValuePair<string, float>(animParams.gazeAtSpeed.Key, value);

        matchStrings = new string[] { "gaze", "back" };
        if (matchStrings.All(parameter.ToLowerInvariant().Contains))
            animParams.gazeBackSpeed = new KeyValuePair<string, float>(animParams.gazeBackSpeed.Key, value);
    }

    public void setAnimationFrequency(string parameter, float value)
    {
        //TODO: FINISH METHOD
        animator.SetFloat(parameter, value);
    }
}

struct AnimatorParameters
{
    public KeyValuePair<string, float> talkSpeed;

    public KeyValuePair<string, float> nodSpeed;
    public float nodFrequency;

    public KeyValuePair<string, float> gazeAtSpeed;
    public KeyValuePair<string, float> gazeBackSpeed;
    public float gazeFrequency;
}