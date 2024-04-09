using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{   

    public static ScoreManager instance;
    public int score;
    public TMP_Text scoretext;
    public GameObject loweranim;

    private void Awake()
    {
        instance = this;
    }




    public void ScoreUp(int a)
    {
            score+=a;
        ScoretextUpdate();
        print("paraya deðdin");
    }

    public void ScoreDown(int a)
    {
        for (int i = 0; i < a; i++)
        {
            score--;
        }
        ScoretextUpdate();
        loweranim.SetActive(true);
    }

    public void ScoreMult(int a)
    {
        if (score > 0)
        {
            score *= a;
        }

        else
        {
            score /= a;
        }
        ScoretextUpdate();

    }

    public void ScoretextUpdate()
    {
        scoretext.text = score.ToString();
    }

}
