using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch2 : MonoBehaviour
{
    CharacterController characterCollider;

    public float Crouching;
    public float NotCrouching;
    

    // Start is called before the first frame update
    void Start()
    {
        characterCollider = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl))
            characterCollider.height = Crouching;
        else
            characterCollider.height = NotCrouching;
        
    }
}
