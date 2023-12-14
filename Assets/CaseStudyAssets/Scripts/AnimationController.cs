using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator = null;

    public void SetBoolean(string animationType, bool value)
    {
        animator.SetBool(animationType, value);
    }
}
