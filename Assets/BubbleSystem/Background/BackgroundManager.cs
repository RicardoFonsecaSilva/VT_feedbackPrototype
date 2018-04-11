using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BubbleSystem
{

    public enum BackgroundEffect
    {
        Fade
    }

    public class BackgroundManager : MonoBehaviour
    {
        [Serializable]
        public struct Background
        {
            public string name;
            public GameObject background;
        }

        public Background[] backgrounds;

        private new Renderer renderer;

        private Dictionary<string, IEnumerator> textureCoroutines = new Dictionary<string, IEnumerator>();
        private Dictionary<string, IEnumerator> colorCoroutines = new Dictionary<string, IEnumerator>();

        public void SetBackground(string bg, Data data, float duration)
        {
            TextureData textureData = DefaultData.Instance.defaultBackgroundDataDictionary[data.emotion][data.reason];
            BackgroundAnimationData backgroundAnimationData = DefaultData.Instance.defaultBackgroundAnimationData[data.emotion];
            renderer = GetBackground(bg).GetComponent<Renderer>();
            StartCoroutine(ChangeImage(bg, renderer, textureData, backgroundAnimationData, duration));
        }

        private GameObject GetBackground(string bg)
        {
            foreach (Background b in backgrounds)
            {
                if (b.name.Equals(bg))
                {
                    return b.background;
                }
            }

            throw new KeyNotFoundException("Background with name: " + bg + " not found.");
        }
        
        private IEnumerator ChangeImage(string bg, Renderer renderer, TextureData textureData, BackgroundAnimationData backgroundAnimationData, float duration)
        {
            if (textureCoroutines.ContainsKey(bg))
                CoroutineStopper.Instance.StopCoroutineWithCheck(textureCoroutines[bg]);
            if (colorCoroutines.ContainsKey(bg))
                CoroutineStopper.Instance.StopCoroutineWithCheck(colorCoroutines[bg]);

            foreach (BackgroundEffect fx in backgroundAnimationData.bannerEffect.Keys) {
                if (fx == BackgroundEffect.Fade)
                    textureCoroutines[bg] = FadeTexture(renderer, textureData.texture, backgroundAnimationData.bannerEffect[fx], duration * 2 / 3);
                yield return StartCoroutine(textureCoroutines[bg]);
            }

            foreach (BackgroundEffect fx in backgroundAnimationData.colorEffect.Keys)
            {
                if (fx == BackgroundEffect.Fade)
                    colorCoroutines[bg] = LerpColor(renderer, textureData.colorData.color, backgroundAnimationData.colorEffect[fx], duration / 3);
                yield return StartCoroutine(colorCoroutines[bg]);
            }
        }

        private IEnumerator FadeTexture(Renderer renderer, Texture nextTexture, AnimationCurve curve, float duration)
        {
            float initialAlpha = renderer.material.color.a;

            yield return StartCoroutine(FadeOutTexture(renderer, curve, duration / 2));
            renderer.material.mainTexture = nextTexture;
            renderer.material.mainTexture.wrapMode = TextureWrapMode.Mirror;
            yield return StartCoroutine(FadeInTexture(renderer, curve, duration / 2, initialAlpha));
        }

        private IEnumerator FadeOutTexture(Renderer renderer, AnimationCurve curve, float duration, float wantedAlpha = 0)
        {
            float finalAlpha;
            float initialAlpha = renderer.material.color.a;
            Color finalColor = renderer.material.color;

            float initialTime = Time.time;
            Keyframe lastframe = curve[curve.length - 1];
            float lastKeyTime = lastframe.time;
            float yValue;

            while (((Time.time - initialTime) / duration) < 1)
            {
                yValue = Mathf.Clamp01(curve.Evaluate((Time.time - initialTime) * lastKeyTime / duration));

                finalAlpha = initialAlpha + yValue * (wantedAlpha - initialAlpha);
                finalColor.a = finalAlpha;

                renderer.material.color = finalColor;
                yield return new WaitForSeconds(Time.deltaTime);
            }

            finalColor.a = wantedAlpha;
            renderer.material.color = finalColor;
        }

        private IEnumerator FadeInTexture(Renderer renderer, AnimationCurve curve, float duration, float wantedAlpha = 1)
        {
            float finalAlpha;
            float initialAlpha = renderer.material.color.a;
            Color finalColor = renderer.material.color;

            float initialTime = Time.time;
            Keyframe lastframe = curve[curve.length - 1];
            float lastKeyTime = lastframe.time;
            float yValue;

            while (((Time.time - initialTime) / duration) < 1)
            {
                yValue = Mathf.Clamp01(curve.Evaluate((Time.time - initialTime) * lastKeyTime / duration));

                finalAlpha = initialAlpha + yValue * (wantedAlpha - initialAlpha);
                finalColor.a = finalAlpha;

                renderer.material.color = finalColor;
                yield return new WaitForSeconds(Time.deltaTime);
            }

            finalColor.a = wantedAlpha;
            renderer.material.color = finalColor;
        }

        private IEnumerator LerpColor(Renderer renderer, Color nextColor, AnimationCurve curve, float duration)
        {
            Color32 initialColor = renderer.material.color, finalColor;
            int red, green, blue, alpha;

            float initialTime = Time.time;
            Keyframe lastframe = curve[curve.length - 1];
            float lastKeyTime = lastframe.time;
            float yValue;

            while (((Time.time - initialTime) / duration) < 1)
            {
                yValue = Mathf.Clamp01(curve.Evaluate((Time.time - initialTime) * lastKeyTime / duration));

                red = (int)(initialColor.r + yValue * (((byte)(nextColor.r * 255)) - initialColor.r));
                green = (int)(initialColor.g + yValue * (((byte)(nextColor.g * 255)) - initialColor.g));
                blue = (int)(initialColor.b + yValue * (((byte)(nextColor.b * 255)) - initialColor.b));
                alpha = (int)(initialColor.a + yValue * (((byte)(nextColor.a * 255)) - initialColor.a));

                finalColor.r = (byte)red;
                finalColor.g = (byte)green;
                finalColor.b = (byte)blue;
                finalColor.a = (byte)alpha;

                renderer.material.color = finalColor;
                yield return new WaitForSeconds(Time.deltaTime);
            }

            renderer.material.color = nextColor;
        }
    }
}