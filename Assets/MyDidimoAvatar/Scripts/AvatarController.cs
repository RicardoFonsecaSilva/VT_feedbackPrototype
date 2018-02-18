using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public partial class AvatarController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ExpressEmotion(ExpressionState expression)
    {
        animator.SetInteger("Expression", (int)expression);
        animator.SetTrigger("Express");
    }

    public void SetMood(MoodState moodState)
    {
        animator.SetInteger("Mood", (int)moodState);
    }

    public void GazeAt(GazeState direction)
    {
        animator.SetInteger("Direction", (int)direction);
        animator.SetTrigger("Gaze");
    }
}