using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimWalk : MonoBehaviour
{
    Vector3 velocity;

    Animator anim;

    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);


        if(isGrounded && velocity.z < 0)
        {
            anim.SetBool("IsWalking", true);
        }

    }
}
