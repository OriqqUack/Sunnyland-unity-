using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    public Image img;
    
    public Sprite sprite;

    void Start()
    {
        img=GetComponent<Image>();
        img.sprite=sprite;
    }
}
