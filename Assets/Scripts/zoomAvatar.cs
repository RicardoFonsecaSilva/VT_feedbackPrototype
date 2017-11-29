// This C# function can be called by an Animation Event
using UnityEngine;
using System.Collections;

public class zoomAvatar : MonoBehaviour
{
    public GameObject avatar;
    public Transform beginPoint;
    public Transform endPoint;
    public float journeyTime = 0.5F;

    private Transform trasform;
    private Animator animator;
    private float zoomInStartTime;
    private bool zoomInStarted = false;
    private float zoomOutStartTime;
    private bool zoomOutStarted = false;

    void Start()
    {
        animator = avatar.GetComponent<Animator>();
        trasform = avatar.GetComponent<Transform>();
    }

    void Update()
    {
        if (!zoomInStarted)
        {
            zoomInStartTime = Time.time;
        }
        if (animator.GetBool("isTalking"))
        {
            zoomInStarted = true;
            lerpIt(beginPoint, endPoint, zoomInStartTime);
        }
        else
        {
             zoomInStarted = false;
        }

        if (!zoomOutStarted)
        {
            zoomOutStartTime = Time.time;
        }
        if (animator.GetBool("isDoneTalking"))
        {
            zoomOutStarted = true;
            lerpIt(endPoint, beginPoint, zoomOutStartTime);
        }
        else
        {
            zoomOutStarted = false;
        }

    }

    void lerpIt(Transform begin, Transform end, float sTime)
    {
        Vector3 center = (begin.position + end.position) * 0.5F;
        center -= new Vector3(0, 1, 0);
        Vector3 riseRelCenter = begin.position - center;
        Vector3 setRelCenter = end.position - center;
        float fracComplete = (Time.time - sTime) / journeyTime;
        //if (fracComplete > 1.0f)
        //{
        //    //Debug.Log("T: DONE");
        //}
        trasform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
        trasform.position += center;
    }
}