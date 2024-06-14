using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;


public class PlayerMove : MonoBehaviour
{
    CharacterController playerController;

    Animator anim;

    Vector3 direction;

    string path;

    public Text Name;

    public float speed = 4;
    public float jumpPower = 5;
    public float gravity = 7f;

    public float mousespeed = 5f;


    public float minmouseY = -45f;
    public float maxmouseY = 45f;

    float RotationY = 0f;
    float RotationX = 0f;

    public Transform agretctCamera;

    //要替换的光标图片
    public Texture2D cursorTexture;

    // Use this for initialization


    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true; ;

        anim = GetComponent<Animator>();
        playerController = this.GetComponent<CharacterController>();
        path =  Application.dataPath + @"\IO\threejue.txt";
        Name.text = File.ReadAllText(path);
    }

    // Update is called once per frame
    void Update()
    {
        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");

        if (playerController.isGrounded)
        {
            direction = new Vector3(_horizontal, 0, _vertical);
            if (Input.GetKeyDown(KeyCode.Space))
                direction.y = jumpPower;
        }
        direction.y -= gravity * Time.deltaTime;
        playerController.Move(playerController.transform.TransformDirection(direction * Time.deltaTime * speed));

        RotationX += agretctCamera.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mousespeed;

        RotationY -= Input.GetAxis("Mouse Y") * mousespeed;
        RotationY = Mathf.Clamp(RotationY, minmouseY, maxmouseY);

        this.transform.eulerAngles = new Vector3(0, RotationX, 0);

        agretctCamera.transform.eulerAngles = new Vector3(RotationY, RotationX, 0);

        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        direction = new Vector3(_horizontal, 0, _vertical);
        UpdateAnim();

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Ismove", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetFloat("move", 1);
                speed = 8;
            }
            else 
            {
                anim.SetFloat("move", 0);
                speed = 4;
            }
            
        }
       else
        {
            anim.SetBool("Ismove", false);
        }
        
    }
    void UpdateAnim()
    {
        anim.SetFloat("Speed", direction.magnitude);
    }
}
