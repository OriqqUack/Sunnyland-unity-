using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Neoguri guri;
    // Start is called before the first frame update
    void Start()
    {
        guri = GameObject.Find("HeroRat").GetComponent<Neoguri>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            guri.Dmg_Health();
            Debug.Log(guri.max_health);
        }
    }
}
