using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float moveSpeed = 2f;

    public Animator anim;
    public Rigidbody2D rb;
    public Camera cam;

    public bool lockLook;
    public bool lockLegs;

    public Vector2 movement;
    Vector2 mousePos;

    public void Start()
    {
        //Cursor.visible = false;
    }
    // Update is called once per frame
    public void Update()
    {
        if (lockLegs == false)
        {
        //Input Variables
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        }

        //Mouse Input Variables
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    
    public void FixedUpdate()
    {
        if(lockLegs == false)
        {
        //Physical Movement 
        rb.MovePosition(position: rb.position + (movement * moveSpeed * Time.fixedDeltaTime));
        movement.Normalize();

        //Animation
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        }
        if(lockLook == false)
        {
            //Character-to-Cursor Directional Aiming (based on angle)
            Vector2 lookDir = mousePos - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
       
    }
}
