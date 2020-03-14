using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float playerHealth;
    public float moveSpeed;

    public GameObject prefabParentObject;
    public GameObject deadParticles;
    private GameObject prefabObject;
    public Slider HealthSliderObject;
    public Transform bulletSpawnPos;
    public Transform particleSpawnPos;
    private Rigidbody2D rb;
    private Animator anim;
    private GameManager gm;

    private Vector2 movement;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        gm = GetComponentInParent<GameManager>();

    }
    void Update()
    {
        GetCharacterInputs();

        Animate();
    }

    //we are using FixedUpdate for all physical related stuff 
    void FixedUpdate()
    {
        //we make the player move according to the player Input, we multiplied the value with time to make the movement at a constant speed 
        //not relative to fps
            rb.MovePosition(rb.position + movement.normalized * moveSpeed*Time.fixedDeltaTime);
    }

    //returns a value between -1 and 1 according to the pressed buttons that are defined for Horizontal in Unity(they are changeable)
    //we assign these values to "movement"
    void GetCharacterInputs()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    //we set the values we get from the player for the animator
    void Animate()
    {
        //To make the player look the way it last moved when stopped we don't make the movement Vector2 at he last frame to trigger
        //the right animation in the blend tree
        if (!gm.gameIsPaused)
        {
            if (movement != Vector2.zero)
            {
                anim.SetFloat("Horizontal", movement.x);
                anim.SetFloat("Vertical", movement.y);
            }
            if (movement.x < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            anim.SetFloat("Speed", movement.sqrMagnitude);
        }
    }






    public void TakeDamage(int damage)
    {

            playerHealth -= damage;
            HealthSliderObject.value = playerHealth;
            if (playerHealth <= 0)
            {
                gm.audioManager.Play("PlayerDamaged");
                Dead();
            }        
    }
    public void Dead()
    {
        prefabObject =Instantiate(deadParticles, gameObject.transform.position, gameObject.transform.rotation);
        prefabObject.transform.parent = prefabParentObject.transform;
        anim.SetTrigger("Dead");
    }

}
