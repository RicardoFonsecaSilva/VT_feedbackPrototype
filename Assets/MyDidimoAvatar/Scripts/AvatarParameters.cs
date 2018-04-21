using System;
using System.Collections.Generic;
using UnityEngine;

enum AnimatorParams
{
    MOOD_INTENSITY = 1,
    EXPRESSION_INTENSITY,
    TALK_SPEED,
    NOD_SPEED,
    GAZEAT_SPEED,
    GAZEBACK_SPEED
}

enum ControllerParams
{
    GAZE_FREQUENCY = 1,
    NOD_FREQUENCY,
}
struct Parameter
{
    public string NAME { get; set; }
    public float VALUE { get; set; }

    public Parameter(string id, float value) : this()
    {
        this.NAME = id;
        this.VALUE = value;
    }
}

[RequireComponent(typeof(Animator))]
public class AvatarParameters : MonoBehaviour
{
    // TODO: DECIDE ON THE BEST WAY TO DEFINE THE MAXIMUM INTERVAL BETWEEN NODS
    [Header("Constants")]
    public float nodInterval = 20.0f;
    public float nodDuration = 3.0f;

    Dictionary<AnimatorParams, Parameter> animParams;
    Dictionary<ControllerParams, Parameter> contParams;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        animParams = new Dictionary<AnimatorParams, Parameter>();
        contParams = new Dictionary<ControllerParams, Parameter>();

        //Animator Parameters
        animParams.Add(AnimatorParams.TALK_SPEED, new Parameter("Talk Speed", 1.0f));
        animParams.Add(AnimatorParams.NOD_SPEED, new Parameter("Nod Speed", 1.0f));
        animParams.Add(AnimatorParams.GAZEAT_SPEED, new Parameter("Gaze At Speed", 1.0f));
        animParams.Add(AnimatorParams.GAZEBACK_SPEED, new Parameter("Gaze Back Speed", 1.0f));
        animParams.Add(AnimatorParams.MOOD_INTENSITY, new Parameter("Mood Intensity", 0.0f));
        
        //Controller Parameters
        contParams.Add(ControllerParams.GAZE_FREQUENCY, new Parameter("Gaze Frequency", 1.0f));
        contParams.Add(ControllerParams.NOD_FREQUENCY, new Parameter("Nod Frequency", 1.0f));  
    }

    public void setParameter<TEnum>(TEnum paramaterKey, float value)
    {
        if (!typeof(TEnum).IsEnum)
            throw new ArgumentException("T must be an enumerated type");

        object key;
        if (EnumUtils.TryParse(typeof(AnimatorParams), paramaterKey.ToString(), out key))
        {
            Parameter auxParam = new Parameter(animParams[(AnimatorParams)key].NAME, value);
            animParams[(AnimatorParams)key] = auxParam;
            animator.SetFloat(auxParam.NAME, auxParam.VALUE);
        }
        else if (EnumUtils.TryParse(typeof(ControllerParams), paramaterKey.ToString(), out key))
            contParams[(ControllerParams)key] = new Parameter(contParams[(ControllerParams)key].NAME, value);
        else
            throw new ArgumentException("Could not parse the parameterKey");       
    }

    public float getParameter<TEnum>(TEnum paramaterKey)
    {
        if (!typeof(TEnum).IsEnum)
            throw new ArgumentException("T must be an enumerated type");

        object key;
        if (EnumUtils.TryParse(typeof(AnimatorParams), paramaterKey.ToString(), out key))
            return animParams[(AnimatorParams)key].VALUE;
        else if (EnumUtils.TryParse(typeof(ControllerParams), paramaterKey.ToString(), out key))
            return contParams[(ControllerParams)key].VALUE;
        else
            throw new ArgumentException("Could not parse the parameterKey");
    }

    public void setAllParameters<TEnum>(float[] paramValue) where TEnum : struct, IConvertible
    {
        int paramSize = paramValue.Length, i = 0;

        if (!typeof(TEnum).IsEnum)
            throw new ArgumentException("T must be an enumerated type");

        Array enumArray = EnumUtils.AsArray<TEnum>();

        if (enumArray.Length > paramSize)
            throw new ArgumentException("Not enough values to fill all the parameter values");

        foreach (TEnum paramaterKey in enumArray)
        {
            object key;
            if(EnumUtils.TryParse(typeof(AnimatorParams), paramaterKey.ToString(), out key))
            {
                if (((AnimatorParams)key).Equals(AnimatorParams.EXPRESSION_INTENSITY) ||
                    ((AnimatorParams)key).Equals(AnimatorParams.MOOD_INTENSITY))
                {
                    i++; continue;
                }  
            }
            setParameter(paramaterKey, paramValue[i++]);
        }     
    }

    public static class Presets
    {    
        // element order:
        // 
        //  animator parameters
        //  {
        //      mood_intensity
        //      expression_intensity
        //      talk_speed
        //      nod_speed
        //      gazeat_speed
        //      gazeback_speed
        //  }
        //  controller parameters
        //  {
        //      gaze_frequency
        //      nod_frequency
        //  }
        public static float[][] Neutral()
        {
            return new float[][]
            {
                new float[] {-1.00f, -1.00f,  1.00f,  1.00f,  1.00f,  1.00f},
                new float[] { 0.75f,  1.00f}
            };
        }
        public static float[][] Happiness()
        {
            return new float[][]
            {
                new float[] { 0.50f,  1.00f,  1.50f,  1.50f,  1.20f,  1.50f},
                new float[] { 0.75f,  1.00f}
            };
        }
        public static float[][] HappinessHigh()
        {
            return new float[][]
            {
                new float[] {-1.00f, -1.00f,  2.00f,  2.00f,  1.50f,  1.20f},
                new float[] { 0.9f,  1.00f}
            };
        }
        public static float[][] Sadness()
        {
            return new float[][]
            {
                new float[] {-1.00f, -1.00f,  1.00f,  1.00f,  0.75f,  0.75f},
                new float[] { 0.50f,  0.50f}
            };
        }
        public static float[][] SadnessHigh()
        {
            return new float[][]
            {
                new float[] {-1.00f, -1.00f,  1.00f,  1.00f,  1.00f,  1.00f},
                new float[] { 0.75f,  1.00f}
            };
        }
        //TODO: ADD DEFAULT VALUES
        public static float[][] Fear()
        {
            return new float[][]
            {
                new float[] {-1.00f, -1.00f,  1.50f,  0.75f,  1.00f,  1.00f},
                new float[] { 0.75f,  1.00f}
            };
        }
        //TODO: ADD DEFAULT VALUES
        public static float[][] Surprise()
        {
            return new float[][]
            {
                new float[] {-1.00f, -1.00f,  1.00f,  1.00f,  1.00f,  1.00f},
                new float[] { 0.75f,  1.00f}
            };
        }
    }

    /// <summary>
    /// CURRENTY UNUSED CODE. 
    /// PLANNED AS A MEANS TO HAVE THE PARAMETERS AS ATTRIBUTES FOR QUICK ACCESS
    /// AND EDIT IN THE UNITY EDITOR.
    /// </summary>
    [Serializable]
    public class ParameterSet
    {
        [Header("Animator Parameters")]
        public float moodIntensity;
        public float moodIntensity2;
        public float moodIntensity3;
        public float moodIntensity4;
        [Space(2.0f)]
        [Header("X Parameters")]
        public float SXV;
        public float WDAWFWA;
    }
}