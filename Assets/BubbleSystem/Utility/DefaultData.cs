using BubbleSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultData : Singleton<DefaultData> {

    [HideInInspector]
    public Dictionary<BubbleSystem.Emotion, TextData> defaultTextData = new Dictionary<BubbleSystem.Emotion, TextData>();
    [HideInInspector]
    public DefaultBalloonAnimationData neutralBalloonAnimationData;
    [HideInInspector]
    public Dictionary<BubbleSystem.Emotion, BalloonAnimationData> balloonAnimationData = new Dictionary<BubbleSystem.Emotion, BalloonAnimationData>();
    [HideInInspector]
    public Dictionary<BubbleSystem.Emotion, SpriteData> defaultBalloonData = new Dictionary<BubbleSystem.Emotion, SpriteData>();
    [HideInInspector]
    public Dictionary<BubbleSystem.Emotion, BackgroundAnimationData> defaultBackgroundAnimationData = new Dictionary<BubbleSystem.Emotion, BackgroundAnimationData>();
    [HideInInspector]
    public Dictionary<BubbleSystem.Emotion, Dictionary<Reason, TextureData>> defaultBackgroundDataDictionary = new Dictionary<BubbleSystem.Emotion, Dictionary<Reason, TextureData>>();

    [HideInInspector]
    public Dictionary<BubbleSystem.Emotion, Dictionary<string, PositionData> > defaultPositions = new Dictionary<BubbleSystem.Emotion, Dictionary<string, PositionData> >();

    public Color blushColor = Color.red;
    public AnimationCurve bellCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.5f, 1.0f), new Keyframe(1.0f, 0));
    public AnimationCurve fadeCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));
    public AnimationCurve flashCurve = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(1f, 1f), new Keyframe(2f, 0f), new Keyframe(3f, 0f), new Keyframe(4f, 1f), new Keyframe(5f, 1f), new Keyframe(6f, 0f));
    public AnimationCurve lowerBellCurve = new AnimationCurve(new Keyframe(0f, -0.25f), new Keyframe(1f, 0.25f), new Keyframe(2f, -0.25f));
    public AnimationCurve palpitationCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f), new Keyframe(1.5f, 1f), new Keyframe(2f, 0f), new Keyframe(3f, 0f));

    public struct PositionData
    {
        public Vector2 anchorMin;
        public Vector2 anchorMax;
        public Quaternion localRotation;
    }

    private DefaultData() { }

    private void Awake()
    {
        SetTextData();
        SetBalloonAnimation();
        SetBallon();
        SetBackground();
        SetBackgroundAnimation();
        SetBalloonPositions();
    }

    public AnimationCurve GetCurve(string name)
    {
        switch (name){
            case "bellCurve":
                return bellCurve;
            case "fadeCurve":
                return fadeCurve;
            case "flashCurve":
                return flashCurve;
            case "jitterCurve":
                return lowerBellCurve;
            case "lowerBellCurve":
                return palpitationCurve;
        }
        throw new KeyNotFoundException("Animation Curve with name " + name + " does not exist.");
    }

    private void SetBalloonPositions()
    {
        Dictionary<string, PositionData> neutralPositions = new Dictionary<string, PositionData>();
        Dictionary<string, PositionData> happinessPositions = new Dictionary<string, PositionData>();
        Dictionary<string, PositionData> sadnessPositions = new Dictionary<string, PositionData>();
        Dictionary<string, PositionData> angerPositions = new Dictionary<string, PositionData>();
        Dictionary<string, PositionData> fearPositions = new Dictionary<string, PositionData>();
        Dictionary<string, PositionData> disgustPositions = new Dictionary<string, PositionData>();
        Dictionary<string, PositionData> surprisePositions = new Dictionary<string, PositionData>();

        PositionData rect = new PositionData();

        //NEUTRAL

        rect.anchorMin = new Vector2(0.6f, 0.91f);
        rect.anchorMax = new Vector2(0.8f, 1.35f);
        rect.localRotation = Quaternion.Euler(0, 180, 180);
        neutralPositions.Add("Peak_top_right", rect);

        rect.anchorMin = new Vector2(0.2f, 0.91f);
        rect.anchorMax = new Vector2(0.4f, 1.35f);
        rect.localRotation = Quaternion.Euler(0, 0, 180);
        neutralPositions.Add("Peak_top_left", rect);

        rect.anchorMin = new Vector2(0.65f, -0.38f);
        rect.anchorMax = new Vector2(0.8f, 0.1f);
        rect.localRotation = Quaternion.Euler(0, 0, 0);
        neutralPositions.Add("Peak_bot_right", rect);

        rect.anchorMin = new Vector2(0.2f, -0.38f);
        rect.anchorMax = new Vector2(0.4f, 0.1f);
        rect.localRotation = Quaternion.Euler(0, 180, 0);
        neutralPositions.Add("Peak_bot_left", rect);

        defaultPositions.Add(BubbleSystem.Emotion.Neutral, neutralPositions);


        //HAPPINESS

        rect.anchorMin = new Vector2(0.6f, 0.81f);
        rect.anchorMax = new Vector2(0.8f, 1.25f);
        rect.localRotation = Quaternion.Euler(0, 40, 190);
        happinessPositions.Add("Peak_top_right", rect);

        rect.anchorMin = new Vector2(0.2f, 0.81f);
        rect.anchorMax = new Vector2(0.4f, 1.25f);
        rect.localRotation = Quaternion.Euler(0, 180, 190);
        happinessPositions.Add("Peak_top_left", rect);

        rect.anchorMin = new Vector2(0.65f, -0.28f);
        rect.anchorMax = new Vector2(0.8f, 0.2f);
        rect.localRotation = Quaternion.Euler(0, 180, 10);
        happinessPositions.Add("Peak_bot_right", rect);

        rect.anchorMin = new Vector2(0.2f, -0.28f);
        rect.anchorMax = new Vector2(0.4f, 0.2f);
        rect.localRotation = Quaternion.Euler(0, 0, 10);
        happinessPositions.Add("Peak_bot_left", rect);

        defaultPositions.Add(BubbleSystem.Emotion.Happiness, happinessPositions);


        //SADNESS

        rect.anchorMin = new Vector2(0.6f, 0.86f);
        rect.anchorMax = new Vector2(0.8f, 1.3f);
        rect.localRotation = Quaternion.Euler(0, 0, 180);
        sadnessPositions.Add("Peak_top_right", rect);

        rect.anchorMin = new Vector2(0.2f, 0.86f);
        rect.anchorMax = new Vector2(0.4f, 1.3f);
        rect.localRotation = Quaternion.Euler(0, 180, 180);
        sadnessPositions.Add("Peak_top_left", rect);

        rect.anchorMin = new Vector2(0.65f, -0.28f);
        rect.anchorMax = new Vector2(0.8f, 0.2f);
        rect.localRotation = Quaternion.Euler(0, 180, 10);
        sadnessPositions.Add("Peak_bot_right", rect);

        rect.anchorMin = new Vector2(0.2f, -0.28f);
        rect.anchorMax = new Vector2(0.4f, 0.2f);
        rect.localRotation = Quaternion.Euler(0, 0, 0);
        sadnessPositions.Add("Peak_bot_left", rect);

        defaultPositions.Add(BubbleSystem.Emotion.Sadness, sadnessPositions);


        //ANGER

        rect.anchorMin = new Vector2(0.6f, 0.71f);
        rect.anchorMax = new Vector2(0.8f, 1.15f);
        rect.localRotation = Quaternion.Euler(0, 180, 170);
        angerPositions.Add("Peak_top_right", rect);

        rect.anchorMin = new Vector2(0.2f, 0.61f);
        rect.anchorMax = new Vector2(0.4f, 1.05f);
        rect.localRotation = Quaternion.Euler(0, 180, 170);
        angerPositions.Add("Peak_top_left", rect);

        rect.anchorMin = new Vector2(0.65f, -0.08f);
        rect.anchorMax = new Vector2(0.8f, 0.4f);
        rect.localRotation = Quaternion.Euler(0, 0, -5);
        angerPositions.Add("Peak_bot_right", rect);

        rect.anchorMin = new Vector2(0.2f, -0.08f);
        rect.anchorMax = new Vector2(0.4f, 0.4f);
        rect.localRotation = Quaternion.Euler(0, 180, 0);
        angerPositions.Add("Peak_bot_left", rect);

        defaultPositions.Add(BubbleSystem.Emotion.Anger, angerPositions);


        //FEAR

        rect.anchorMin = new Vector2(0.65f, 0.71f);
        rect.anchorMax = new Vector2(0.8f, 1.25f);
        rect.localRotation = Quaternion.Euler(0, 0, 180);
        fearPositions.Add("Peak_top_right", rect);

        rect.anchorMin = new Vector2(0.25f, 0.81f);
        rect.anchorMax = new Vector2(0.4f, 1.35f);
        rect.localRotation = Quaternion.Euler(0, 180, 180);
        fearPositions.Add("Peak_top_left", rect);

        rect.anchorMin = new Vector2(0.65f, -0.28f);
        rect.anchorMax = new Vector2(0.8f, 0.2f);
        rect.localRotation = Quaternion.Euler(0, 180, 0);
        fearPositions.Add("Peak_bot_right", rect);

        rect.anchorMin = new Vector2(0.25f, -0.3f);
        rect.anchorMax = new Vector2(0.4f, 0.25f);
        rect.localRotation = Quaternion.Euler(0, 0, 0);
        fearPositions.Add("Peak_bot_left", rect);

        defaultPositions.Add(BubbleSystem.Emotion.Fear, fearPositions);


        //DISGUST

        rect.anchorMin = new Vector2(0.65f, 0.71f);
        rect.anchorMax = new Vector2(0.85f, 1.55f);
        rect.localRotation = Quaternion.Euler(0, 0, 180);
        disgustPositions.Add("Peak_top_right", rect);

        rect.anchorMin = new Vector2(0.15f, 0.71f);
        rect.anchorMax = new Vector2(0.35f, 1.55f);
        rect.localRotation = Quaternion.Euler(0, 180, 180);
        disgustPositions.Add("Peak_top_left", rect);

        rect.anchorMin = new Vector2(0.65f, -0.48f);
        rect.anchorMax = new Vector2(0.85f, 0.3f);
        rect.localRotation = Quaternion.Euler(0, 180, 0);
        disgustPositions.Add("Peak_bot_right", rect);

        rect.anchorMin = new Vector2(0.15f, -0.48f);
        rect.anchorMax = new Vector2(0.35f, 0.3f);
        rect.localRotation = Quaternion.Euler(0, 0, 0);
        disgustPositions.Add("Peak_bot_left", rect);

        defaultPositions.Add(BubbleSystem.Emotion.Disgust, disgustPositions);


        //SURPRISE

        rect.anchorMin = new Vector2(0.6f, 0.66f);
        rect.anchorMax = new Vector2(0.8f, 1.2f);
        rect.localRotation = Quaternion.Euler(0, 180, 180);
        surprisePositions.Add("Peak_top_right", rect);

        rect.anchorMin = new Vector2(0.2f, 0.66f);
        rect.anchorMax = new Vector2(0.4f, 1.2f);
        rect.localRotation = Quaternion.Euler(0, 0, 180);
        surprisePositions.Add("Peak_top_left", rect);

        rect.anchorMin = new Vector2(0.65f, -0.18f);
        rect.anchorMax = new Vector2(0.8f, 0.3f);
        rect.localRotation = Quaternion.Euler(0, 0, 0);
        surprisePositions.Add("Peak_bot_right", rect);

        rect.anchorMin = new Vector2(0.2f, -0.23f);
        rect.anchorMax = new Vector2(0.4f, 0.35f);
        rect.localRotation = Quaternion.Euler(0, 180, 0);
        surprisePositions.Add("Peak_bot_left", rect);

        defaultPositions.Add(BubbleSystem.Emotion.Surprise, surprisePositions);
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
            text.showEffect = new Dictionary<Effect, AnimationCurve>();
            text.hideEffect = new Dictionary<Effect, AnimationCurve>();
            defaultTextData.Add(emotion, text);
        }

        defaultTextData[BubbleSystem.Emotion.Neutral].showEffect.Add(Effect.FadeIn, fadeCurve);
        defaultTextData[BubbleSystem.Emotion.Neutral].hideEffect.Add(Effect.FadeOut, fadeCurve);

        defaultTextData[BubbleSystem.Emotion.Happiness].showEffect.Add(Effect.Wave, bellCurve);
        defaultTextData[BubbleSystem.Emotion.Happiness].hideEffect.Add(Effect.Wave, bellCurve);

        defaultTextData[BubbleSystem.Emotion.Sadness].showEffect.Add(Effect.FadeIn, fadeCurve);
        defaultTextData[BubbleSystem.Emotion.Sadness].hideEffect.Add(Effect.FadeOut, fadeCurve);

        defaultTextData[BubbleSystem.Emotion.Anger].showEffect.Add(Effect.FadeIn, fadeCurve);
        defaultTextData[BubbleSystem.Emotion.Anger].hideEffect.Add(Effect.FadeOut, fadeCurve);

        defaultTextData[BubbleSystem.Emotion.Fear].showEffect.Add(Effect.FadeIn, fadeCurve);
        defaultTextData[BubbleSystem.Emotion.Fear].hideEffect.Add(Effect.FadeOut, fadeCurve);

        defaultTextData[BubbleSystem.Emotion.Disgust].showEffect.Add(Effect.FadeIn, fadeCurve);
        defaultTextData[BubbleSystem.Emotion.Disgust].hideEffect.Add(Effect.FadeOut, fadeCurve);

        defaultTextData[BubbleSystem.Emotion.Surprise].showEffect.Add(Effect.FadeIn, fadeCurve);
        defaultTextData[BubbleSystem.Emotion.Surprise].hideEffect.Add(Effect.FadeOut, fadeCurve);
    }

    private void SetBalloonAnimation()
    {
        neutralBalloonAnimationData.animator = (RuntimeAnimatorController)Resources.Load("Balloons/Animators/BallonPopup_v2");
        neutralBalloonAnimationData.duration = 5;

        BalloonAnimationData balloon = new BalloonAnimationData();
        balloon.animator = (AnimatorOverrideController)Resources.Load("Balloons/Animators/HappyAnimator");
        balloon.duration = 5;
        balloonAnimationData.Add(BubbleSystem.Emotion.Happiness, balloon);

        balloon = new BalloonAnimationData();
        balloon.animator = (AnimatorOverrideController)Resources.Load("Balloons/Animators/SadAnimator");
        balloon.duration = 5;
        balloonAnimationData.Add(BubbleSystem.Emotion.Sadness, balloon);

        balloon = new BalloonAnimationData();
        balloon.animator = (AnimatorOverrideController)Resources.Load("Balloons/Animators/AngerAnimator");
        balloon.duration = 5;
        balloonAnimationData.Add(BubbleSystem.Emotion.Anger, balloon);

        balloon = new BalloonAnimationData();
        balloon.animator = (AnimatorOverrideController)Resources.Load("Balloons/Animators/FearAnimator");
        balloon.duration = 5;
        balloonAnimationData.Add(BubbleSystem.Emotion.Fear, balloon);

        balloon = new BalloonAnimationData();
        balloon.animator = (AnimatorOverrideController)Resources.Load("Balloons/Animators/DisgustAnimator");
        balloon.duration = 5;
        balloonAnimationData.Add(BubbleSystem.Emotion.Disgust, balloon);

        balloon = new BalloonAnimationData();
        balloon.animator = (AnimatorOverrideController)Resources.Load("Balloons/Animators/SurpriseAnimator");
        balloon.duration = 5;
        balloonAnimationData.Add(BubbleSystem.Emotion.Surprise, balloon);


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
        BackgroundAnimationData backgroundData = new BackgroundAnimationData();

        backgroundData.bannerEffect = new Dictionary<BackgroundEffect, AnimationCurve>();
        backgroundData.colorEffect = new Dictionary<BackgroundEffect, AnimationCurve>();

        backgroundData.bannerEffect.Add(BackgroundEffect.Fade, fadeCurve);
        backgroundData.colorEffect.Add(BackgroundEffect.Fade, fadeCurve);

        defaultBackgroundAnimationData.Add(BubbleSystem.Emotion.Neutral, backgroundData);
        defaultBackgroundAnimationData.Add(BubbleSystem.Emotion.Happiness, backgroundData);
        defaultBackgroundAnimationData.Add(BubbleSystem.Emotion.Sadness, backgroundData);
        defaultBackgroundAnimationData.Add(BubbleSystem.Emotion.Anger, backgroundData);
        defaultBackgroundAnimationData.Add(BubbleSystem.Emotion.Fear, backgroundData);
        defaultBackgroundAnimationData.Add(BubbleSystem.Emotion.Disgust, backgroundData);
        defaultBackgroundAnimationData.Add(BubbleSystem.Emotion.Surprise, backgroundData);
    }

    private void SetBackgroundAnimation()
    {
        TextureData defaultBackgroundData;
        Dictionary<Reason, TextureData> neutralDict = new Dictionary<Reason, TextureData>();
        Dictionary<Reason, TextureData> happinessDict = new Dictionary<Reason, TextureData>();
        Dictionary<Reason, TextureData> sadnessDict = new Dictionary<Reason, TextureData>();
        Dictionary<Reason, TextureData> angerDict = new Dictionary<Reason, TextureData>();
        Dictionary<Reason, TextureData> fearDict = new Dictionary<Reason, TextureData>();
        Dictionary<Reason, TextureData> disgustDict = new Dictionary<Reason, TextureData>();
        Dictionary<Reason, TextureData> surpriseDict = new Dictionary<Reason, TextureData>();

        
        defaultBackgroundData.texture = (Texture2D)Resources.Load("Backgrounds/Images/joaoBackground");
        defaultBackgroundData.colorData.color = Color.white;
        neutralDict.Add(Reason.None, defaultBackgroundData);
        defaultBackgroundData.colorData.color = Color.yellow;
        happinessDict.Add(Reason.None, defaultBackgroundData);
        defaultBackgroundData.colorData.color = Color.blue;
        sadnessDict.Add(Reason.None, defaultBackgroundData);
        defaultBackgroundData.colorData.color = Color.red;
        angerDict.Add(Reason.None, defaultBackgroundData);
        defaultBackgroundData.colorData.color = Color.grey;
        fearDict.Add(Reason.None, defaultBackgroundData);
        defaultBackgroundData.colorData.color = Color.green;
        disgustDict.Add(Reason.None, defaultBackgroundData);
        defaultBackgroundData.colorData.color = Color.cyan;
        surpriseDict.Add(Reason.None, defaultBackgroundData);

        defaultBackgroundData.texture = (Texture2D)Resources.Load("Backgrounds/Images/graph");
        defaultBackgroundData.colorData.color = Color.white;
        neutralDict.Add(Reason.Grades, defaultBackgroundData);
        defaultBackgroundData.colorData.color = Color.yellow;
        happinessDict.Add(Reason.Grades, defaultBackgroundData);
        defaultBackgroundData.colorData.color = Color.blue;
        sadnessDict.Add(Reason.Grades, defaultBackgroundData);
        defaultBackgroundData.colorData.color = Color.red;
        angerDict.Add(Reason.Grades, defaultBackgroundData);
        defaultBackgroundData.colorData.color = Color.grey;
        fearDict.Add(Reason.Grades, defaultBackgroundData);
        defaultBackgroundData.colorData.color = Color.green;
        disgustDict.Add(Reason.Grades, defaultBackgroundData);
        defaultBackgroundData.colorData.color = Color.cyan;
        surpriseDict.Add(Reason.Grades, defaultBackgroundData);

        defaultBackgroundDataDictionary.Add(BubbleSystem.Emotion.Neutral, neutralDict);
        defaultBackgroundDataDictionary.Add(BubbleSystem.Emotion.Happiness, happinessDict);
        defaultBackgroundDataDictionary.Add(BubbleSystem.Emotion.Sadness, sadnessDict);
        defaultBackgroundDataDictionary.Add(BubbleSystem.Emotion.Anger, angerDict);
        defaultBackgroundDataDictionary.Add(BubbleSystem.Emotion.Fear, fearDict);
        defaultBackgroundDataDictionary.Add(BubbleSystem.Emotion.Disgust, disgustDict);
        defaultBackgroundDataDictionary.Add(BubbleSystem.Emotion.Surprise, surpriseDict);
    }
}
