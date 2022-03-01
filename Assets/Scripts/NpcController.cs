using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    Rigidbody2D rig;
    public Dialogue info;
    Animator anim;
    DialogueSystem Ds;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.Z))
            {
                var system = FindObjectOfType<DialogueSystem>();
                system.Begin(info);
                
            }
        }
    }


}
