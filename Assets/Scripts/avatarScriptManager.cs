using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avatarScriptManager : MonoBehaviour {

    [SerializeField]
    private AvatarControllerUIHook maleAvatarControllerHook;
    [SerializeField]
    private AvatarControllerUIHook femaleAvatarControllerHook;

    void Update() {}

    public void talkFor(string who, float sec)
    {
        if (who == "joao")
            StartCoroutine(joaoTalkFor(sec));
        if (who == "maria")
            StartCoroutine(mariaTalkFor(sec));
    }
    public void express(string who, int id)
    {
        if (who == "joao")
            maleAvatarControllerHook._requestExpression(id);
        if (who == "maria")
            femaleAvatarControllerHook._requestExpression(id);
    }

    public IEnumerator joaoTalkFor(float wait)
    {
        maleAvatarControllerHook._requestExpression(19);
        yield return new WaitForSeconds(wait);
        maleAvatarControllerHook._requestExpression(0);
    }
    public IEnumerator mariaTalkFor(float wait)
    {
        femaleAvatarControllerHook._requestExpression(19);
        yield return new WaitForSeconds(wait);
        femaleAvatarControllerHook._requestExpression(0);
    }
}