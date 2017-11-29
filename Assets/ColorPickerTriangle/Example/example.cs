using UnityEngine;
using System.Collections;

public class example : MonoBehaviour {

    public GameObject ColorPickedPrefab;
    private ColorPickerTriangle CP;
    private bool isPaint = false;
    private GameObject go;
    private Material mat;

    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        if (isPaint)
        {
            mat.color = CP.TheColor;
        }
    }

    void OnMouseDown()
    {
        if (isPaint)
        {
            StopPaint();
        }
        else
        {
            StartPaint();
        }
    }

    private void StartPaint()
    {
        go = (GameObject)Instantiate(ColorPickedPrefab, new Vector3(transform.position.x, -0.5f, transform.position.z-0.2f), Quaternion.identity);
        go.transform.localScale = new Vector3(0.3f,0.3f,1.0f);
        go.transform.LookAt(Camera.main.transform);
        CP = go.GetComponent<ColorPickerTriangle>();
        CP.SetNewColor(mat.color);
        isPaint = true;
    }

    private void StopPaint()
    {
        Destroy(go);
        isPaint = false;
    }
}
