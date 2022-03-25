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

    private GameObject Ui_z;
    private SpriteRenderer spriteR;
    private bool isBegin=false;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        imgC=GameObject.FindGameObjectWithTag("changeImage").GetComponent<ImageChanger>();
        spriteR=GetComponent<SpriteRenderer>();
        system=GameObject.Find("dialogueSystem").GetComponent<DialogueSystem>();
        Ui_z = GameObject.Find("HeroRat").transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if(isBegin==true)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                if (system.sentences.Count == 0)
                {
                    isBegin = false;
                    system.End();
                }
                else
                {
                    system.Next();
                }
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
                imgC.sprite = spriteR.sprite;
                if (isBegin == false)
                {
                    system.Begin(info);
                    isBegin = true;
                }
            }
        }
    }


}
