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
}