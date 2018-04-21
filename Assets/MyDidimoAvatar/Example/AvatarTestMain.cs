#define TESTCOMMAND
using System;
using UnityEngine;

public class AvatarTestMain : MonoBehaviour
{
    //This will be the main animation manager for the synthetic characters
    [Header("Object Hooks")]
    [SerializeField]
    private AvatarManager manager;
    //Placeholder, system should be aware of the available tutors (by name)
    [SerializeField]
    private GameObject tutor;   
    private string tutorName;
    [Space(2.0f)]
    [Header("Yarn Commands")]
    [SerializeField]
    private bool testCommands = false;

    void Start()
    {
        if (undefinedReferences())
            Debug.Log("[WARNING]: One or more editor references (required for testing) are currently unassigned.");
        else
            tutorName = tutor.name;
    }
    public void toogleCommandTest()
    {
        testCommands = !testCommands;
    }
    private bool undefinedReferences()
    {
        return manager == null || tutor == null;
    }

    // Input driven commands
    void FixedUpdate()
    {
        if (undefinedReferences())
            return;

        // Emotion
        if (Input.GetKey("q"))
        {
            if (testCommands)
                manager.sendCommand(new string[] { "Feel", tutorName, "Neutral", "0.0" });
            else
                manager.Feel(new Tutor(tutorName, new Emotion(EmotionEnum.Neutral, 0.0f)));
        }   
        if (Input.GetKey("w"))
        {
            if (testCommands)
                manager.sendCommand(new string[] { "Feel", tutorName, "Happiness", "0.2" });
            else
                manager.Feel(new Tutor(tutorName, new Emotion(EmotionEnum.Happiness, 0.2f)));
        }
        if (Input.GetKey("e"))
        {
            if (testCommands)
                manager.sendCommand(new string[] { "Feel", tutorName, "Happiness", "0.8" });
            else
                manager.Feel(new Tutor(tutorName, new Emotion(EmotionEnum.Happiness, 0.8f)));
        }
        if (Input.GetKey("r"))
        {
            if (testCommands)
                manager.sendCommand(new string[] { "Feel", tutorName, "Sadness", "0.2" });
            else
                manager.Feel(new Tutor(tutorName, new Emotion(EmotionEnum.Sadness, 0.2f)));
        }
        if (Input.GetKey("t"))
        {
            if (testCommands)
                manager.sendCommand(new string[] { "Feel", tutorName, "Sadness", "0.8" });
            else
                manager.Feel(new Tutor(tutorName, new Emotion(EmotionEnum.Sadness, 0.8f)));
        }
        if (Input.GetKey("1"))
        {
            if (testCommands)
                manager.sendCommand(new string[] { "Feel", tutorName, "Fear", "0.0" });
            else
                manager.Feel(new Tutor(tutorName, new Emotion(EmotionEnum.Fear, 0.0f)));
        }
        if (Input.GetKey("2"))
        {
            if (testCommands)
                manager.sendCommand(new string[] { "Feel", tutorName, "Surprise", "0.0" });
            else
                manager.Feel(new Tutor(tutorName, new Emotion(EmotionEnum.Surprise, 0.0f)));
        }

        // Expression
        if (Input.GetKey("a"))
        {
            if (testCommands)
                manager.sendCommand(new string[] { "Express", tutorName, "Neutral", "-1.0" });
            else
                manager.Express(new Tutor(tutorName), new Emotion(EmotionEnum.Neutral, -1.0f));
        }
        if (Input.GetKey("s"))
        {
            if (testCommands)
                manager.sendCommand(new string[] { "Express", tutorName, "Happiness", "0.2" });
            else
                manager.Express(new Tutor(tutorName), new Emotion(EmotionEnum.Happiness, 0.2f));
        }
        if (Input.GetKey("d"))
        {
            if (testCommands)
                manager.sendCommand(new string[] { "Express", tutorName, "Happiness", "0.8f" });
            else
                manager.Express(new Tutor(tutorName), new Emotion(EmotionEnum.Happiness, 0.8f));
        }
        if (Input.GetKey("f"))
        {
            if (testCommands)
                manager.sendCommand(new string[] { "Express", tutorName, "Sadness", "0.2f" });
            else
                manager.Express(new Tutor(tutorName), new Emotion(EmotionEnum.Sadness, 0.2f));
        }
        if (Input.GetKey("g"))
        {
            if (testCommands)
                manager.sendCommand(new string[] { "Express", tutorName, "Sadness", "0.8f" });
            else
                manager.Express(new Tutor(tutorName), new Emotion(EmotionEnum.Sadness, 0.8f));
        }
        if (Input.GetKey("h"))
        {
            if (testCommands)
                manager.sendCommand(new string[] { "Express", tutorName, "Anger", "0.2f" });
            else
                manager.Express(new Tutor(tutorName), new Emotion(EmotionEnum.Anger, 0.2f));
        }
        if (Input.GetKey("j"))
        {
            if (testCommands)
                manager.sendCommand(new string[] { "Express", tutorName, "Anger", "0.8f" });
            else
                manager.Express(new Tutor(tutorName), new Emotion(EmotionEnum.Anger, 0.8f));
        }
        if (Input.GetKey("k"))
        {
            if (testCommands)
                manager.sendCommand(new string[] { "Express", tutorName, "Fear", "0.2f" });
            else
                manager.Express(new Tutor(tutorName), new Emotion(EmotionEnum.Fear, 0.2f));
        }
        if (Input.GetKey("l"))
        {
            if (testCommands)
                manager.sendCommand(new string[] { "Express", tutorName, "Fear", "0.8f" });
            else
                manager.Express(new Tutor(tutorName), new Emotion(EmotionEnum.Fear, 0.8f));
        }
        if (Input.GetKey("z"))
        {
            if (testCommands)
                manager.sendCommand(new string[] { "Express", tutorName, "Disgust", "0.2f" });
            else
                manager.Express(new Tutor(tutorName), new Emotion(EmotionEnum.Disgust, 0.2f));
        }
        if (Input.GetKey("x"))
        {
            if (testCommands)
                manager.sendCommand(new string[] { "Express", tutorName, "Disgust", "0.8f" });
            else
                manager.Express(new Tutor(tutorName), new Emotion(EmotionEnum.Disgust, 0.8f));
        }
        if (Input.GetKey("c"))
        {
            if (testCommands)
                manager.sendCommand(new string[] { "Express", tutorName, "Surprise", "0.2f" });
            else
                manager.Express(new Tutor(tutorName), new Emotion(EmotionEnum.Surprise, 0.2f));
        }
        if (Input.GetKey("v"))
        {
            if (testCommands)
                manager.sendCommand(new string[] { "Express", tutorName, "Surprise", "0.8f" });
            else
                manager.Express(new Tutor(tutorName), new Emotion(EmotionEnum.Surprise, 0.8f));
        }

        // Actions
        if (Input.GetKey("b"))
        {
            if (testCommands)
                manager.sendCommand(new string[] { "Nod", tutorName, "Start" });
            else
                manager.Act(new Tutor(tutorName), new HeadAction("Nod", ""));
        }
        if (Input.GetKey("p"))
        {
            if (testCommands)
                manager.sendCommand(new string[] { "Nod", tutorName, "End" });
            else
                manager.Act(new Tutor(tutorName), new HeadAction("Nod", "End"));
        }
        if (Input.GetKey("n"))
        {
            if (testCommands)
                manager.sendCommand(new string[] { "Talk", tutorName, "Start" });
            else
                manager.Act(new Tutor(tutorName), new HeadAction("Talk", ""));
        }
        if (Input.GetKey("m"))
        {
            if (testCommands)
                manager.sendCommand(new string[] { "Talk", tutorName, "End" });
            else
                manager.Act(new Tutor(tutorName), new HeadAction("Talk", "End"));
        }
        if (Input.GetKey("y"))
        {
            if (testCommands)
                manager.sendCommand(new string[] { "Gazeat", tutorName, tutorName=="Maria" ? "Joao" : "Maria" });
            else
                manager.Act(new Tutor(tutorName), new HeadAction("Gaze", "At Partner"));
        }
        if (Input.GetKey("u"))
        {
            if (testCommands)
                manager.sendCommand(new string[] { "Gazeback", tutorName, tutorName == "Maria" ? "Joao" : "Maria" });
            else
                manager.Act(new Tutor(tutorName), new HeadAction("Gaze", "Back From Partner"));
        }
        if (Input.GetKey("i"))
        {
            if (testCommands)
                manager.sendCommand(new string[] { "Gazeat", tutorName, "User" });
            else
                manager.Act(new Tutor(tutorName), new HeadAction("Gaze", "At User"));
        }
        if (Input.GetKey("o"))
        {
            if (testCommands)
                manager.sendCommand(new string[] { "Gazeback", tutorName, "User" });
            else
                manager.Act(new Tutor(tutorName), new HeadAction("Gaze", "Back From User"));
        }

        // Action Speed\Frequency
        if (Input.GetKey("["))
        {
            if (testCommands)
                //manager.sendCommand(new string[] { "Nod", tutorName, "Frequency", "0.5" });
                manager.sendRequest("maria_nodfrequency_0.5");
        }
        if (Input.GetKey("]"))
        {
            if (testCommands)
                //manager.sendCommand(new string[] { "Nod", tutorName, "Speed", "2.0" });
                manager.sendRequest("maria_nodspeed_2.0");
        }
        if (Input.GetKey(","))
        {
            if (testCommands)
            {
                manager.sendRequest("maria_gazeatspeed_1.5");
                //manager.sendCommand(new string[] { "Gazeat", tutorName, "Speed", "1.5" });
                manager.sendRequest("maria_gazebackspeed_2");
                //manager.sendCommand(new string[] { "Gazeback", tutorName, "Speed", "2.0" });
            }
        }
        if (Input.GetKey("."))
        {
            if (testCommands)
                //manager.sendCommand(new string[] { "Gazeat", tutorName, "Frequency", "0.5" });
                manager.sendRequest("maria_gazefrequency_0.5");
        }
    }

    // UI driven commands
    public void talk(string who)
    {
        manager.Act(new Tutor(who), new HeadAction("Talk", ""));
    }
    public void stopTalking(string who)
    {
        manager.Act(new Tutor(who), new HeadAction("Talk", "End"));
    }
}