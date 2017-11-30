using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avatarController : MonoBehaviour
{
    public GameObject maleAvatar;
    public GameObject femaleAvatar;
    private Animator maleAnimator;
    private Animator femaleAnimator;
    private string expression = "Null";

    void Start()
    {
        maleAnimator = maleAvatar.GetComponent<Animator>();
        femaleAnimator = femaleAvatar.GetComponent<Animator>();
    }

    void OnEnable()
    {
        hookController.OnTalkRequest += HandleTalkRequest;
        hookController.OnMoodChange += HandleMoodChange;
        hookController.OnExpressionRequest += HandleExpressionRequest;
        hookController.OnBlendToggle += HandleBlendToggle;
    }

    void OnDisable()
    {
        hookController.OnTalkRequest -= HandleTalkRequest;
        hookController.OnMoodChange -= HandleMoodChange;
        hookController.OnExpressionRequest -= HandleExpressionRequest;
        hookController.OnBlendToggle -= HandleBlendToggle;
    }

    private void HandleBlendToggle(string source, int param1)
    {
        //Debug.Log(gameObject.name + ": \"Blend\" event was received." + source);
        toggleBlend(source);
    }

    private void HandleTalkRequest(string source, int param1)
    {
        //Debug.Log(gameObject.name + ": \"Talk\" event was received." + source);
        zoomIn(source);
        turnHead(source);
    }
    private void HandleMoodChange(string source, int param1)
    {
        //Debug.Log(gameObject.name + ": \"Mood\" event was received." + source + "; " + param1);
        updateMood(source, param1);
    }
    private void HandleExpressionRequest(string source, int param)
    {
        //Debug.Log(gameObject.name + ": \"Expression\" event was received." + source + "; " + param);
        expressEmotion(source, param);
    }

    private void toggleBlend(string source)
    {
        string paramName = "blendActive";

        if (source == "Joao")
            maleAnimator.SetBool(paramName, !maleAnimator.GetBool(paramName));

        if (source == "Maria")
            femaleAnimator.SetBool(paramName, !femaleAnimator.GetBool(paramName));
        
        //Debug.Log("ERROR: COULD NOT FIND CORRECT AVATAR.");
    }
    private void updateMood(string source, int param)
    {
        if (source == "Joao")
        {
            maleAnimator.SetInteger("CurrentMood", param);
            return;
        }
            
        if (source == "Maria")
        {
            femaleAnimator.SetInteger("CurrentMood", param);
            return;
        }
        //Debug.Log("ERROR: COULD NOT FIND CORRECT AVATAR.");
    }
    private void turnHead(string source)
    {
        if (source == "Maria")
        {
            maleAnimator.SetBool("beingTalkedTo", true);
            return;
        }

        if (source == "Joao")
        {
            femaleAnimator.SetBool("beingTalkedTo", true);
            return;
        }
        //Debug.Log("ERROR: COULD NOT FIND THE SPEECH SOURCE.");
    }
    private void zoomIn(string source)
    {
        if (source == "Maria")
        {
            femaleAnimator.SetBool("isTalking", true);
            return;
        }

        if (source == "Joao")
        {
            maleAnimator.SetBool("isTalking", true);
            return;
        }
        //Debug.Log("ERROR: COULD NOT FIND THE SPEECH SOURCE.");
    }
    private void expressEmotion(string source, int param)
    {
        switch (param)
        {
            case 1:
                expression = "Expression - Fear";
                break;
            case 2:
                expression = "Expression - Fear (Intense)";
                break;
            case 3:
                expression = "Expression - Rage";
                break;
            case 4:
                expression = "Expression - Rage (Intense)";
                break;
            case 5:
                expression = "Expression - Disgust";
                break;
            case 6:
                expression = "Expression - Disgust (Intense)";
                break;
            case 7:
                expression = "Expression - Surprise";
                break;
            case 8:
                expression = "Expression - Surprise (Intense)";
                break;
            case 9:
                expression = "Expression - Sadness";
                break;
            case 10:
                expression = "Expression - Sadness (Intense)";
                break;
            case 11:
                expression = "Expression - Happiness";
                break;
            case 12:
                expression = "Expression - Happiness (Intense)";
                break;
            default:
                break;
        }

        if (source == "Joao")
        {
            maleAnimator.CrossFade(expression, 0.3F, maleAnimator.GetLayerIndex("Expression"));
            return;
        }
        if (source == "Maria")
        {
            femaleAnimator.CrossFade(expression, 0.3F, femaleAnimator.GetLayerIndex("Expression"));
            return;
        }
    }
}