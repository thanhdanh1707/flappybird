using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float flyPower = 100;

    public AudioClip flyClip;
    public AudioClip gameoverClip;

    private AudioSource audioSource;
    private Animator animator;
    GameObject gameController;
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        audioSource = obj.GetComponent<AudioSource>();
        audioSource.clip = flyClip;
        animator = obj.GetComponent<Animator>();
        animator.SetFloat("flyPower", 0);
        animator.SetBool("isDead", false);
        

        if(gameController == null)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(!gameController.GetComponent<GameController>().isEndGame)
                audioSource.Play();
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, flyPower));
            
        }
        animator.SetFloat("flyPower", obj.GetComponent<Rigidbody2D>().velocity.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        EndGame();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        gameController.GetComponent<GameController>().GetPoint();
    }

    void EndGame()
    {
        animator.SetBool("isDead", true);
        audioSource.clip = gameoverClip;
        audioSource.Play();
        gameController.GetComponent<GameController>().EndGame();
    }
}
