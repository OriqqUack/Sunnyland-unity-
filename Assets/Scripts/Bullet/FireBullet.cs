using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    Rigidbody2D rig;
    

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.up * 2f * Time.deltaTime);
    }

    private void OnBecameInvisible()//화면 밖으로 나가면
    {
        Destroy(this.gameObject);//삭제
    }
}