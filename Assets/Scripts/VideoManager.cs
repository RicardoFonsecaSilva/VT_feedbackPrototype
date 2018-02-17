using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoManager : MonoBehaviour {

    [SerializeField]
    private ButtonsController balloonManager;
    [SerializeField]
    private avatarScriptManager avatarScriptHelper;
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            balloonManager.text = "Hello.";
            balloonManager.timeToWait = 2.0f;
            balloonManager.Generate("Joao");
            avatarScriptHelper.talkFor(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {

        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {

        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {

        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {

        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {

        }
    }
}
