using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;

// Main interface class between the VT application and the animation module. 
// Handles the propagation of any commands sent by relevant VT modules to the avatar controllers 
public class AvatarManager : MonoBehaviour
{
    [SerializeField]
    private List<AvatarController> Controllers;

    // Method to receive the commands from the VT's dialog Module. 
    public void Feel(Tutor tutor)
    {
        string moodString = getStateString(tutor.Emotion);
        MoodState moodState = getStateType<MoodState>(moodString);
        AvatarController controller = getController(tutor);
        if (controller == null)
            return;

        controller.SetMood(moodState, tutor.Emotion.Intensity);
    }

    private void Feel(string[] parameters)
    {
        Tutor tutor = new Tutor();
        tutor.Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(parameters[0].ToLower());

        //Parse the emotion field of the command
        object emotionEnum;
        if (EnumUtils.TryParse(typeof(EmotionEnum), parameters[1], out emotionEnum))
        {
            //Debug.Log(String.Format("{0} was parsed as a {1} emotion", parameters[1], (EmotionEnum)emotionEnum)); 
            float parsedFloat;
            tutor.Emotion = new Emotion((EmotionEnum)emotionEnum);
            if (float.TryParse(parameters[2], out parsedFloat))
                tutor.Emotion.Intensity = parsedFloat;
            else
            {
                Debug.Log(String.Format("{0} could not be parsed as a float.", parameters[2]));
                return;
            }
            Feel(tutor);
        }        
        else
            Debug.Log(String.Format("{0} is not a reconizable emotion.", parameters[1]));
    }

    public void Express(Tutor tutor, Emotion emotion)
    {
        string expressionString = getStateString(emotion);
        ExpressionState expressionState = getStateType<ExpressionState>(expressionString);
        AvatarController controller = getController(tutor);
        if (controller == null)
            return;

        controller.ExpressEmotion(expressionState);
    }
    private void Express(string[] parameters)
    {
        Tutor tutor = new Tutor();
        tutor.Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(parameters[0].ToLower());

        //Parse the emotion field of the command
        object emotionEnum;
        if (EnumUtils.TryParse(typeof(EmotionEnum), parameters[1], out emotionEnum))
        {
            //Debug.Log(String.Format("{0} was parsed as a {1} emotion", parameters[1], (EmotionEnum)emotionEnum)); 
            float parsedFloat;
            tutor.Emotion = new Emotion((EmotionEnum)emotionEnum);
            if (float.TryParse(parameters[2], out parsedFloat))
                tutor.Emotion.Intensity = parsedFloat;
            else
            {
                Debug.Log(String.Format("{0} could not be parsed as a float.", parameters[2]));
                return;
            }
            Feel(tutor);
        }
        else
            Debug.Log(String.Format("{0} is not a reconizable emotion.", parameters[1]));
    }

    public void Act(Tutor tutor, HeadAction action)
    {
        AvatarController controller = getController(tutor);
        if (controller == null)
            return;

        string actionString = getStateString(action);

        try
        {
            NodState actionState = getStateType<NodState>(actionString);
            controller.DoNodding(actionState);
        }
        catch (ArgumentException)
        {
            try
            {
                TalkState actionState = getStateType<TalkState>(actionString);
                controller.DoTalking(actionState);
                StartCoroutine(React(tutor, actionState));
            }
            catch (ArgumentException)
            {
                try
                {
                    GazeState actionState = getStateType<GazeState>(actionString);
                    controller.DoGazing(actionState);
                }
                catch (ArgumentException ae)
                {
                    Debug.Log(ae.Message);
                }
            }
        }  
    }
    IEnumerator React(Tutor tutor, TalkState actionState)
    {
        float delay = 0.5f;
        yield return new WaitForSeconds(delay);
        if (actionState.Equals(TalkState.TALK))
        {
            AvatarController partnerController = getPartnerController(tutor);
            partnerController.isListening(true);
            partnerController.DoGazing(GazeState.GAZEAT_PARTNER);
        }
        if (actionState.Equals(TalkState.TALK_END))
        {
            AvatarController partnerController = getPartnerController(tutor);
            partnerController.isListening(false);
            partnerController.DoGazing(GazeState.GAZEBACK_PARTNER);
        }
    }

