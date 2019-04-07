using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Emitter : MonoBehaviour
{

    public GameObject prefab;
    public float velocity;
    public float timeBetweenSpawns;

    float timeSinceLastSpawn;

    void FixedUpdate()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= timeBetweenSpawns)
        {
            timeSinceLastSpawn -= timeBetweenSpawns;
            SpawnGuest();
        }
    }

    void SpawnGuest()
    {
        GameObject spawn = ObjectPooler.Pool.GetObject();
        if (spawn != null)
        {
            spawn.transform.position = transform.position;
            Rigidbody body = spawn.GetComponent<Rigidbody>();
            body.velocity = transform.forward * velocity;
        }
    }
}
