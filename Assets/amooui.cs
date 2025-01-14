using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class amooui : MonoBehaviour
{
    public Rigidbody player;
     public Slider slider;
     Image Amoo;
     public float maxClipSize = 10;
     public float currentClip;


    // Start is called before the first frame update
    void Start()
    {
        Amoo = GetComponent<Image>();
        currentClip = maxClipSize;


    }

    // Update is called once per frame
    void Update()
    {
        Amoo.fillAmount = currentClip/maxClipSize;
    }
}
