using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour {

	public Transform camera;
    public float xTilt = 15.0f;
    public float yAngle = 20.0f;
    private Transform transform;

	void Start()
	{
		transform = GetComponent<Transform>();
    }

	void LateUpdate ()
	{
		Vector3 v = camera.transform.position - transform.position;
		transform.rotation = Quaternion.LookRotation(v) * Quaternion.Euler(xTilt, yAngle, 0);
    }
}