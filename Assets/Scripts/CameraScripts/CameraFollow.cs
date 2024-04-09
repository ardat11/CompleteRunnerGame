using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance;

    private void Awake()
    {
        instance = this;
    }



    [SerializeField] private Transform target;
    public Vector3 Difference;
    private void LateUpdate()
    {

        if (target != null)
        {
            transform.position = target.position + Difference;


        }
    }
}