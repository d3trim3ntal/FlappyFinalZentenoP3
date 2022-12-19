using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce = 200f;
    private bool isDead = false;

    private Rigidbody2D rb2d;
    private Animator anim;

    public AudioClip flap;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Don't allow control if the bird has died/
        if (isDead == false)
        {
            //Look for input to trigger a "flap".
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Flap");
                //...zero out the birds current y velocity before...
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
            }
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Die");
        GameControl.instance.BirdDied();
    }
}    
