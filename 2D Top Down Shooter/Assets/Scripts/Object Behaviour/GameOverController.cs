using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    
    void Start()
    {

    }
    void Update()
    {

    }

    public void gameOver() {
        GameManager.GetInstance().gameOver();
    }
}