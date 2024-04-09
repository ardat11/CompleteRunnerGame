using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartDelay : MonoBehaviour
{

    public static StartDelay instance;
    public float startcounter;
    public TMP_Text startcounterText;
    public TMP_Text Touchtext;
    public bool gameon = false;
    public bool runit = false;
    private void Awake()
    {
        instance = this;
    }


    private void Update()
    {   
        
        if (runit)
        {
            if (gameon != true)
            {
                startcounter -= Time.deltaTime;
            }
            if (startcounter > 0.6)
            {

                startcounterText.text = "    " + startcounter.ToString("F0");

            }
            else if (startcounter <= 0)
            {
                startcounterText.text = "Start!";
            }

            if (startcounter <= -1)
            {
                startcounterText.text = null;
                gameon = true;
                runit = false;
                HealthManager.instance.Animator.SetBool("Run", true);
                
            }

        }
    }
}
