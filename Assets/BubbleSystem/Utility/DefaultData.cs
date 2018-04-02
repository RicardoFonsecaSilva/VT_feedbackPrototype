using BubbleSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultData : Singleton<DefaultData> {

    [HideInInspector]
    public Dictionary<BubbleSystem.Emotion, TextData> defaultTextData = new Dictionary<BubbleSystem.Emotion, TextData>();
    [HideInInspector]
    public DefaultBalloonAnimationData defaultBalloonAnimationData;
    [HideInInspector]
    public SpriteData defaultBalloonData;
    [HideInInspector]
    public BackgroundAnimationData defaultBackgroundAnimationData;
    [HideInInspector]
    public Dictionary<Reason, TextureData> defaultBackgroundDataDictionary = new Dictionary<Reason, TextureData>();
    [HideInInspector]
    public RuntimeAnimatorController defaultAnimatorController;

    private DefaultData() { }

    private void Awake()
    {
        TMPro.TMP_FontAsset font = (TMPro.TMP_FontAsset)Resources.Load("Text/TextMesh_Fonts/arial");
        Color color = Color.black;
        float size = 12.0f;
        foreach(BubbleSystem.Emotion emotion in Enum.GetValues(typeof(BubbleSystem.Emotion)))
        {
            TextData text = new TextData();
            text.font = font;
            text.colorData.color = color;
            text.size = size;
            text.showEffect = new List<Effect>();
            text.hideEffect = new List<Effect>();
            defaultTextData.Add(emotion, text);
        }
        defaultTextData[BubbleSystem.Emotion.Happiness].showEffect.Add(Effect.Wave);
        defaultTextData[BubbleSystem.Emotion.Happiness].hideEffect.Add(Effect.Wave);

        defaultTextData[BubbleSystem.Emotion.Sadness].showEffect.Add(Effect.FadeIn);
        defaultTextData[BubbleSystem.Emotion.Sadness].hideEffect.Add(Effect.FadeOut);

        defaultBalloonAnimationData.animator = (RuntimeAnimatorController)Resources.Load("Balloons/Animators/BallonPopup_v2");
        defaultBalloonAnimationData.duration = 5;

        var tex = (Texture2D)Resources.Load("Balloons/Images/SpeechBubbles/Default/balloon");
        defaultBalloonData.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        defaultBalloonData.colorData.color = Color.white;

        defaultBackgroundAnimationData.colorTransitionData.duration = 5;
        defaultBackgroundAnimationData.colorTransitionData.smoothness = 0.02f;
        defaultBackgroundAnimationData.imageFadePercentage = 0.5f;

        TextureData defaultBackgroundData;
        defaultBackgroundData.colorData.color = Color.white;
        defaultBackgroundData.texture = (Texture2D)Resources.Load("Backgrounds/Images/joaoBackground");
        defaultBackgroundDataDictionary.Add(Reason.None, defaultBackgroundData);

        defaultBackgroundData.texture = (Texture2D)Resources.Load("Backgrounds/Images/graph");
        defaultBackgroundDataDictionary.Add(Reason.Grades, defaultBackgroundData);
    }
}
