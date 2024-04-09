using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemyBullet : MonoBehaviour
{
    public static CreateEnemyBullet instance;
    public GameObject bullet;
    public bool onsight;
    public Transform Player;

    [SerializeField] private float limit = 40;
    [SerializeField] private float diff;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        

        InvokeRepeating("BulletSpawn", 0f, 1f);


    }

    private void BulletSpawn()
    {
        if (onsight && StartDelay.instance.gameon)
        {
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.Euler(new Vector3(-90f, 0, 0)));
        }
        print("çalýþtým la");
    }


    

    private void Update()
    {
        diff = transform.position.z - Player.position.z;

        if (diff < limit && diff > 0)
        {
            print("aaaa");
            onsight = true;

        }
        else if (diff < 0)
        {
            onsight = false;
        }

    }




}
