using System.Collections.Generic;
using UnityEngine;
using HookControl;
using VT;
using UnityEngine.UI;
using System.Collections;

public class BallonsTest : MonoBehaviour {

	public GameObject prefab;
    public GameObject options_prefab;
    public Vector2 mariaBalloonAnchorMin, mariaBalloonAnchorMax, joaoBalloonAnchorMin, joaoBalloonAnchorMax;
    public Vector3 mariaBalloonRotation, joaoBalloonRotation;
    [SerializeField]
    private RuntimeAnimatorController default_controller;
    [SerializeField]
	private RuntimeAnimatorController happy_controller;
    [SerializeField]
    private RuntimeAnimatorController sad_controller;

    //public ChangeBackground mariaPlane, joaoPlane;

    //private ChangeBackground currentPlane;

    Control mariaController, joaoController, controller;
    Control optionsController;

    private Dictionary<string, RuntimeAnimatorController> emotionControllers = new Dictionary<string, RuntimeAnimatorController>();

	BalloonsHooks mariaHooks, joaoHooks, optionsHooks;

    private Vector2 anchorMin, anchorMax;
    private Vector3 rotation;
    private float timeToWait;

    bool clean = false;

	// Use this for initialization
	void Start () {

        mariaController = new Control(prefab);
        joaoController = new Control(prefab);
        optionsController = new Control(options_prefab);

        emotionControllers["Default"] = default_controller;
        emotionControllers["Happy"] = happy_controller;
        emotionControllers["Sad"] = sad_controller;
    }

	public void Show(string person, string text, string emotion, float t, string text_2 = "")
	{
        timeToWait = t;
        if (person == "Maria")
        {
            HooksShow(person, text, emotion, ref mariaHooks);
            
        }
        else if (person == "Joao")
        {
            HooksShow(person, text, emotion, ref joaoHooks);
        }
        else
        {
            OptionsShow(person, text, emotion, ref optionsHooks, text_2);

        }
    }

    private void OptionsShow(string person, string text, string emotion, ref BalloonsHooks hooks, string text_2)
    {
        var ret = optionsController.Show();
        if (ret == ShowResult.FIRST || ret == ShowResult.OK)
        {
            hooks = optionsController.instance.GetComponent<BalloonsHooks>();
            if (hooks)
            {
                hooks.topicLeft.GetComponent<Animator>().runtimeAnimatorController = emotionControllers["Default"];

                hooks.ContentLeft = text;
                hooks.ContentRight = text_2;

                //StartCoroutine(CleanAfterClick(hooks));

                //currentPlane.ChangeBackgroundColor(emotion);
            }
        }
    }

    private void HooksShow(string person, string text, string emotion, ref BalloonsHooks hooks)
    {
        if (person == "Maria")
        {
            controller = mariaController;
            anchorMin = mariaBalloonAnchorMin;
            anchorMax = mariaBalloonAnchorMax;
            rotation = mariaBalloonRotation;
            //currentPlane = mariaPlane;

        }
        else if (person == "Joao")
        {
            controller = joaoController;
            anchorMin = joaoBalloonAnchorMin;
            anchorMax = joaoBalloonAnchorMax;
            rotation = joaoBalloonRotation;
            //currentPlane = joaoPlane;
        }

        var ret = controller.Show();
        if (ret == ShowResult.FIRST || ret == ShowResult.OK)
        {
            hooks = controller.instance.GetComponent<BalloonsHooks>();
            if (hooks)
            {
                hooks.topicLeft.GetComponent<RectTransform>().anchorMin = anchorMin;
                hooks.topicLeft.GetComponent<RectTransform>().anchorMax = anchorMax;

                //FAST HACK
                if(emotion == "Sad")
                {
                    hooks.topicLeft.GetComponent<RectTransform>().anchorMin -= new Vector2(0.0f, 0.1f);
                    hooks.topicLeft.GetComponent<RectTransform>().anchorMax -= new Vector2(0.0f, 0.1f);
                }

                hooks.topicLeft.GetComponent<RectTransform>().localEulerAngles = rotation;
                try
                {
                    hooks.topicLeft.GetComponentInChildren<Text>().GetComponent<RectTransform>().localEulerAngles = rotation;
                }
                catch
                {
                }

                if (emotionControllers.ContainsKey(emotion))
                    hooks.topicLeft.GetComponent<Animator>().runtimeAnimatorController = emotionControllers[emotion];
                else
                    hooks.topicLeft.GetComponent<Animator>().runtimeAnimatorController = emotionControllers["Default"];

                hooks.ContentLeft = text;

                StartCoroutine(Clean(hooks));

                //currentPlane.ChangeBackgroundColor(emotion);
            }
        }
    }

    public void CleanOptions(float t)
    {
        timeToWait = t;
        if (optionsController != null) {
            try
            {
                optionsHooks = optionsController.instance.GetComponent<BalloonsHooks>();
            }
            catch { }
            StartCoroutine(Clean(optionsHooks));
        }
    }

    IEnumerator Clean(BalloonsHooks hooks)
	{
        yield return new WaitForSeconds(timeToWait);
        if (hooks)
		{
            hooks.ContentLeft = null;
            try
            {
                hooks.ContentRight = null;
            }
            catch { }
        }
	}
}