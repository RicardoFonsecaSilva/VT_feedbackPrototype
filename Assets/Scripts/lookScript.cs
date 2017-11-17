using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lookScript : MonoBehaviour {

    public GameObject source;
    public GameObject target;
    private Animator anim1;
    private Animator anim2;

    void Start ()
    {
        anim1 = source.GetComponent<Animator>();
        //anim2 = target.GetComponent<Animator>();
    }
	
	void Update ()
    {
		
	}

    public void testLook()
    {
        Vector3 targetVec = target.transform.position;
        Debug.Log("Target: " + targetVec);
        anim1.SetLookAtPosition(targetVec);
        anim1.SetLookAtWeight(1.0f);
    }
}
