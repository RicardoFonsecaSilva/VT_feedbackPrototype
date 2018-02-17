using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avatarScriptManager : MonoBehaviour {

    [SerializeField]
    private AvatarControllerUIHook maleAvatarControllerHook;
    [SerializeField]
    private AvatarControllerUIHook femaleAvatarControllerHook;

    IEnumerator Example()
    {
        print(Time.time);
        maleAvatarControllerHook._requestExpression(19);
        yield return new WaitForSeconds(3);
        print(Time.time);
        maleAvatarControllerHook._requestExpression(0);
    }

    void Update()
    {
        if (Input.GetKeyDown("q"))
            test();
        if (Input.GetKeyDown("w"))
            test2();
        if (Input.GetKeyDown("1"))
            test3();
    }

    public void test()
    {
        maleAvatarControllerHook._requestExpression(18);
    }
    public void test2()
    {
        maleAvatarControllerHook._requestExpression(0);
    }
    public void test3()
    {
        
        StartCoroutine(Example());
        
    }
}