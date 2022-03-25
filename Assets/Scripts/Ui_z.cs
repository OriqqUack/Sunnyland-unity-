using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_z : MonoBehaviour
{
    [SerializeField]
     public GameObject Uiz;
    private void Start()
    {
        Uiz = GameObject.Find("HeroRat").transform.GetChild(0).gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Uiz.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Uiz.SetActive(false);
        }
    }
}
