using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace BubbleSystem
{
    public abstract class Modifier : MonoBehaviour
    {
        protected abstract void Add(Data data);
        protected abstract void Set<T>(T data, string attribute, bool defaultData = false);

        protected void SetDictionary(string folder, string file)
        {
            var json = JsonParser.Instance.ParseJson(folder + file);

            foreach (var emotionKey in json.Keys)
            {
                Data data = new Data();
                Texture2D tex = new Texture2D(2, 2);

                data.emotion = (Emotion)Enum.Parse(typeof(Emotion), emotionKey);

                var emotion = json[emotionKey] as Dictionary<string, System.Object>;

                foreach (var intensityKey in emotion.Keys)
                {
                    data.intensity = Mathf.Clamp01(Convert.ToSingle(intensityKey));
                    var intensity = emotion[intensityKey] as Dictionary<string, System.Object>;
                    foreach (var reasonKey in intensity.Keys)
                    {
                        data.reason = (Reason)Enum.Parse(typeof(Reason), reasonKey as string);
                        var reason = intensity[reasonKey] as Dictionary<string, System.Object>;
                        foreach (var dictKey in reason.Keys)
                        {
                            switch (dictKey)
                            {
                                case "image_path":
                                    tex = (Texture2D)Resources.Load(folder + reason[dictKey]);
                                    Set(tex, dictKey);
                                    continue;
                                case "color":
                                    var colorList = reason[dictKey] as List<System.Object>;
                                    Set(colorList, dictKey);
                                    continue;
                                case "font":
                                    Font font = (Font)Resources.GetBuiltinResource(typeof(Font), reason[dictKey] + ".ttf");
                                    Set(font, dictKey);
                                    continue;
                                case "size":
                                    Set(Convert.ToSingle(reason[dictKey]), dictKey);
                                    continue;
                                case "transition_fade":
                                    Set(Convert.ToSingle(reason[dictKey]), dictKey);
                                    continue;
                                case "color_duration":
                                    Set(Convert.ToSingle(reason[dictKey]), dictKey);
                                    continue;
                                case "color_smoothness":
                                    Set(Convert.ToSingle(reason[dictKey]), dictKey);
                                    continue;
                                case "animator_path":
                                    if (data.emotion.Equals(Emotion.Default))
                                        Set((UnityEditor.Animations.AnimatorController)Resources.Load(folder + reason[dictKey]), dictKey);
                                    else
                                        Set((AnimatorOverrideController)Resources.Load(folder + reason[dictKey]), dictKey);
                                    continue;
                                case "duration":
                                    Set(Convert.ToSingle(reason[dictKey]), dictKey, data.emotion.Equals(Emotion.Default) ? true : false);
                                    continue;
                                default:
                                    Debug.Log("Key " + dictKey + " not found");
                                    continue;
                            }
                        }
                        Add(data);
                    }
                }
            }
        }
    }
}