using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;

public class CollissionManager : MonoBehaviour
{

    public GameObject WinPanel;
    public TMP_Text winscoretext;

    private void OnTriggerEnter(Collider other)
    {
       
        if(other.gameObject.CompareTag("FinishLine"))
        {
            
            WinPanel.SetActive(true);
            HealthManager.instance.Animator.SetBool("Run", false);
            winscoretext.text = ScoreManager.instance.score.ToString();
            StartDelay.instance.gameon = false;
            Destroy(DynamicJoystick.instance.currentjoybg);
            Destroy(DynamicJoystick.instance.currentJoystick);
            Destroy(ScoreManager.instance.scoretext.transform.parent.gameObject);
            return;
        }
        
        if(other.gameObject.CompareTag("OurBullet"))
        {
            return;
        }
        if (other.gameObject.CompareTag("Coin"))
        {
            
            ScoreManager.instance.ScoreUp(1);

        }

        if (other.gameObject.CompareTag("HigherCoin"))
        {
            
            ScoreManager.instance.ScoreMult(2);


        }

        if (other.gameObject.CompareTag("LowerCoin"))
        {
           
           ScoreManager.instance.ScoreDown(10);

        }

        if (other.gameObject.CompareTag("HigherFR"))
        {
            
            CreateBullet.instance.FireRateMultiplier(0.5f);

        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            ScoreManager.instance.ScoreDown(10);
        }
            Destroy(other.gameObject);
    
    }
}
