using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarTestMain : MonoBehaviour
{
    //This will be the main animation manager for the synthetic characters
    [SerializeField]
    private AvatarManager manager;
    //Placeholder, system should be aware of the available new Tutor(tutorName)s (by name)
    [SerializeField]
    private GameObject tutor;
    private string tutorName;

    void Start()
    {
        tutorName = tutor.name;
    }

    void Update()
    {
        if (manager == null)
            return;

        // Emotion
        if (Input.GetKey("q"))
            manager.Feel(new Tutor(tutorName), new Emotion(EmotionEnum.Neutral, -1.0f));
        if (Input.GetKey("w"))
            manager.Feel(new Tutor(tutorName), new Emotion(EmotionEnum.Happiness, 0.2f));
        if (Input.GetKey("e"))
            manager.Feel(new Tutor(tutorName), new Emotion(EmotionEnum.Happiness, 0.8f));
        if (Input.GetKey("r"))
            manager.Feel(new Tutor(tutorName), new Emotion(EmotionEnum.Sadness, 0.2f));
        if (Input.GetKey("t"))
            manager.Feel(new Tutor(tutorName), new Emotion(EmotionEnum.Sadness, 0.8f));

        // Expression
        if (Input.GetKey("a"))
            manager.Express(new Tutor(tutorName), new Expression("Neutral", ""));
        if (Input.GetKey("s"))
            manager.Express(new Tutor(tutorName), new Expression("Happy", "Low"));
        if (Input.GetKey("d"))
            manager.Express(new Tutor(tutorName), new Expression("Happy", "High"));
        if (Input.GetKey("f"))
            manager.Express(new Tutor(tutorName), new Expression("Sad", "Low"));
        if (Input.GetKey("g"))
            manager.Express(new Tutor(tutorName), new Expression("Sad", "High"));
        if (Input.GetKey("h"))
            manager.Express(new Tutor(tutorName), new Expression("Anger", "Low"));
        if (Input.GetKey("j"))
            manager.Express(new Tutor(tutorName), new Expression("Anger", "High"));
        if (Input.GetKey("k"))
            manager.Express(new Tutor(tutorName), new Expression("Fear", "Low"));
        if (Input.GetKey("l"))
            manager.Express(new Tutor(tutorName), new Expression("Fear", "High"));
        if (Input.GetKey("z"))
            manager.Express(new Tutor(tutorName), new Expression("Disgust", "Low"));
        if (Input.GetKey("x"))
            manager.Express(new Tutor(tutorName), new Expression("Disgust", "High"));
        if (Input.GetKey("c"))
            manager.Express(new Tutor(tutorName), new Expression("Surprise", "Low"));
        if (Input.GetKey("v"))
            manager.Express(new Tutor(tutorName), new Expression("Surprise", "High"));

        // Action
        if (Input.GetKey("b"))
            manager.Act(new Tutor(tutorName), new HeadAction("Head", "Nod"));
        if (Input.GetKey("n"))
            manager.Act(new Tutor(tutorName), new HeadAction("Talk", ""));
        if (Input.GetKey("m"))
            manager.Act(new Tutor(tutorName), new HeadAction("Talk", "End"));
        if (Input.GetKey("y"))
            manager.Act(new Tutor(tutorName), new HeadAction("Gaze", "Middle to Left"));
        if (Input.GetKey("u"))
            manager.Act(new Tutor(tutorName), new HeadAction("Gaze", "Left to Middle"));
        if (Input.GetKey("i"))
            manager.Act(new Tutor(tutorName), new HeadAction("Gaze", "Middle to Right"));
        if (Input.GetKey("o"))
            manager.Act(new Tutor(tutorName), new HeadAction("Gaze", "Right to Middle"));
    }
}
