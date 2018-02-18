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
        maleAvatarControllerHook.OnGazeRequest += MaleGazeRequest;
        femaleAvatarControllerHook.OnGazeRequest += FemaleGazeRequest;
    }

    void OnDisable()
    {
        maleAvatarControllerHook.OnMoodChange -= MaleMoodChange;
        femaleAvatarControllerHook.OnMoodChange -= FemaleMoodChange;
        maleAvatarControllerHook.OnExpressionRequest -= MaleExpressionRequest;
        femaleAvatarControllerHook.OnExpressionRequest -= FemaleExpressionRequest;
        maleAvatarControllerHook.OnGazeRequest -= MaleGazeRequest;
        femaleAvatarControllerHook.OnGazeRequest -= FemaleGazeRequest;
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

    private void MaleGazeRequest(GazeState state)
    {
        if (maleAvatarController != null)
            maleAvatarController.GazeAt(state);
    }

    private void FemaleGazeRequest(GazeState state)
    {

        if (femaleAvatarController != null)
            femaleAvatarController.GazeAt(state);
    }

    private void turnHead(string source)
    {
    }

    private void zoomIn(string source)
    {
    }
}