using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    private PlayerController controller;

    public float speed = 30f;
    public float spinRate = 20f;
    private float leftBound = -20;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!controller.GameOver)
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        //transform.Rotate(new Vector3(0,-1) * Time.deltaTime * spinRate, Space.Self);

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);
    }
}
