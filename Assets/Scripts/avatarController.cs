using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avatarController : MonoBehaviour
{
    public GameObject maleAvatar;
    public GameObject femaleAvatar;
    private Animator maleAnimator;
    private Animator femaleAnimator;

    void OnEnable()
    {
        hookController.OnTalkRequest += HandleTalkRequest;
        hookController.OnMoodChange += HandleMoodChange;
    }
    void OnDisable()
    {
        hookController.OnTalkRequest -= HandleTalkRequest;
        hookController.OnMoodChange -= HandleMoodChange;
    }

    void HandleTalkRequest(string source, int param1)
    {
        Debug.Log(gameObject.name + ": \"Talk\" event was received." + source);
        zoomIn(source);
        turnHead(source);
    }
    void HandleMoodChange(string source, int param1)
    {
        Debug.Log(gameObject.name + ": \"Mood\" event was received." + source + "; " + param1);
        updateMood(source, param1);
    }

    void Start()
    {
        maleAnimator = maleAvatar.GetComponent<Animator>();
        femaleAnimator = femaleAvatar.GetComponent<Animator>();
    }

    private void updateMood(string avatar, int mood)
    {
        if (avatar == "Joao")
        {
            maleAnimator.SetInteger("CurrentMood", mood);
            return;
        }
            
        if (avatar == "Maria")
        {
            femaleAnimator.SetInteger("CurrentMood", mood);
            return;
        }
        Debug.Log("ERROR: COULD NOT FIND CORRECT AVATAR.");
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
        Debug.Log("ERROR: COULD NOT FIND THE SPEECH SOURCE.");
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
        Debug.Log("ERROR: COULD NOT FIND THE SPEECH SOURCE.");
    }
}