using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BubbleSystem
{
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

        private float initialAlpha;

        public void SetBackground(string bg, Data data)
        {
            TextureData textureData = DefaultData.Instance.defaultBackgroundDataDictionary[data.reason];
            BackgroundAnimationData backgroundAnimationData = DefaultData.Instance.defaultBackgroundAnimationData[data.emotion];
            renderer = GetBackground(bg).GetComponent<Renderer>();
            SetImage(bg, renderer, textureData, backgroundAnimationData, true);
        }

        private GameObject GetBackground(string bg)
        {
            foreach(Background b in backgrounds)
            {
                if (b.name.Equals(bg))
                {
                    return b.background;
                }
            }

            throw new KeyNotFoundException("Background with name: " + bg + " not found.");
        }

        public void SetImage(string bg, Renderer renderer, TextureData textureData, BackgroundAnimationData backgroundAnimationData, bool lerp)
        {
            if (lerp)
            {
                initialAlpha = renderer.material.color.a;
                StartCoroutine(ChangeImage(bg, renderer, textureData, backgroundAnimationData));
            }
            else
            {
                renderer.material.mainTexture = textureData.texture;
                renderer.material.color = textureData.colorData.color;
            }
        }

        public void ChangeColor(string bg, Renderer renderer, Color nextColor, ColorTransitionData backgroundColorAnimationData)
        {
            if (colorCoroutines.ContainsKey(bg))
                CoroutineStopper.Instance.StopCoroutineWithCheck(colorCoroutines[bg]);

            colorCoroutines[bg] = LerpColor(renderer, nextColor, backgroundColorAnimationData);
            StartCoroutine(colorCoroutines[bg]);
        }

        public void ChangeTexture(string bg, Renderer renderer, Texture nextTexture, float fade)
        {
            if (textureCoroutines.ContainsKey(bg))
                CoroutineStopper.Instance.StopCoroutineWithCheck(textureCoroutines[bg]);
            textureCoroutines[bg] = LerpTexture(renderer, nextTexture, fade);
            StartCoroutine(textureCoroutines[bg]);
        }

        private IEnumerator ChangeImage(string bg, Renderer renderer, TextureData textureData, BackgroundAnimationData backgroundAnimationData)
        {
            if (!renderer.material.mainTexture.name.Equals(textureData.texture.name))
            {
                ChangeTexture(bg, renderer, textureData.texture, backgroundAnimationData.imageFadePercentage);
            }
            yield return new WaitUntil(() => renderer.material.mainTexture.name.Equals(textureData.texture.name) && renderer.material.color.a == initialAlpha);

            if (!renderer.material.color.Equals(textureData.colorData.color))
            {
                ChangeColor(bg, renderer, textureData.colorData.color, backgroundAnimationData.colorTransitionData);
            }
            yield return new WaitUntil(() => renderer.material.color == textureData.colorData.color);
        }

        private IEnumerator LerpColor(Renderer renderer, Color nextColor, ColorTransitionData backgroundColorAnimationData)
        {
            float progress = 0;
            float increment = backgroundColorAnimationData.smoothness / backgroundColorAnimationData.duration;

            while (progress < 1)
            {
                renderer.material.color = Color.Lerp(renderer.material.color, nextColor, progress);
                progress += increment;
                yield return new WaitForSeconds(backgroundColorAnimationData.smoothness);
            }
        }

        private IEnumerator FadeOut(Renderer renderer, float fade)
        {
            while (renderer.material.color.a > 0.0f)
            {
                var material = renderer.material;
                var color = material.color;
                color.a -= (fade * Time.deltaTime);
                color.a = Mathf.Clamp01(color.a);

                material.color = new Color(color.r, color.g, color.b, color.a);
                yield return null;
            }
        }

        private IEnumerator FadeIn(Renderer renderer, float fade)
        {
            while (renderer.material.color.a < initialAlpha)
            {
                var material = renderer.material;
                var color = material.color;
                color.a += (fade * Time.deltaTime);
                color.a = Mathf.Clamp(color.a, 0.0f, initialAlpha);

                material.color = new Color(color.r, color.g, color.b, color.a);
                yield return null;
            }
        }

        private IEnumerator LerpTexture(Renderer renderer, Texture nextTexture, float fade)
        {
            yield return StartCoroutine(FadeOut(renderer, fade));
            renderer.material.mainTexture = nextTexture;
            renderer.material.mainTexture.wrapMode = TextureWrapMode.Mirror;
            yield return StartCoroutine(FadeIn(renderer, fade));
        }
    }
}