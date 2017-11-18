using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HookControl;
using VT;

public class BallonsTest : MonoBehaviour {

	public GameObject prefab;
    [SerializeField]
    private RuntimeAnimatorController default_controller;
    [SerializeField]
	private RuntimeAnimatorController anger_controller;

	Control controller;

    private Dictionary<string, RuntimeAnimatorController> emotionControllers = new Dictionary<string, RuntimeAnimatorController>();

	BalloonsHooks hooks;

	bool shownText = false;
	float time = 0;

	// Use this for initialization
	void Start () {
		controller = new Control(prefab);
        emotionControllers["Default"] = default_controller;
        emotionControllers["Anger"] = anger_controller;
	}

	public void Show(string text, string emotion)
	{
		var ret = controller.Show();
		if (ret == ShowResult.FIRST || ret == ShowResult.OK)
		{
			hooks = controller.instance.GetComponent<BalloonsHooks>();
			if (hooks)
			{
                if (emotionControllers.ContainsKey(emotion))
                    hooks.topicLeft.GetComponent<Animator>().runtimeAnimatorController = emotionControllers[emotion];
                else
                    hooks.topicLeft.GetComponent<Animator>().runtimeAnimatorController = emotionControllers["Default"];
                hooks.ContentLeft = text;
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