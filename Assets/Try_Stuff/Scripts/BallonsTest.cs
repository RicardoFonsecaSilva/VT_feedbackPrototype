////using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HookControl;
using VT;
using UnityEngine.UI;
using System.Collections;

public class BallonsTest : MonoBehaviour {

	public GameObject prefab;
    public Vector3 mariaBalloonPos, joaoBalloonPos, mariaBalloonRotation, joaoBalloonRotation;
    [SerializeField]
    private RuntimeAnimatorController default_controller;
    [SerializeField]
	private RuntimeAnimatorController happy_controller;
    [SerializeField]
    private RuntimeAnimatorController sad_controller;

    public ChangeBackground mariaPlane, joaoPlane;

    private ChangeBackground currentPlane;

    Control mariaController, joaoController, controller;

    private Dictionary<string, RuntimeAnimatorController> emotionControllers = new Dictionary<string, RuntimeAnimatorController>();

	BalloonsHooks mariaHooks, joaoHooks;

    private Vector3 position, rotation;
    private float timeToWait = 5.0f;

	// Use this for initialization
	void Start () {

        mariaController = new Control(prefab);
        joaoController = new Control(prefab);

        emotionControllers["Default"] = default_controller;
        emotionControllers["Happy"] = happy_controller;
        emotionControllers["Sad"] = sad_controller;
    }

	public void Show(string person, string text, string emotion)
	{

        if (person == "Maria")
        {
            HooksShow(person, text, emotion, ref mariaHooks);
            
        }
        else if (person == "Joao")
        {
            HooksShow(person, text, emotion, ref joaoHooks);
        }

		
	}

    private void HooksShow(string person, string text, string emotion, ref BalloonsHooks hooks)
    {
        if (person == "Maria")
        {
            controller = mariaController;
            position = mariaBalloonPos;
            rotation = mariaBalloonRotation;
            currentPlane = mariaPlane;

        }
        else if (person == "Joao")
        {
            controller = joaoController;
            position = joaoBalloonPos;
            rotation = joaoBalloonRotation;
            currentPlane = joaoPlane;
        }

        var ret = controller.Show();
        if (ret == ShowResult.FIRST || ret == ShowResult.OK)
        {
            hooks = controller.instance.GetComponent<BalloonsHooks>();
            if (hooks)
            {
                hooks.topicLeft.GetComponent<RectTransform>().anchoredPosition3D = position;
                hooks.topicLeft.GetComponent<RectTransform>().localEulerAngles = rotation;
                try
                {
                    hooks.topicLeft.GetComponentInChildren<Text>().GetComponent<RectTransform>().localEulerAngles = rotation;
                }
                catch { }

                if (emotionControllers.ContainsKey(emotion))
                    hooks.topicLeft.GetComponent<Animator>().runtimeAnimatorController = emotionControllers[emotion];
                else
                    hooks.topicLeft.GetComponent<Animator>().runtimeAnimatorController = emotionControllers["Default"];
                hooks.ContentLeft = text;
                
                StartCoroutine(Clean(hooks));

                currentPlane.ChangeBackgroundColor(emotion);
            }
        }
    }

    IEnumerator Clean(BalloonsHooks hooks)
	{
        yield return new WaitForSeconds(timeToWait);
        if (hooks)
		{
            hooks.ContentLeft = null;
		}
	}
}