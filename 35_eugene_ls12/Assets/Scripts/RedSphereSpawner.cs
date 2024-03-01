﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSphereSpawner : MonoBehaviour
{
    public float MinX, MinY, MaxX, MaxY;

    public GameObject RedSphere;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRedSphere", 1.0f, 2.0f);
    }

    Vector3 RandomPosition()
    {
        float x, y, z;

        x = Random.Range(MinX, MaxX);
        y = Random.Range(MinY, MaxY);
        z = 0;

        return new Vector3(x, y, z);
    }

    void SpawnRedSphere()
    {
        GameObject RedSphereTemp = Instantiate(RedSphere, RandomPosition(), Quaternion.identity);
        Destroy(RedSphereTemp, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
