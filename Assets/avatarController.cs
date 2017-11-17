using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avatarController : MonoBehaviour
{

    void OnEnable()
    {
        hookController.OnTalkRequest += HandleTalkRequest;
    }


    void HandleTalkRequest()
    {
        Debug.Log(gameObject.name + ": Event was received.");
    }

    void OnDisable()
    {
        hookController.OnTalkRequest -= HandleTalkRequest;
    }
}
