using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neoguri : MonoBehaviour
{

    Rigidbody2D rig;
    Animator animator;
    Animator HP;
    public float JumpPower=2f;
    public float PlayerSpeed = 1f;
    float horizontalMove, verticalMove;
    bool isGround = false;
    [SerializeField]
    public int max_health=3;
    float invincibleTime = 2f;
    bool isInvincible;
    float invincibleTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        HP = GameObject.FindWithTag("HP").GetComponent<Animator>();
            }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");

        animator.SetFloat("LookDirection", horizontalMove);

        playerMove();
        
        AnimationUpdate();

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
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
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            animator.SetBool("isJump", false);
        }
        
     }

    void jumpAnimation()
    {
        if (isGround)
        {
            rig.AddForce(Vector3.up * PlayerSpeed* JumpPower, ForceMode2D.Impulse);

            isGround = false;
            
        }
    }

    void AnimationUpdate()
    {

        if (horizontalMove == 0 && verticalMove == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }

    }

    [SerializeField]
    public void Dmg_Health()
    {
        if (isInvincible)
        {
            Debug.Log("test");
            HP.SetBool("isDmg", false);
            return;
        }
        else
        {
            HP.SetBool("isDmg", true);
            max_health -= 1;
            invincibleTimer = invincibleTime;
            isInvincible = true;
        }
    }

}
