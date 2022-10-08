using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float speed = 100f;
    public int damage = 52;
    //public GameObject hitEffect;
    public Rigidbody2D rb;

    public LayerMask hitLayer;
    public Transform hitCheck;
    public bool isHit;
    public float hitRadius;


    void Awake()
    {
       
        //Launch that fucker
        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
        Destroy(gameObject, 2f);
    }
    public void FixedUpdate()
    {
        isHit = Physics2D.OverlapCircle(hitCheck.position, hitRadius, hitLayer);
    }

    void Collision2D(Collider2D collision)
    {
        isHit = true;
        TestTarget enemy = collision.GetComponent<TestTarget>();
        BoxCollider2D collider = collision.GetComponent<BoxCollider2D>();


        DestroyIt();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            DestroyIt();
        }
        else if (collider != null)
        {
            DestroyIt();
        }

        void DestroyIt()
        {
            Destroy(gameObject, 0.001f);
        }
        //Instantiate(hitEffect, transform.position, transform.rotation);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        isHit    = true;
        TestTarget enemy = collision.GetComponent<TestTarget>();
        BoxCollider2D collider = collision.GetComponent<BoxCollider2D>();
        

        DestroyIt();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            DestroyIt();
        }
        else if (collider != null)
        {
            DestroyIt();
        }

        void DestroyIt()
        {
            Destroy(gameObject, 0.001f);
        }
        //Instantiate(hitEffect, transform.position, transform.rotation);
    }
}
