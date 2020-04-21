using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;
    public GameObject FirstPerson;
    private AudioSource Pew;

    public float speed;

    Vector3 velocity;
    public float gravity = -9.81f;

    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;
    bool isGrounded;

    public float JumpHeight;

    public float WalkSpeed;
    public float SprintSpeed;
    public float SideSpeed;
    public float Sneak;


    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Pew = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);
        

            if (isGrounded && velocity.y < 0)
        {
            velocity.y = -4f;
        }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey("s") && Input.GetKey("a"))
            speed = SideSpeed;
        else if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey("s") && Input.GetKey("d"))
            speed = SideSpeed;
        else if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey("s"))
            speed = SprintSpeed;
        else if (!Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl))
            speed = Sneak;
        else
            speed = WalkSpeed;

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (x > 0)
        {
            
        }


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }

        velocity.y += gravity + Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

       
       
      


           



        }

    }


