using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neoguri : MonoBehaviour
{

    Rigidbody2D rig;
    Animator animator;
    public float JumpPower=2f;
    public float PlayerSpeed = 1f;
    public IEnumerator m_typeMove;
    float horizontalMove, verticalMove;
    bool isGround = false;
    
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");

        animator.SetFloat("LookDirection", horizontalMove);

        playerMove();
        
        AnimationUpdate();
    }

    public void playerMove()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            animator.SetBool("isJump", true);
            jumpAnimation();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("isLay", true);
            PlayerSpeed = 0.5f;
            
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            PlayerSpeed = 1f;
            animator.SetBool("isLay", false);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * PlayerSpeed * Time.deltaTime;
            animator.SetFloat("LookDirection", horizontalMove);
            animator.SetFloat("StaticLookD", -1);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * PlayerSpeed * Time.deltaTime;
            animator.SetFloat("LookDirection", horizontalMove);
            animator.SetFloat("StaticLookD", 1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        isGround = true;
        animator.SetBool("isJump", false);
    }

    void jumpAnimation()
    {
        if (isGround)
        {
            rig.AddForce(Vector3.up * JumpPower, ForceMode2D.Impulse);

            isGround = false;
            
        }
    }

    void AnimationUpdate()
    {

        if (horizontalMove == 0 && verticalMove == 0)
        {
            animator.SetBool("isRunning", false);
            
        }
        else animator.SetBool("isRunning",true);
        

    }
}
