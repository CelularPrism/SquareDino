using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private Animator animator;

    private void Start()
    {
        movement = transform.GetComponent<Movement>();
        animator = transform.GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("Move", movement.isMove);
    }
}
