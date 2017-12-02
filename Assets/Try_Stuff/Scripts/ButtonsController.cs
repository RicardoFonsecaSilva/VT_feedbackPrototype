using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VT;

public class ButtonsController : MonoBehaviour {

    private BallonsTest balloon;
    private GameObject balloonObject;
    private string text = "hello world", joaoEmotion = "Default", mariaEmotion = "Default";
    public ChangeBackground mariaPlane, joaoPlane;

    void Start()
    {
        balloonObject = GameObject.FindGameObjectWithTag("Balloon Manager");
        balloon = balloonObject.GetComponent<BallonsTest>();
    }

    //Event Listeners
    void OnEnable()
    {
        hookController.OnTalkRequest += HandleTalkRequest;
        hookController.OnMoodChange += HandleMoodChange;
    }
    void OnDisable()
    {
        hookController.OnTalkRequest -= HandleTalkRequest;
        hookController.OnMoodChange -= HandleMoodChange;
    }

    //Event Handlers
    void HandleTalkRequest(string source, int param1)
    {
        Generate(source);
    }
    void HandleMoodChange(string source, int param1)
    {
        SetMood(source, param1);
        if (source == "Maria")
            mariaPlane.ChangeBackgroundColor(param1 > 0 ? "Happy" : param1 < 0 ? "Sad" : "Default");
        else if (source == "Joao")
            joaoPlane.ChangeBackgroundColor(param1 > 0 ? "Happy" : param1 < 0 ? "Sad" : "Default");
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
