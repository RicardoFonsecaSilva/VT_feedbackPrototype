using UnityEngine;
using System.Collections;

public class example : MonoBehaviour {

    public GameObject ColorPickedPrefab;
    private ColorPickerTriangle CP;
    private bool isPaint = false;
    private GameObject go;
    private Material[] mat = new Material[2];

    void Start()
    {
        Material m;
        for(int i = 0; i < transform.childCount; i++)
        {
            m = transform.GetChild(i).GetComponent<MeshRenderer>().material;
            mat[i] = m;
        }

        go = (GameObject)Instantiate(ColorPickedPrefab, new Vector3(0, -0.3f, 9.275f), Quaternion.Euler(11.31f, 180, 0));
        go.transform.localScale = new Vector3(0.1f, 0.1f, 1.0f);
        go.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(2) || Input.GetKeyDown(KeyCode.Space))
        {
            if (isPaint)
                StopPaint();
            else
                StartPaint();
        }

        if (isPaint)
        {
            foreach(Material m in mat)
                m.color = CP.TheColor;

            if(go != null)
                go.transform.LookAt(Camera.main.transform);
        }
    }

    //void OnMouseDown()
    //{
//        if (isPaint)
//        {
//            StopPaint();
//}
//        else
//        {
//            StartPaint();
//        }
    //}

    private void StartPaint()
    {
        go.SetActive(true);
        go.transform.LookAt(Camera.main.transform);
        CP = go.GetComponent<ColorPickerTriangle>();
        foreach (Material m in mat)
            CP.SetNewColor(m.color);
        isPaint = true;
    }

    private void StopPaint()
    {
        go.SetActive(false);
        isPaint = false;
    }
}
