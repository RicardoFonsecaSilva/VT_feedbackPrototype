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
            //balloonManager.MaleMoodChange(MoodState.HAPPY_HIGH);
            //balloonManager.FemaleMoodChange(MoodState.HAPPY_HIGH);
            //balloonManager.optionsText_1 = "Hello.";
            //balloonManager.optionsText_2 = "Hello.";
            //balloonManager.Generate("Options");
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
