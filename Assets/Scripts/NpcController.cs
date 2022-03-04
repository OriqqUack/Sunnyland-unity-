using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NpcController : MonoBehaviour
{
    Rigidbody2D rig;
    public Dialogue info;
    Animator anim;
    DialogueSystem system;
    ImageChanger imgC;
    public SpriteRenderer spriteR;
    public bool isBegin=false;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        imgC=GameObject.FindGameObjectWithTag("changeImage").GetComponent<ImageChanger>();
        spriteR=GetComponent<SpriteRenderer>();
        system=GameObject.Find("dialogueSystem").GetComponent<DialogueSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isBegin==true)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                system.Next();           
                Debug.Log("next");     
            }
            
        }

        
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                imgC.sprite=spriteR.sprite;
                if(isBegin==false)
                {
                    system.Begin(info);
                    isBegin=true;       
                }
                
            }
        }
    }


}
