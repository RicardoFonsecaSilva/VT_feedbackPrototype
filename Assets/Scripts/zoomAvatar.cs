// This C# function can be called by an Animation Event
using UnityEngine;
using System.Collections;

public class zoomAvatar : MonoBehaviour
{
    public GameObject avatar;
    public Transform beginPoint;
    public Transform endPoint;
    public float journeyTime = 0.5F;
    public float delay = 0.0F;

    private Transform trasform;
    private Animator animator;
    private float zoomInStartTime;
    private float zoomOutStartTime;
    private bool zoomingIn = false;
    private bool zoomingOut = false;

    void Start()
    {
        animator = avatar.GetComponent<Animator>();
        trasform = avatar.GetComponent<Transform>();
    }

    void Update()
    {
        //Zoom In
        if (animator.GetBool("zoomAvatar"))
        {
            zoomingIn = true;
            animator.SetBool("zoomAvatar", false);
        }

        if (zoomingIn)
            lerpIt(beginPoint, endPoint, zoomInStartTime);
        else
            zoomInStartTime = Time.time;

        //Zoom Out
        if (animator.GetBool("returnAvatar"))
        {
            //zoomingOut = true;
            animator.SetBool("returnAvatar", false);
            StartCoroutine(DelayedLerp(delay));
        }

        if (zoomingOut)
            lerpIt(endPoint, beginPoint, zoomOutStartTime);
        else
            zoomOutStartTime = Time.time;
    }

    void lerpIt(Transform begin, Transform end, float sTime)
    {
        Vector3 center = (begin.position + end.position) * 0.5F;
        center -= new Vector3(0, 1, 0);
        Vector3 riseRelCenter = begin.position - center;
        Vector3 setRelCenter = end.position - center;
        float fracComplete = (Time.time - sTime) / journeyTime;
        //Debug.Log("T: "+ fracComplete);
        if (fracComplete > 1.0f)
        {
            //Debug.Log("T: DONE");
            zoomingIn = false;
            zoomingOut = false;
        }
        trasform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
        trasform.position += center;
    }

    IEnumerator DelayedLerp(float wait)
    {
        yield return new WaitForSeconds(wait);
        zoomingOut = true;
    }
}