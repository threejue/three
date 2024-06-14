using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float runspeed;
    public float jumpSpeed;
    public float gravity;
   
    private Vector3 moveDirection = Vector3.zero;
  
    CharacterController controller;

    public
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }
    
    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            //获取wasd
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump")) moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);



    }
}