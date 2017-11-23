using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VT;

public class ButtonsController : MonoBehaviour {

    private static BallonsTest balloon;
    private static GameObject balloonObject;
    private static string text = "hello world", emotion = "Default";

    private static ButtonsController instance = null;
    public static ButtonsController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ButtonsController();
                Initialize();
            }
            return instance;
        }
    }

    static void Initialize()
    {
        balloonObject = GameObject.FindGameObjectWithTag("Balloon Manager");
        balloon = balloonObject.GetComponent<BallonsTest>();
    }

    public void SetMood(int mood)
    {
        if (mood < 0)
            emotion = "Sad";
        else if (mood > 0)
            emotion = "Happy";
        else
            emotion = "Default";
    }

    public void Generate(string person)
    {
        balloon.Show(person, text, emotion);
    }
}
