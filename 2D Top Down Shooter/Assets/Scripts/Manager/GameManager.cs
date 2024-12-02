using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public GameObject playerPrefab;
    public GameObject activePlayer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        spawnPlayer();
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    private void spawnPlayer()
    {
        Instantiate(playerPrefab);
    }
    public Vector3 getPlayerPosition() 
    {
        if (activePlayer != null) 
        {
            return activePlayer.transform.position;
        } 
        else 
        {
            return Vector3.zero;
        }
    }
}