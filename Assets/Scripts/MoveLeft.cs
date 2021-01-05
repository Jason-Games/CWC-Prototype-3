using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    public float speed = 30f;
    public float spinRate = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        //transform.Rotate(new Vector3(0,-1) * Time.deltaTime * spinRate, Space.Self);
    }
}
