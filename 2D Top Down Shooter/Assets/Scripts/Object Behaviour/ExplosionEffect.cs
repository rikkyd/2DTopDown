using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    // Unity Message
    void Start()
    {
        
    }

    // Unity Message
    void Update()
    {
        
    }

    
    public void ShowExplosion()
    {
        ObjectPool.GetInstance().requestObject(PoolObjectType.EXPLOSION).activate(transform.position, Quaternion.identity);
    }
}