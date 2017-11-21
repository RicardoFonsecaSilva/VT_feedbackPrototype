using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avatarController : MonoBehaviour
{
    public GameObject maleAvatar;
    public GameObject femaleAvatar;

    void OnEnable()
    {
        hookController.OnTalkRequest += HandleTalkRequest;
    }

    void OnDisable()
    {
        hookController.OnTalkRequest -= HandleTalkRequest;
    }

    void HandleTalkRequest(string avatar)
    {
        Debug.Log(gameObject.name + ": \"Talk\" event was received." + avatar);
        Debug.Log(gameObject.name + ": "+ maleAvatar.name+ ";" + femaleAvatar);
    }


}
