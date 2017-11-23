using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VT;

public class ButtonsController : MonoBehaviour {

    private static BallonsTest balloon;
    private static GameObject balloonObject;
    private static string text = "hello world", joaoEmotion = "Default", mariaEmotion = "Default";

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

    public void SetMood(string person, int mood)
    {
        if (person == "Maria")
        {
            if (mood < 0)
                mariaEmotion = "Sad";
            else if (mood > 0)
                mariaEmotion = "Happy";
            else
                mariaEmotion = "Default";
        }

        else if (person == "Joao")
        {
            if (mood < 0)
                joaoEmotion = "Sad";
            else if (mood > 0)
                joaoEmotion = "Happy";
            else
                joaoEmotion = "Default";
        }
    }

    public string getMood(string person)
    {
        if (person == "Maria")
            return mariaEmotion;
        else if (person == "Joao")
            return joaoEmotion;
        else return null;
    }

    public void Generate(string person)
    {
        balloon.Show(person, text, person == "Joao" ? joaoEmotion : mariaEmotion);
    }
}
