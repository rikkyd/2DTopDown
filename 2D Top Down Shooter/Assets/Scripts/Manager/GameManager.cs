using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public GameObject playerPrefab;
    public GameObject activePlayer;
    public ScriptableInteger life;
    public ScriptableInteger coin;
    public EnemySpawner spawner;
    public List<GameObject> items;

    public bool isPlaying = false;
    public UnityAction OnGameOverAction;
    
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
        items = new List<GameObject>();
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    private void spawnPlayer()
    {
        if (playerPrefab != null)
        {
        
            activePlayer = Instantiate(playerPrefab);

            
            activePlayer.transform.position = Vector3.zero; 
        }
        else
        {
            Debug.LogWarning("Player prefab is not assigned in the GameManager!");
        }
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

    public void startGame() 
    {
        isPlaying = true; 
        spawnPlayer();
    }
    public void pauseGame() 
    {
        isPlaying = false; 
        Time.timeScale = 0; 
    }

    internal void retry() 
    {
        life.reset();
        coin.reset();
        spawner.clearEnemies();
        ObjectPool.GetInstance().deactivateAllObjects();
        clearAllItems();
    }

    public void resumeGame() 
    {
        isPlaying = true;
        Time.timeScale = 1;
    }

    internal void gameOver() 
    {
        isPlaying = false;
        OnGameOverAction?.Invoke();
    }

    internal void addItem(GameObject gameObject)
    {
        items.Add(gameObject);
    }

    public void clearAllItems()
    {
        foreach (GameObject go in items)
        {
            Destroy(go);
        }
        items.Clear();
    }
}