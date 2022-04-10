using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;
    public Transform FirePos;
    float time, timer=1;
    bool isTime;

    // Start is called before the first frame update
    void Start()
    {
        time = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (isTime)
            {
                Instantiate(bullet, FirePos.transform.position, FirePos.transform.rotation);
                isTime = false;
            }
        }

    }

    
}
