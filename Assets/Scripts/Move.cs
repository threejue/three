using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 1;
    Animator anim;
    Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = new Vector3(x,0,z);

       
        transform.Translate(x*speed,0,z*speed);
        UpdateAnim();

        
    }
     void UpdateAnim()
    {
        anim.SetFloat("Speed", move.magnitude);
    }
}
