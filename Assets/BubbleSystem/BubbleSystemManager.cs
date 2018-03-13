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

        private Data data = new Data();
        private Emotion defaultEmotion = new Emotion();

        private void SetData(Emotion emotion, Reason reason = Reason.Grades, string[] text = null )
        {
            data.emotion = emotion.Name;
            data.intensity = emotion.Intensity;
            data.reason = reason;
            data.text = text;
        }

        public void UpdateBackground(string tutor, Emotion emotion, Reason reason)
        {
            SetData(emotion, reason);
            backgroundManager.SetBackground(tutor, data);
        }

        public void Speak(string tutor, Emotion emotion, string[] text, float duration = 0.0f)
        {
            SetData(emotion, Reason.None, text);
            balloonManager.ShowBalloon(tutor, data, duration);
        }

        public void HideBalloon(string tutor, float duration = 0.0f)
        {
            balloonManager.HideBalloon(tutor, duration);
        }

        public void UpdateOptions(string[] text, float duration = 0.0f)
        {
            defaultEmotion.Name = EmotionEnum.Neutral;
            defaultEmotion.Intensity = 0.0f;
            SetData(defaultEmotion, Reason.None, text);
            balloonManager.ShowBalloon("Options", data, duration);
        }
    }
}
