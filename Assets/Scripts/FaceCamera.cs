using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour {

	public Transform camera;
    public float tilt;
    private Transform transform;

	void Start()
	{
		transform = GetComponent<Transform>();
	}

	void LateUpdate ()
	{
		Vector3 v = camera.transform.position - transform.position;
		transform.rotation = Quaternion.LookRotation(v) * Quaternion.Euler(tilt, 0, 0);
	}
}
