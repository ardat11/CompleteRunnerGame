using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public static EnemyHealth instance;

    
    public int health;
    public TMP_Text healthtext;

    private void Awake()
    {
        instance = this;
    }
    public void healthlose()
    {
        health--;
        healthtext.text = health.ToString();
        if (health == 0)
        {
            Destroy(gameObject);

            
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("OurBullet"))
        {
            healthlose();
            Destroy(other.gameObject);

        }
    }
}
