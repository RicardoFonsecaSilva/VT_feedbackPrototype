using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HookControl;
using VT;
using UnityEngine.UI;

public class BallonsTest : MonoBehaviour {

	public GameObject prefab;
    public Vector3 mariaBalloonPos, joaoBalloonPos, mariaBalloonRotation, joaoBalloonRotation;
    [SerializeField]
    private RuntimeAnimatorController default_controller;
    [SerializeField]
	private RuntimeAnimatorController happy_controller;
    [SerializeField]
    private RuntimeAnimatorController sad_controller;

    Control mariaController, joaoController, controller;

    private Dictionary<string, RuntimeAnimatorController> emotionControllers = new Dictionary<string, RuntimeAnimatorController>();

	BalloonsHooks hooks;

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
            controller = mariaController;
            position = mariaBalloonPos;
            rotation = mariaBalloonRotation;
        }
        else if (person == "Joao")
        {
            controller = joaoController;
            position = joaoBalloonPos;
            rotation = joaoBalloonRotation;
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
                
                Invoke("Clean", timeToWait);
            }
		}
	}

    public void Clean()
	{
		if (hooks)
		{
			hooks.ContentLeft = null;
		}
	}
}