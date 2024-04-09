using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaptoStart : MonoBehaviour
{
    [SerializeField] public TMP_Text Touchtext;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touchtext.text = null;
            StartDelay.instance.runit = true;
            Destroy(gameObject);
        }
    }
    
}
