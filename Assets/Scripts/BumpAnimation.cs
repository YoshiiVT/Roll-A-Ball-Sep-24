using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpAnimation : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        animator.SetTrigger("Bump");
    }
}
