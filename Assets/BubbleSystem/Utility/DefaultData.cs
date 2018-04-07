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
    public Dictionary<BubbleSystem.Emotion, SpriteData> defaultBalloonData = new Dictionary<BubbleSystem.Emotion, SpriteData>();
    [HideInInspector]
    public BackgroundAnimationData defaultBackgroundAnimationData;
    [HideInInspector]
    public Dictionary<Reason, TextureData> defaultBackgroundDataDictionary = new Dictionary<Reason, TextureData>();
    [HideInInspector]
    public RuntimeAnimatorController defaultAnimatorController;

    private DefaultData() { }

    private void Awake()
    {
        SetTextData();
        SetBalloonAnimation();
        SetBallon();
        SetBackground();
        SetBackgroundAnimation();
    }

    private void SetTextData()
    {
        TMPro.TMP_FontAsset font = (TMPro.TMP_FontAsset)Resources.Load("Text/TextMesh_Fonts/arial");
        Color color = Color.black;
        float size = 12.0f;
        foreach (BubbleSystem.Emotion emotion in Enum.GetValues(typeof(BubbleSystem.Emotion)))
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
    }

    private void SetBalloonAnimation()
    {
        defaultBalloonAnimationData.animator = (RuntimeAnimatorController)Resources.Load("Balloons/Animators/BallonPopup_v2");
        defaultBalloonAnimationData.duration = 5;
    }

    private void SetBallon()
    {
        var tex = (Texture2D)Resources.Load("Balloons/Images/SpeechBubbles/Neutral/neutral_balloon");
        var beak = (Texture2D)Resources.Load("Balloons/Images/SpeechBubbles/Neutral/neutral_beak");
        SpriteData spriteData = new SpriteData();
        spriteData.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        spriteData.beak = Sprite.Create(beak, new Rect(0.0f, 0.0f, beak.width, beak.height), new Vector2(0.5f, 0.5f), 100.0f);
        spriteData.colorData.color = Color.white;
        defaultBalloonData.Add(BubbleSystem.Emotion.Neutral, spriteData);

        tex = (Texture2D)Resources.Load("Balloons/Images/SpeechBubbles/Happiness/happiness_balloon");
        beak = (Texture2D)Resources.Load("Balloons/Images/SpeechBubbles/Happiness/happiness_beak");
        spriteData = new SpriteData();
        spriteData.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        spriteData.beak = Sprite.Create(beak, new Rect(0.0f, 0.0f, beak.width, beak.height), new Vector2(0.5f, 0.5f), 100.0f);
        spriteData.colorData.color = Color.white;
        defaultBalloonData.Add(BubbleSystem.Emotion.Happiness, spriteData);

        tex = (Texture2D)Resources.Load("Balloons/Images/SpeechBubbles/Sadness/sadness_balloon");
        beak = (Texture2D)Resources.Load("Balloons/Images/SpeechBubbles/Sadness/sadness_beak");
        spriteData = new SpriteData();
        spriteData.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        spriteData.beak = Sprite.Create(beak, new Rect(0.0f, 0.0f, beak.width, beak.height), new Vector2(0.5f, 0.5f), 100.0f);
        spriteData.colorData.color = Color.white;
        defaultBalloonData.Add(BubbleSystem.Emotion.Sadness, spriteData);

        tex = (Texture2D)Resources.Load("Balloons/Images/SpeechBubbles/Anger/anger_balloon");
        beak = (Texture2D)Resources.Load("Balloons/Images/SpeechBubbles/Anger/anger_beak");
        spriteData = new SpriteData();
        spriteData.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        spriteData.beak = Sprite.Create(beak, new Rect(0.0f, 0.0f, beak.width, beak.height), new Vector2(0.5f, 0.5f), 100.0f);
        spriteData.colorData.color = Color.white;
        defaultBalloonData.Add(BubbleSystem.Emotion.Anger, spriteData);

        tex = (Texture2D)Resources.Load("Balloons/Images/SpeechBubbles/Fear/fear_balloon");
        beak = (Texture2D)Resources.Load("Balloons/Images/SpeechBubbles/Fear/fear_beak");
        spriteData = new SpriteData();
        spriteData.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        spriteData.beak = Sprite.Create(beak, new Rect(0.0f, 0.0f, beak.width, beak.height), new Vector2(0.5f, 0.5f), 100.0f);
        spriteData.colorData.color = Color.white;
        defaultBalloonData.Add(BubbleSystem.Emotion.Fear, spriteData);

        tex = (Texture2D)Resources.Load("Balloons/Images/SpeechBubbles/Disgust/disgust_balloon");
        beak = (Texture2D)Resources.Load("Balloons/Images/SpeechBubbles/Disgust/disgust_beak");
        spriteData = new SpriteData();
        spriteData.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        spriteData.beak = Sprite.Create(beak, new Rect(0.0f, 0.0f, beak.width, beak.height), new Vector2(0.5f, 0.5f), 100.0f);
        spriteData.colorData.color = Color.white;
        defaultBalloonData.Add(BubbleSystem.Emotion.Disgust, spriteData);

        tex = (Texture2D)Resources.Load("Balloons/Images/SpeechBubbles/Surprise/surprise_balloon");
        beak = (Texture2D)Resources.Load("Balloons/Images/SpeechBubbles/Surprise/surprise_beak");
        spriteData = new SpriteData();
        spriteData.sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        spriteData.beak = Sprite.Create(beak, new Rect(0.0f, 0.0f, beak.width, beak.height), new Vector2(0.5f, 0.5f), 100.0f);
        spriteData.colorData.color = Color.white;
        defaultBalloonData.Add(BubbleSystem.Emotion.Surprise, spriteData);
    }

    private void SetBackground()
    {
        defaultBackgroundAnimationData.colorTransitionData.duration = 5;
        defaultBackgroundAnimationData.colorTransitionData.smoothness = 0.02f;
        defaultBackgroundAnimationData.imageFadePercentage = 0.5f;
    }

    private void SetBackgroundAnimation()
    {
        TextureData defaultBackgroundData;
        defaultBackgroundData.colorData.color = Color.white;
        defaultBackgroundData.texture = (Texture2D)Resources.Load("Backgrounds/Images/joaoBackground");
        defaultBackgroundDataDictionary.Add(Reason.None, defaultBackgroundData);

        defaultBackgroundData.texture = (Texture2D)Resources.Load("Backgrounds/Images/graph");
        defaultBackgroundDataDictionary.Add(Reason.Grades, defaultBackgroundData);
    }
}
