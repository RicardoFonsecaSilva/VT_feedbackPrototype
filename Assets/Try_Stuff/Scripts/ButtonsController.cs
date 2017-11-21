using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VT;

public class ButtonsController : MonoBehaviour {

    private BallonsTest balloon;
    private GameObject balloonObject;
    private string text, emotion;
    private Image image;

    void Awake()
    {
        balloonObject = GameObject.FindGameObjectWithTag("Balloon Manager");
        balloon = balloonObject.GetComponent<BallonsTest>();
        //image = balloon.prefab.GetComponent<BalloonsHooks>().topicLeft.GetComponent<Image>();
        //balloon.prefab.GetComponent<BalloonsHooks>().topicLeft.GetComponent<RectTransform>().localScale = new Vector3(100.0f, 200.0f, 0.0f);
        //image.rectTransform.rect.Set(image.rectTransform.rect.x, image.rectTransform.rect.y, 1.0f, 1.0f); // = new Vector2(1.0f, 1.0f);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
            balloon.Clean();
        else if (Input.GetKeyDown(KeyCode.Alpha1))
            Generate("Happy");
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            Generate("Sad");
    }

    public void Generate(string emotion)
    {
        text = "hello world";
        balloon.Show(text, emotion);
    }
}
