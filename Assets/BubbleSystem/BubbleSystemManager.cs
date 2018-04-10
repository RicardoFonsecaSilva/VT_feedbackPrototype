using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BubbleSystem
{
    public class BubbleSystemManager : MonoBehaviour
    {
        private BackgroundManager backgroundManager;
        private BalloonManager balloonManager;

        private Dictionary<string, Data> tutorData = new Dictionary<string, Data>();

        private void Start()
        {
            backgroundManager = GetComponent<BackgroundManager>();
            balloonManager = GetComponent<BalloonManager>();
        }

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

        private Dictionary<Effect, AnimationCurve> getEffectsDictionary(Dictionary<string, string> effects)
        {
            Dictionary<Effect, AnimationCurve> effectsDictionary = null;
            if (effects != null)
            {
                foreach (string fx in effects.Keys)
                {
                    Effect effect = (Effect)Enum.Parse(typeof(Effect), fx);
                    AnimationCurve curve = DefaultData.Instance.GetCurve(effects[fx]);
                    effectsDictionary.Add(effect, curve);
                }
                return effectsDictionary;
            }
            return null;
        }

        public void Speak(string tutor, string emotion, float intensity, string[] text, float duration = 0.0f, Dictionary<string, string> showEffects = null, Dictionary<string, string> hideEffects = null)
        {
            intensity = Mathf.Clamp01(intensity);
            SetData(tutor, emotion, intensity, Reason.None, text);
            

            balloonManager.ShowBalloon(tutor, tutorData[tutor], duration, getEffectsDictionary(showEffects), getEffectsDictionary(hideEffects));
        }

        public void HideBalloon(string tutor, float duration = 0.0f, Dictionary<string, string> hideEffects = null)
        {
            if (tutorData.ContainsKey(tutor))
            {
                balloonManager.HideBalloon(tutor, duration, getEffectsDictionary(hideEffects), tutorData[tutor]);
            }
            else
            {
                throw new KeyNotFoundException("Key " + tutor + " does not exist yet");
            }
        }

        public void UpdateOptions(string[] text, float duration = 0.0f, Dictionary<string, string> showEffects = null, Dictionary<string, string> hideEffects = null)
        {
            SetData("Options", "Neutral", 0.0f, Reason.None, text);
            balloonManager.ShowBalloon("Options", tutorData["Options"], duration, getEffectsDictionary(showEffects), getEffectsDictionary(hideEffects));
        }

    }
}
