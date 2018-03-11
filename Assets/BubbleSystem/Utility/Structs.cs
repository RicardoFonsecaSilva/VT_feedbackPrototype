using System;
using System.Collections.Generic;
using UnityEngine;

namespace BubbleSystem
{
    public enum Emotion
    {
        Default,
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

    public struct ColorData
    {
        public Color color;

        public void SetColor(List<System.Object> list)
        {
            color.r = Convert.ToSingle(list[0]);
            color.g = Convert.ToSingle(list[1]);
            color.b = Convert.ToSingle(list[2]);
            color.a = Convert.ToSingle(list[3]);
        }
    }

    public struct TextData
    {
        public Font font;
        public float size;
        public ColorData colorData;
    }

    public struct BackgroundAnimationData
    {
        public float imageFadePercentage;
        public ColorTransitionData colorTransitionData;
    }

    public struct BalloonAnimationData
    {
        public AnimatorOverrideController animator;
        public float duration;
    }

    public struct DefaultAnimationData
    {
        public UnityEditor.Animations.AnimatorController animator;
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
        public ColorData colorData;
    }

    public struct TextureData
    {
        public Texture2D texture;
        public ColorData colorData;
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