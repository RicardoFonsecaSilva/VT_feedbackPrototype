using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VT;

public class ButtonsController : MonoBehaviour {

    private BallonsTest balloon;
    private GameObject balloonObject;
    public string joaoEmotion = "Default", mariaEmotion = "Default";
    public string optionsText_1 = "asdf", optionsText_2 = "123", text = "hello world";
    public ChangeBackground mariaPlane, joaoPlane;

    public float timeToWait = 2.0f;

    [SerializeField]
    private AvatarControllerUIHook maleAvatarControllerHook;
    [SerializeField]
    private AvatarControllerUIHook femaleAvatarControllerHook;

    void Start()
    {
        balloonObject = GameObject.FindGameObjectWithTag("Balloon Manager");
        balloon = balloonObject.GetComponent<BallonsTest>();
    }

    //Event Listeners
    void OnEnable()
    {
        maleAvatarControllerHook.OnMoodChange += MaleMoodChange;
        femaleAvatarControllerHook.OnMoodChange += FemaleMoodChange;
        maleAvatarControllerHook.OnExpressionRequest += MaleExpressionRequest;
        femaleAvatarControllerHook.OnExpressionRequest += FemaleExpressionRequest;
    }
    void OnDisable()
    {
        maleAvatarControllerHook.OnMoodChange -= MaleMoodChange;
        femaleAvatarControllerHook.OnMoodChange -= FemaleMoodChange;
        maleAvatarControllerHook.OnExpressionRequest -= MaleExpressionRequest;
        femaleAvatarControllerHook.OnExpressionRequest -= FemaleExpressionRequest;
    }

    //Event Handlers
    void MaleExpressionRequest(ExpressionState state)
    {
        if(ExpressionState.VISEMES == state)
            Generate("Joao");
    }

    void FemaleExpressionRequest(ExpressionState state)
    {
        if (ExpressionState.VISEMES == state)
            Generate("Maria");
    }

    public void MaleMoodChange(MoodState state)
    {
        SetMood("Joao", state);
        joaoPlane.ChangeBackgroundColor((state == MoodState.HAPPY_LOW || state == MoodState.HAPPY_HIGH) ? "Happy" : (state == MoodState.SAD_HIGH || state == MoodState.SAD_LOW) ? "Sad" : "Default");
    }

    public void FemaleMoodChange(MoodState state)
    {
        SetMood("Maria", state);
        mariaPlane.ChangeBackgroundColor((state == MoodState.HAPPY_LOW || state == MoodState.HAPPY_HIGH) ? "Happy" : (state == MoodState.SAD_HIGH || state == MoodState.SAD_LOW) ? "Sad" : "Default");
    }

    public void SetMood(string person, MoodState mood)
    {
        if (person == "Maria")
        {
            if (mood == MoodState.SAD_HIGH || mood == MoodState.SAD_LOW)
                mariaEmotion = "Sad";
            else if (mood == MoodState.HAPPY_LOW || mood == MoodState.HAPPY_HIGH)
                mariaEmotion = "Happy";
            else
                mariaEmotion = "Default";
        }

        if (person == "Joao")
        {
            if (mood == MoodState.SAD_HIGH || mood == MoodState.SAD_LOW)
                joaoEmotion = "Sad";
            else if (mood == MoodState.HAPPY_LOW || mood == MoodState.HAPPY_HIGH)
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
        if(person == "Joao" || person == "Maria")
            balloon.Show(person, text, person == "Joao" ? joaoEmotion : mariaEmotion, timeToWait);
        else
            balloon.Show("Options", optionsText_1, "Default", timeToWait, optionsText_2);
    }

    public void Clean(float t)
    {
        balloon.CleanOptions(t);
    }
}
