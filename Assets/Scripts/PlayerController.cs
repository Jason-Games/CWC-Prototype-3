using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int jumpForce = 10;
    public bool GameOver { get; set; }
    public float gravityModifier = 1.05f;

    private Rigidbody body;

    private bool isOnGround = true;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        switch(collision.gameObject.tag)
        {
            case "Ground":
                isOnGround = true;
                break;
            case "Obstacle":
                GameOver = true;
                Debug.Log("Game Over");
                break;
        }
        
    }

}
