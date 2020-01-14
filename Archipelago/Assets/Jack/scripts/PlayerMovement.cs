using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;

    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float gravity = -55.81f;

    [SerializeField] public Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim.SetBool("Walking", false);
    }


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");


        //move character acording to input
        Vector3 move = new Vector3(moveHorizontal, 0f, moveVertical);

        controller.Move(move * speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(move), .2f);

        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


        //make character walk if getting input
        if (moveHorizontal > 0.01 || moveHorizontal < -0.01 || moveVertical > 0.01 || moveVertical < -0.01)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        



    }
}
