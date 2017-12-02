using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{

    public Transform camera;
    public float xTilt = 15.0f;
    public float yTilt = 25.0f;
    public float zTilt = 7.5f;
    public Orientation orientation = Orientation.Right;

    private Transform transform;

    void Start()
    {
        transform = GetComponent<Transform>();
    }

    void LateUpdate()
    {
        Vector3 v = camera.transform.position - transform.position;
        float ori = (orientation == Orientation.Right ? 1.0f : -1.0f);
        transform.rotation = Quaternion.LookRotation(v) * Quaternion.Euler(xTilt, yTilt * ori, zTilt * ori);
    }
}

public enum Orientation
{
    Left, Right
}