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
        if (Input.GetKeyDown(KeyCode.A))
            Generate();
        if (Input.GetKeyDown(KeyCode.B))
            balloon.Clean();
    }

    public void Generate()
    {
        text = "hello world";
        emotion = "Anger";
        balloon.Show(text, emotion);
    }
}
