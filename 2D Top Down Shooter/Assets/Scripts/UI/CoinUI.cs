using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    public Text text;
    public ScriptableInteger coinScriptable;

    void Start()
    {
        
        
    }

    void Update()
    {
        text.text = coinScriptable.value.ToString(); 
    }

    
}
