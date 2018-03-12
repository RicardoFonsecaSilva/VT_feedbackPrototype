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

        private void SetData(Emotion emotion = Emotion.Neutral, float intensity = 0, Reason reason = Reason.Grades, string[] text = null )
        {
            data.emotion = emotion;
            data.intensity = intensity;
            data.reason = reason;
            data.text = text;
        }

        public void UpdateBackground(string tutor, Emotion emotion, float intensity, Reason reason)
        {
            SetData(emotion, intensity, reason);
            backgroundManager.SetBackground(tutor, data);
        }

        public void Speak(string tutor, Emotion emotion, float intensity, string[] text, float duration = 0.0f)
        {
            SetData(emotion, intensity, Reason.None, text);
            balloonManager.ShowBalloon(tutor, data, duration);
        }

        public void HideBalloon(string tutor, float duration = 0.0f)
        {
            balloonManager.HideBalloon(tutor, duration);
        }

        public void UpdateOptions(string[] text, float duration = 0.0f)
        {
            SetData(Emotion.Neutral, 0.0f, Reason.None, text);
            balloonManager.ShowBalloon("Options", data, duration);
        }
    }
}
