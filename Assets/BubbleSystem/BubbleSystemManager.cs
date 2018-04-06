using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BubbleSystem
{
    public class BubbleSystemManager : MonoBehaviour
    {
        [SerializeField]
        private BackgroundManager backgroundManager;
        [SerializeField]
        private BalloonManager balloonManager;
        [SerializeField]
        private TextManager textManager;

        private Dictionary<string, Data> tutorData = new Dictionary<string, Data>();

        private void SetData(string tutor, string emotion = "Neutral", float intensity = 0.0f, Reason reason = Reason.Grades, string[] text = null )
        {
            Data data = new Data();
            try
            {
                data.emotion = (Emotion)Enum.Parse(typeof(Emotion), emotion);
            }
            catch
            {
                throw new MissingFieldException("Emotion enum does not contain " + emotion + ".");
            }
            data.intensity = intensity;
            data.reason = reason;
            data.text = text;

            try
            {
                tutorData.Add(tutor, data);
            }
            catch
            {
                tutorData[tutor] = data;
            }
        }

        public void UpdateBackground(string tutor, string emotion, float intensity, Reason reason)
        {
            intensity = Mathf.Clamp01(intensity);
            SetData(tutor, emotion, intensity, reason);
            backgroundManager.SetBackground(tutor, tutorData[tutor]);
        }

        private Effect[] getEffectsArray(string[] effects)
        {
            Effect[] effectsArray = null;
            if (effects != null)
            {
                effectsArray = new Effect[effects.Length];
                for (int i = 0; i < effects.Length; i++)
                {
                    effectsArray[i] = (Effect)Enum.Parse(typeof(Effect), effects[i]);
                }
            }
            //else
            //{
            //    effectsArray = new Effect[1];
            //    effectsArray[0] = (Effect)Enum.Parse(typeof(Effect), "None");
            //}
            return effectsArray;
        }

        public void Speak(string tutor, string emotion, float intensity, string[] text, float duration = 0.0f, string[] showEffects = null, string[] hideEffects = null)
        {
            intensity = Mathf.Clamp01(intensity);
            SetData(tutor, emotion, intensity, Reason.None, text);
            

            balloonManager.ShowBalloon(tutor, tutorData[tutor], duration, getEffectsArray(showEffects), getEffectsArray(hideEffects));
        }

        public void HideBalloon(string tutor, float duration = 0.0f, string[] hideEffects = null)
        {
            if (tutorData.ContainsKey(tutor))
            {
                balloonManager.HideBalloon(tutor, duration, getEffectsArray(hideEffects), tutorData[tutor]);
            }
            else
            {
                throw new KeyNotFoundException("Key " + tutor + " does not exist yet");
            }
        }

        public void UpdateOptions(string[] text, float duration = 0.0f, string[] showEffects = null, string[] hideEffects = null)
        {
            SetData("Options", "Neutral", 0.0f, Reason.None, text);
            balloonManager.ShowBalloon("Options", tutorData["Options"], duration, getEffectsArray(showEffects), getEffectsArray(hideEffects));
        }

    }
}