    // public method for receiving tags from other classes
    // Accepts tags in the form of "TutorName_Command_Argument" 
    public void sendRequest(string input)
    {
        //TODO: PROPERLY PROCESS TAGS SO INVALID TAGS, SUCH AS
        //      "maria_gazebat_1.5", ARE NOT ACCEPTED 

        string[] sArray = input.Split('_');

        if (sArray.Length < 3)
        {
            Debug.Log(String.Format("{0} could not be parsed, because it is not a valid tag.", input));
            return;
        }

        CultureInfo culture = CultureInfo.InvariantCulture;

        for (int i = 0; i < sArray.Length; i++)
            sArray[i] = culture.TextInfo.ToTitleCase(sArray[i].ToLower());

        // tag contains a frequency\speed command
        string[] matchStrings = { "frequency", "speed" };
        if (matchStrings.Any(sArray[1].ToLowerInvariant().Contains))
            ChangeAnimationParameters(new Tutor(sArray[0]), sArray[1], float.Parse(sArray[2], culture.NumberFormat));

        //TODO: PROCESS THE REMAINING TAGS
    }

    private void ChangeAnimationParameters(Tutor tutor, string parameter, float value)
    {
        AvatarController controller = getController(tutor);
        if (controller == null)
            return;

        //TODO: PROPERLY PROCESS TAGS SO INVALID TAGS, SUCH AS
        //      "maria_gazebat_1.5", ARE NOT ACCEPTED 

        CultureInfo culture = CultureInfo.InvariantCulture;
        if (culture.CompareInfo.IndexOf(parameter, "speed", CompareOptions.IgnoreCase) >= 0)
            controller.setAnimationSpeed(parameter, value);
        if (culture.CompareInfo.IndexOf(parameter, "frequency", CompareOptions.IgnoreCase) >= 0)
            controller.setAnimationFrequency(parameter, value);
    }

    private AvatarController getController(Tutor tutor)
    {
        foreach (var controller in Controllers)
        {
            if (tutor.Name.Equals(controller.name))
                return controller;
        }
        return null;
    }
    private AvatarController getPartnerController(Tutor tutor)
    {
        foreach (var controller in Controllers)
        {
            if (!tutor.Name.Equals(controller.name))
                return controller;
        }
        return null;
    }

    private string getStateString(IState state) {
        string stateString;

        if (String.IsNullOrEmpty(state.Param1))
            stateString = state.Name.ToUpperInvariant();
        else
            stateString = string.Concat(state.Name.ToUpperInvariant(), "_", state.Param1.Replace(" ", "").ToUpperInvariant());

        return stateString;
    }
    private string getStateString(Emotion emotion)
    {
        return string.Concat(emotion.Name.ToString().ToUpperInvariant());
    }

    private static T getStateType<T>(string stateString)
    {
        try
        {
            T value = (T)Enum.Parse(typeof(T), stateString);
            if (!Enum.IsDefined(typeof(T), value))
            {
                Debug.Log(String.Format("{0} is not an underlying value of the {1} enumeration.", stateString, typeof(T)));
                return default(T);
            }
            else
            {
                //    Debug.Log(String.Format("Converted '{0}' to {1}.", stateString, value.ToString()));
                return value;
            }

        }
        catch (ArgumentException)
        {
            throw new ArgumentException(String.Format("'{0}' is not a member of the {1} enumeration.", stateString, typeof(T)));
        }  
    }

    // Method to receive the commands from the VT's dialog Module. 
    public void sendCommand(string[] input)
    {
        //Parse the "[0]" field of the command
        object parsedEnum;

        if (EnumUtils.TryParse(typeof(ActionGroup), input[0], out parsedEnum))
        {
            //Debug.Log(String.Format("{0} was parsed as a {1} command", input[0], (ActionGroup)parsedEnum));
            switch ((ActionGroup)parsedEnum)
            {
                case ActionGroup.EXPRESS:
                    Express(input.Skip(1).ToArray());
                    break;
                case ActionGroup.FEEL:
                    Feel(input.Skip(1).ToArray());
                    break;
                case ActionGroup.GAZEAT:
                    // Command currently not supported
                    break;
                case ActionGroup.GAZEBACK:
                    // Command currently not supported
                    break;
                case ActionGroup.MOVEEYES:
                    // Command currently not supported
                    break;
                case ActionGroup.NOD:
                    // Command currently not supported
                    break;
                case ActionGroup.TALK:
                    // Command currently not supported
                    break;
                default:
                    break;
            }
        }
        else
            Debug.Log(String.Format("{0} could not be parsed.", input[0]));
    }
}