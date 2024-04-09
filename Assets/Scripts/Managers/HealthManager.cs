using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager instance;
    public int health;
    public GameObject LosePanel;
    public TMP_Text LoseScoreText;
    public Animator Animator;

    private void Awake()
    {

        instance = this;
    }


    public void healthgain()
    {
        health++;

        // Canvas üzerinde düzenlemeler yapýlacak.

    }


    public void healthlose()
    {
        health--;
        if (health == 0)
        {
            LosePanel.SetActive(true);
            StartDelay.instance.gameon = false;

            LoseScoreText.text = "Skor: " + ScoreManager.instance.score;
            Animator.SetBool("Run", false);
        }
    }






}
