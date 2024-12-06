using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CoinUI : MonoBehaviour
{
    public TMP_Text text;
    public ScriptableInteger coinScriptable;

    void Start()
    {
        
        
    }

    void Update()
    {
        text.text = coinScriptable.value.ToString(); 
    }

    
}
