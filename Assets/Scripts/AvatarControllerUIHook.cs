using System;
using UnityEngine;

public class AvatarControllerUIHook : MonoBehaviour
{

    public delegate void MoodEventHandler(MoodState state);
    public event MoodEventHandler OnMoodChange;

    public delegate void ExpressionEventHandler(ExpressionState state);
    public event ExpressionEventHandler OnExpressionRequest;


    public delegate void GazeEventHandler(GazeState state);
    public event GazeEventHandler OnGazeRequest;

    public void _requestMood(int state)
    {
        if (Enum.IsDefined(typeof(MoodState), state))
        {
            OnMoodChange((MoodState)state);
        } else
        {
            Debug.LogWarning("Selected Mood State doesn't exist.");
        }
    }

    public void _requestExpression(int state)
    {
        if (Enum.IsDefined(typeof(ExpressionState), state))
        {
            OnExpressionRequest((ExpressionState)state);
        }
        else
        {
            Debug.LogWarning("Selected Expression State doesn't exist.");
        }
    }

    public void _requestGaze(int state)
    {
        if (Enum.IsDefined(typeof(GazeState), state))
        {
            OnGazeRequest((GazeState)state);
        }
        else
        {
            Debug.LogWarning("Selected Gaze State doesn't exist.");
        }
    }
}