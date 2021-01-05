using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int jumpForce = 10;
    public bool GameOver { get; set; }
    public float gravityModifier = 1.05f;

    private Rigidbody body;
    private Animator animator;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    
    public AudioSource playerAudio;
    public AudioClip crashSound;
    public AudioClip jumpSound;

    private bool isOnGround = true;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !GameOver)
        {
            body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            dirtParticle.Stop();
            isOnGround = false;
        }   
    }

    private void OnCollisionEnter(Collision collision)
    {

        switch(collision.gameObject.tag)
        {
            case "Ground":
                isOnGround = true;
                dirtParticle.Play();
                break;
            case "Obstacle":
                GameOver = true;

                Debug.Log("Game Over");
                dirtParticle.Stop(true,ParticleSystemStopBehavior.StopEmittingAndClear);
                playerAudio.PlayOneShot(crashSound, 1.0f);
                animator.SetBool("Death_b", true);
                animator.SetInteger("DeathType_int",1);
                explosionParticle.Play();
                break;
        }
        
    }

}
