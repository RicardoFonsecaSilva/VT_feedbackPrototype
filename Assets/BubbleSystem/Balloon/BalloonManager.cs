using HookControl;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BubbleSystem
{
    public class BalloonManager : MonoBehaviour
    {
        [Serializable]
        public struct Balloon
        {
            public string name;
            public GameObject balloon;
            public bool isPeakTop, isPeakLeft;
        }

        public Balloon[] balloons;
        
        private Dictionary<string, Control> controllers = new Dictionary<string, Control>();
        private Dictionary<string, IEnumerator> hideCoroutines = new Dictionary<string, IEnumerator>();

        private void Start()
        {
            foreach(Balloon balloon in balloons)
            {
                controllers.Add(balloon.name, new Control(balloon.balloon));
                if(balloon.name != "Options")
                    balloon.balloon.GetComponentInChildren<NewBalloonsHooks>().SetPeak(balloon.isPeakTop, balloon.isPeakLeft);
            }
        }

        public void HideBalloon(string tutor, float duration, Effect[] hideEffects, Data data)
        {
            var controller = controllers[tutor];
            try
            {
                var balloonHooks = controller.instance.GetComponentsInChildren<NewBalloonsHooks>();
                foreach (NewBalloonsHooks hooks in balloonHooks)
                {
                    CoroutineStopper.Instance.StopCoroutineWithCheck(hideCoroutines[tutor]);
                    StartCoroutine(Clean(hooks, duration, hideEffects, data));
                }
            }
            catch
            {
                throw new NotSupportedException("Balloon can not disappear, since it does not exist yet.");
            }
        }

        private void SetBeaks(Emotion emotion, GameObject beakObject, Sprite beak)
        {
            beakObject.GetComponent<Image>().sprite = beak;
            beakObject.GetComponent<RectTransform>().anchorMin = DefaultData.Instance.defaultPositions[emotion][beakObject.name].anchorMin;
            beakObject.GetComponent<RectTransform>().anchorMax = DefaultData.Instance.defaultPositions[emotion][beakObject.name].anchorMax;
            beakObject.GetComponent<RectTransform>().localRotation = DefaultData.Instance.defaultPositions[emotion][beakObject.name].localRotation;
        }

        private void SetSprite(Emotion emotion, NewBalloonsHooks hooks, Sprite sprite, Sprite beak)
        {
            if (hooks)
            {
                hooks.GetComponentInChildren<Image>().sprite = sprite;
                SetBeaks(emotion, hooks.peakTopLeft, beak);
                SetBeaks(emotion, hooks.peakBotLeft, beak);
                SetBeaks(emotion, hooks.peakTopRight, beak);
                SetBeaks(emotion, hooks.peakBotRight, beak);
            }
        }

        private void SetSprites(Emotion emotion, NewBalloonsHooks hooks, SpriteData spriteData)
        {
            SetSprite(emotion, hooks, spriteData.sprite, spriteData.beak);
        }

        private void SetAnimator(GameObject hooksTopic, AnimatorOverrideController animator)
        {
            if (hooksTopic)
                hooksTopic.GetComponent<Animator>().runtimeAnimatorController = animator;
        }

        private void SetAnimator(NewBalloonsHooks hooksTopic, RuntimeAnimatorController animator)
        {
            if (hooksTopic)
                hooksTopic.GetComponent<Animator>().runtimeAnimatorController = animator;
        }

        private void SetAnimators(NewBalloonsHooks hooks, BalloonAnimationData animatorData)
        {
            SetAnimator(hooks, animatorData.animator);
        }

        private void SetAnimators(NewBalloonsHooks hooks, DefaultBalloonAnimationData animatorData)
        {
            SetAnimator(hooks, animatorData.animator);
        }

        private void SetEffect(TMP_Text hooksTopicText, Effect[] effects, float intensity, float duration)
        {
            if (hooksTopicText)
            {
                hooksTopicText.GetComponent<Effects>().SetEffect(effects, intensity, duration);
            }
        }

        private void SetEffects(NewBalloonsHooks hooks, Effect[] effects, float intensity, float duration)
        {
            SetEffect(hooks.text, effects, intensity, duration);
        }

        private void SetText(TMP_Text hooksTopicText, TextData textData, BubbleSystem.Emotion emotion)
        {
            if (hooksTopicText)
            {
                hooksTopicText.font = textData.font;
                //hooksTopicText.fontSize = (int)textData.size;
                try
                {
                    hooksTopicText.color = textData.colorData.color;
                }
                catch
                {
                    hooksTopicText.color = DefaultData.Instance.defaultTextData[emotion].colorData.color;
                }
            }
        }

        private void SetTexts(NewBalloonsHooks hooks, TextData textData, BubbleSystem.Emotion emotion)
        {
            SetText(hooks.text, textData, emotion);
        }

        private void SetContent(NewBalloonsHooks hooks, string text)
        {
            hooks.Content = text;
        }

        public void ShowBalloon(string balloon, Data data, float duration, Effect[] showEffects, Effect[] hideEffects)
        {
            var controller = controllers[balloon];

            if (controller.Show() != ShowResult.FAIL)
            {
                var balloonHooks = controller.instance.GetComponentsInChildren<NewBalloonsHooks>();
                int i = 0;

                foreach (NewBalloonsHooks hooks in balloonHooks)
                {
                    if (hooks != null)
                    {
                        float realDuration = DefaultData.Instance.neutralBalloonAnimationData.duration;
                        SetContent(hooks, data.text.Length > i ? data.text[i] : null);

                        try
                        {
                            SpriteData spriteData = DefaultData.Instance.defaultBalloonData[data.emotion];
                            TextData textData = DefaultData.Instance.defaultTextData[data.emotion];
                            if (data.emotion.Equals(Emotion.Neutral))
                            {
                                SetAnimators(hooks, DefaultData.Instance.neutralBalloonAnimationData);
                            }
                            else
                            {
                                realDuration = DefaultData.Instance.balloonAnimationData[data.emotion].duration;
                                SetAnimators(hooks, DefaultData.Instance.balloonAnimationData[data.emotion]);
                            }
                            SetSprites(data.emotion, hooks, spriteData);
                            SetTexts(hooks, textData, data.emotion);

                            realDuration = duration > 0 ? duration : realDuration;

                            if (showEffects != null)
                                SetEffects(hooks, showEffects, data.intensity, realDuration);
                            else
                            {
                                SetEffects(hooks, textData.showEffect.ToArray(), data.intensity, realDuration);
                            }
                        }
                        catch { }

                        hooks.Show();
                        AddCoroutine(balloon, hooks, realDuration, data.intensity, hideEffects, data);
                    }
                    i++;
                }
            }
        }

        public void AddCoroutine(string balloon, NewBalloonsHooks hooks, float duration, float intensity, Effect[] hideEffects, Data data)
        {
            IEnumerator clean = Clean(hooks, duration, hideEffects, data);
            if (hideCoroutines.ContainsKey(balloon))
                hideCoroutines[balloon] = clean;
            else
                hideCoroutines.Add(balloon, clean);
            StartCoroutine(clean);
        }

        IEnumerator Clean(NewBalloonsHooks hooks, float duration, Effect[] hideEffects, Data data)
        {
            yield return new WaitForSeconds(duration);
            if (hooks)
            {
                hooks.Hide();

                if (hideEffects != null)
                {
                    SetEffects(hooks, hideEffects, 10f, 10f);
                }
                else
                {
                    TextData textData = DefaultData.Instance.defaultTextData[data.emotion];
                    SetEffects(hooks, textData.hideEffect.ToArray(), 10f, 10f);
                }
            }
        }
    }
}