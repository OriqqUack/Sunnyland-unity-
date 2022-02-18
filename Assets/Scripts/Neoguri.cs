using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neoguri : MonoBehaviour
{
    Rigidbody2D rig;
    Animator animator;
    public float JumpPower=2f;
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
        




        if (Input.GetKeyDown(KeyCode.Space)){
            transform.position +=Vector3.up * Time.deltaTime;
            jumpAnimation();
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * Time.deltaTime;
            
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * Time.deltaTime;
            
        }
        
        AnimationUpdate();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground");
        isGround = true;
    }

    void jumpAnimation()
    {
        if (isGround)
        {
            rig.AddForce(Vector3.up * JumpPower, ForceMode2D.Impulse);
            isGround = false;
            Debug.Log("jump!");
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
