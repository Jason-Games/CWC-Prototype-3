using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawnObject;
    public Vector3 spawnPostiion = new Vector3(25,0,0);

    private float startDelay = 2f;
    private float repeatSecs = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn",startDelay, repeatSecs);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        Instantiate(spawnObject, spawnPostiion, spawnObject.transform.rotation);
    }
}
