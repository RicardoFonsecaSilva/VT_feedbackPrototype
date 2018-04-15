using System;
using System.Collections.Generic;
using UnityEngine;

namespace BubbleSystem
{
    public enum Emotion
    {
        Default,
        Neutral,
        Happiness,
        Sadness,
        Anger,
        Fear,
        Disgust,
        Surprise
    }

    public enum Reason
    {
        None,
        Grades
    }

    public struct TextData
    {
        public TMPro.TMP_FontAsset font;
        public float size;
        public Color32 color;
        public Dictionary<Effect, AnimationCurve> showEffect;
        public Dictionary<Effect, AnimationCurve> hideEffect;
    }

    public struct BackgroundAnimationData
    {
        public Dictionary<BackgroundEffect, AnimationCurve> showBannerEffect;
        public Dictionary<BackgroundEffect, AnimationCurve> hideBannerEffect;
        public Dictionary<BackgroundEffect, AnimationCurve> colorEffect;
    }

    public struct BalloonAnimationData
    {
        public AnimatorOverrideController animator;
        public float duration;
    }

    public struct DefaultBalloonAnimationData
    {
        public RuntimeAnimatorController animator;
        public float duration;
    }

    public struct ColorTransitionData
    {
        public float duration;
        public float smoothness;
    }

    public struct SpriteData
    {
        public Sprite sprite;
        public Sprite beak;
        public Color32 color;
    }

    public struct TextureData
    {
        public Texture2D texture;
        public Color32 color;
    }

    public struct Data
    {
        public Emotion emotion;
        public float intensity;
        public Reason reason;
        //Top, Left, Right, Extra
        public string[] text;
    }
}