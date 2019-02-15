using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public float maxTime = 50;
    public float minTime = 10;
    private float time;
    private float spawnTime;


    void Awake()
    {
    }


    void Start()
    {
        SetRandomTime();
        time = 0;
    }


    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time >= spawnTime)
        {
            Spawn();
            SetRandomTime();
            time = 0;
        }
    }


    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
        Debug.Log("diamond spawn in " + spawnTime + " seconds.");
    }

    void Spawn()
    {
        Instantiate(transform, transform.position, transform.rotation);
    }
    
}

