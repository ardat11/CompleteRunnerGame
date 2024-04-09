using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBullet : MonoBehaviour
{
    public static CreateBullet instance;
    public GameObject bullet;
    public bool onsight;
    private float rotate;
    public float firerate = 1;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            rotate = -90f;
        }
        else if (gameObject.CompareTag("Player"))
        {
            rotate = +90f;
        }

        InvokeRepeating("BulletSpawn", 0f, firerate);


    }

    private void BulletSpawn()
    {
        if (onsight && StartDelay.instance.gameon)
        {
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.Euler(new Vector3(rotate, 0, 0)));
        }
        print("çalýþtým la");
    }



    public void FireRateMultiplier(float a)
    {
        firerate = firerate * a;
        CancelInvoke("BulletSpawn");
        InvokeRepeating("BulletSpawn", firerate, firerate);
    }



}
