using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avatarScriptManager : MonoBehaviour {

    private string male = "Joao";
    private string female = "Maria";

    [SerializeField]
    private AvatarControllerUIHook maleAvatarControllerHook;
    [SerializeField]
    private AvatarControllerUIHook femaleAvatarControllerHook;

    public void talkFor(string who, float sec)
    {
        if (who == male)
            StartCoroutine(joaoTalkFor(sec));
        if (who == female)
            StartCoroutine(mariaTalkFor(sec));
    }
    public void express(string who, int id)
    {
        if (who == male)
            maleAvatarControllerHook._requestExpression(id);
        if (who == female)
            femaleAvatarControllerHook._requestExpression(id);
    }
    public void mood(string who, int id)
    {
        if (who == male)
            maleAvatarControllerHook._requestMood(id);
        if (who == female)
            femaleAvatarControllerHook._requestMood(id);
    }
    public void gazeFor(string who, float sec, int dir)
    {
        if (who == male)
            StartCoroutine(joaoGazeFor(sec,dir));
        if (who == female)
            StartCoroutine(mariaGazeFor(sec, dir));
    }
    IEnumerator joaoTalkFor(float wait)
    {
        maleAvatarControllerHook._requestExpression(19);
        yield return new WaitForSeconds(wait);
        maleAvatarControllerHook._requestExpression(0);
    }
    IEnumerator mariaTalkFor(float wait)
    {
        femaleAvatarControllerHook._requestExpression(19);
        yield return new WaitForSeconds(wait);
        femaleAvatarControllerHook._requestExpression(0);
    }
    IEnumerator joaoGazeFor(float wait, int dir)
    {
        maleAvatarControllerHook._requestGaze(dir);
        yield return new WaitForSeconds(wait+1);
        maleAvatarControllerHook._requestGaze(0);
    }
    IEnumerator mariaGazeFor(float wait, int dir)
    {
        femaleAvatarControllerHook._requestGaze(dir);
        yield return new WaitForSeconds(wait+1);
        femaleAvatarControllerHook._requestGaze(0);
    }
}