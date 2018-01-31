using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avatarController : MonoBehaviour
{

    [SerializeField]
    private AvatarController maleAvatarController;
    [SerializeField]
    private AvatarController femaleAvatarController;

    [SerializeField]
    private AvatarControllerUIHook maleAvatarControllerHook;
    [SerializeField]
    private AvatarControllerUIHook femaleAvatarControllerHook;



    void Start()
    {
    }

    void OnEnable()
    {
        maleAvatarControllerHook.OnMoodChange += MaleMoodChange;
        femaleAvatarControllerHook.OnMoodChange += FemaleMoodChange;
        maleAvatarControllerHook.OnExpressionRequest += MaleExpressionRequest;
        femaleAvatarControllerHook.OnExpressionRequest += FemaleExpressionRequest;
    }

    void OnDisable()
    {
        maleAvatarControllerHook.OnMoodChange -= MaleMoodChange;
        femaleAvatarControllerHook.OnMoodChange -= FemaleMoodChange;
        maleAvatarControllerHook.OnExpressionRequest -= MaleExpressionRequest;
        femaleAvatarControllerHook.OnExpressionRequest -= FemaleExpressionRequest;
    }

    private void MaleMoodChange(MoodState state)
    {
        if (maleAvatarController != null)
        {
            maleAvatarController.SetMood(state);
        }
    }

    private void FemaleMoodChange(MoodState state)
    {
        if (femaleAvatarController != null)
        {
            femaleAvatarController.SetMood(state);
        }
    }

    private void MaleExpressionRequest(ExpressionState state)
    {
        if (maleAvatarController != null)
        {
            maleAvatarController.ExpressEmotion(state);
        }
        //zoomIn(source);
        //turnHead(source);
    }

    private void FemaleExpressionRequest(ExpressionState state)
    {

        if (femaleAvatarController != null)
        {
            femaleAvatarController.ExpressEmotion(state);
        }
        //zoomIn(source);
        //turnHead(source);
    }

    private void turnHead(string source)
    {
    }

    private void zoomIn(string source)
    {
    }
}