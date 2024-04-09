using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement instance;
    public Animator animator;
    
    public float horspeed;
    public float verspeed;
    private float horpos;

    public float leftlimit;
    public float rightlimit;
    public float delaymult;

    public float hordirection;
    private void Awake()
    {
        instance = this;
    }


    void Update()
    {
        if (StartDelay.instance.gameon)
        {
            
            

            transform.Translate(hordirection * verspeed * Time.deltaTime, 0, verspeed * Time.deltaTime);


            horpos = Mathf.Clamp(transform.position.x, leftlimit, rightlimit);

            transform.position = new Vector3(horpos, transform.position.y, transform.position.z);
        }

    }

    
}
