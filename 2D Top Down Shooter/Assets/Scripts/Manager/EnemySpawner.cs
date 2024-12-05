using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float delay;
    public ObjectSpawnRate[] enemies;
    private List<GameObject> enemyList;

    void Start()
    {
        enemyList = new List<GameObject>();
        StartCoroutine(spawner()); 
    }
    private IEnumerator spawner() 
    {
    while (true) 
        {
            if (GameManager.GetInstance().isPlaying) 
            {
                spawn(); 
                yield return new WaitForSeconds(delay); 
            }
            else
            {
                yield return null;
            }
        }
    }
    


    private GameObject getEnemy() 
    {
        int limit = 0;

        foreach (ObjectSpawnRate osr in enemies) 
        {
        limit += osr.rate;
        }

        int random = Random.Range(0, limit);

        foreach (ObjectSpawnRate osr in enemies) 
        {
            if (random < osr.rate) 
            {
                return osr.prefab;
            } 
            else 
            {
                random -= osr.rate;
            }
        }
        return null;
    }

    public void spawn() 
    {
        Vector3 newPosition = transform.position;
        newPosition.x = Random.Range(-7.5f, 7.5f);
        enemyList.Add(Instantiate(getEnemy(), newPosition, transform.rotation));
    }

    public void clearEnemies() 
    {
        foreach (GameObject go in enemyList) 
        {
            Destroy(go);
        }
        enemyList.Clear();
    }
}
