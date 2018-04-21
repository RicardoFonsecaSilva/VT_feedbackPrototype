using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System.Linq;
using System;

[RequireComponent(typeof(Animator))]
public partial class AvatarController : MonoBehaviour
{
    private Animator animator;
    private AvatarParameters parameters;

    void Start()
    {
        animator = GetComponent<Animator>();
        parameters = GetComponent<AvatarParameters>();

        StartCoroutine("NoddingRoutine");
        //StartCoroutine("DEBUGRoutine");
    }

    void FixedUpdate()
    {
        // Updates the parameters of the animator
        //if (animator.gameObject.activeSelf) 
        //    foreach (var entry in parameters.animParams)
        //        animator.SetFloat(entry.Value.ID, entry.Value.VALUE);
    }

    public void SetMood(MoodState moodState, float intensity)
    {
        float[][] preset;
        switch (moodState)
        {
            case MoodState.NEUTRAL:
                preset = AvatarParameters.Presets.Neutral();
                break;
            case MoodState.HAPPINESS:
                if(intensity < 0.5)
                    preset = AvatarParameters.Presets.Happiness();
                else
                    preset = AvatarParameters.Presets.HappinessHigh();
                break;
            case MoodState.SADNESS:
                if (intensity < 0.5)
                    preset = AvatarParameters.Presets.Sadness();
                else
                    preset = AvatarParameters.Presets.SadnessHigh();
                break;
            default:
                preset = AvatarParameters.Presets.Neutral();
                break;
        }

        parameters.setAllParameters<AnimatorParams>(preset[0]);
        parameters.setAllParameters<ControllerParams>(preset[1]);
        parameters.setParameter(AnimatorParams.MOOD_INTENSITY, intensity);

        animator.SetInteger("Mood", (int)moodState);
    }

    //TODO : NEXT METHOD TO FIX
    public void ExpressEmotion(ExpressionState expression)
    {
        if ((int)expression == 0)
            animator.SetFloat("Expression Intensity", 0.0f);
        if((int)expression % 2 == 0) //low expression
            animator.SetFloat("Expression Intensity", 1.0f);
        else //high expression
            animator.SetFloat("Expression Intensity", 0.5f);

        animator.SetInteger("Expression", (int)expression);
        animator.SetTrigger("Express");
    }

    public void DoNodding(NodState nodState)
    {
        animator.SetInteger("Nod Style", (int)nodState);
        animator.SetTrigger("Nod");
    }

    IEnumerator NoddingRoutine()
    {
        
        while (true)
        {
            yield return null;
            if (animator.gameObject.activeSelf)
            {
                if (animator.GetBool("Listening"))
                {
                    DoNodding(NodState.NOD);
                    //TODO: USE NOD LENGTH (FROM ANIMATOR) AS THE WAIT TIME BETWEEN NODS
                    //yield return new WaitForSeconds(Mathf.Abs(NODDURATION / (parameters.nodSpeed.Value == 0.0f ? 0.001f : parameters.nodSpeed.Value) ));
                }
            }
            //yield return new WaitForSeconds(NODMAXINTERVAL * (1 - parameters.nodFrequency) + 0.001f);  
        }
    }

    public void DoTalking(TalkState talkState)
    {
        animator.SetInteger("Talk State", (int)talkState);
        animator.SetTrigger("Talk");
    }

    public void DoGazing(GazeState gazeState)
    {
        float rand = UnityEngine.Random.value;

        animator.SetInteger("Direction", (int)gazeState);

        // Randomizer for gaze frequency
        //if (UnityEngine.Random.value <= parameters.gazeFrequency)
        //{  
        //    if ((int)gazeState % 2 != 0)
        //        animator.SetTrigger("Gaze");
        //}
    }

    public void isListening(bool state)
    {
        animator.SetBool("Listening", state);
    }

    public void setAnimationSpeed(string parameter, float value)
    {
        CultureInfo culture = CultureInfo.InvariantCulture;

        //if (culture.CompareInfo.IndexOf(parameter, "nod", CompareOptions.IgnoreCase) >= 0)
        //    parameters.nodSpeed = new KeyValuePair<string, float>(parameters.nodSpeed.Key, value);

        //if (culture.CompareInfo.IndexOf(parameter, "talk", CompareOptions.IgnoreCase) >= 0)
        //    parameters.talkSpeed = new KeyValuePair<string, float>(parameters.talkSpeed.Key, value);

        //string[] matchStrings = { "gaze", "at" };
        //if (matchStrings.All(parameter.ToLowerInvariant().Contains))
        //    parameters.gazeAtSpeed = new KeyValuePair<string, float>(parameters.gazeAtSpeed.Key, value);

        //matchStrings = new string[] { "gaze", "back" };
        //if (matchStrings.All(parameter.ToLowerInvariant().Contains))
        //    parameters.gazeBackSpeed = new KeyValuePair<string, float>(parameters.gazeBackSpeed.Key, value);
    }

    public void setAnimationFrequency(string parameter, float value)
    {
        CultureInfo culture = CultureInfo.InvariantCulture;

        //if (culture.CompareInfo.IndexOf(parameter, "nod", CompareOptions.IgnoreCase) >= 0)
        //    parameters.nodFrequency = Mathf.Clamp(value, 0.0f, 1.0f);

        // TODO: SEE IF 0 TO 1 RANGE IS OK FOR GAZE FREQUENCY
        //if (culture.CompareInfo.IndexOf(parameter, "gaze", CompareOptions.IgnoreCase) >= 0)
        //    parameters.gazeFrequency = Mathf.Clamp(value, 0.0f, 1.0f);
    }

    public void setParameter(string parameter, float value)
    {
       // if (matchStrings.All(parameter.ToLowerInvariant().Contains))
       //     animParams.gazeAtSpeed = new KeyValuePair<string, float>(animParams.gazeAtSpeed.Key, value);
    }

    IEnumerator DEBUGRoutine()
    {
        while (true)
        {
            if (CultureInfo.InvariantCulture.CompareInfo.IndexOf(animator.ToString(), "Maria", CompareOptions.IgnoreCase) >= 0)
            {
                //Debug.Log(String.Format("animParams.talkSpeed: {0}", parameters.talkSpeed.Value));
                //Debug.Log(String.Format("animParams.nodSpeed: {0}", parameters.nodSpeed.Value));
                //Debug.Log(String.Format("animParams.nodFrequency: {0}", parameters.nodFrequency));
                //Debug.Log(String.Format("animParams.gazeAtSpeed: {0}", parameters.gazeAtSpeed.Value));
                //Debug.Log(String.Format("animParams.gazeBackSpeed: {0}", parameters.gazeBackSpeed.Value));
                //Debug.Log(String.Format("animParams.gazeFrequency: {0}", parameters.gazeFrequency));
                ////

                //Debug.Log(String.Format("NODDURATIONF: {0}", Mathf.Abs(NODDURATION * parameters.nodSpeed.Value)));
                //Debug.Log(String.Format("NODINTERVAL: {0}", NODMAXINTERVAL * (1 - parameters.nodFrequency) + 0.001f));
            }
            yield return new WaitForSeconds(5.0f);
        }
    }

}