using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserSimpleWalk : MonoBehaviour
{
    public float speed = 1f;
    public float maxSpeed = 10f;
    public bool grounded; 
    public Rigidbody2D rigidBody2D;
    public Physics2D physics2D;
    Animator animator;
    void Start()
    {
        rigidBody2D = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();   
    }

    void Update()
    {
        animator.SetBool("Grounded", true); //set Ground
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal"))); //set speed
        if(Input.GetAxis("Horizontal") < -0.1f) { //for go left
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0,180);
        } else if(Input.GetAxis("Horizontal") > 0.1f) {//for go right
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0,0);
        }
    }
}
