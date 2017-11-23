using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour {

    private Color defaultColor, happyColor = Color.yellow, sadColor = Color.blue, lastColor;
    private float duration = 20, smoothness = 0.02f;
    private IEnumerator coroutine;

    // Use this for initialization
    void Start () {
        defaultColor = GetComponent<Renderer>().material.color;
    }

    public void ChangeBackgroundColor(string emotion)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        Color nextColor = GetColor(emotion);
        coroutine = LerpColor(nextColor);
        StartCoroutine(coroutine);
    }

    Color GetColor(string emotion)
    {
        if (emotion == "Sad")
            return sadColor;
        else if (emotion == "Happy")
            return happyColor;
        else
            return defaultColor;
    }

    IEnumerator LerpColor(Color nextColor)
    {
        float progress = 0;
        float increment = smoothness / duration;

        while (progress < 1)
        {
            GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, nextColor, progress);
            progress += increment;
            yield return new WaitForSeconds(smoothness);
        }
    }
}
