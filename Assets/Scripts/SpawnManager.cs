using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PlayerController controller;
    public GameObject spawnObject;
    public Vector3 spawnPostiion = new Vector3(25,0.5f,0);

    private float startDelay = 2f;
    public float spawnRepeatsSecsMin = 1f;
    public float spawnRepeatsSecsMax = 2.2f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
        Invoke("Spawn",startDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void Spawn()
    {
        if (!controller.GameOver)
        { 
            // Random rotation

            Instantiate(spawnObject, spawnPostiion, spawnObject.transform.rotation);
            //Instantiate(spawnObject, spawnPostiion, Random.rotation);
            Invoke("Spawn",Random.Range(spawnRepeatsSecsMin, spawnRepeatsSecsMax));
        }
    }
}
