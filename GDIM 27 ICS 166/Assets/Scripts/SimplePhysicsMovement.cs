using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePhysicsMovement : MonoBehaviour
{

    public SpriteRenderer thisSprite;
    public Rigidbody2D thisRigidbody2D;
    public float force = 1;
    public float jumpforce = 40;
    //public bool onPlatform;
    public GroundCheck groundCheckScript;
    public float gravityInAir = 2f;

    public Vector3 movementVector;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>();
    }

    public bool moving;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.A))
        {
            thisRigidbody2D.AddForce(Vector2.left * force, ForceMode2D.Impulse);
            thisSprite.flipX = false;
        }

        if(Input.GetKey(KeyCode.D))
        {
            thisRigidbody2D.AddForce(Vector2.right * force, ForceMode2D.Impulse);
            thisSprite.flipX = true;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(groundCheckScript.isGrounded)
            {
                thisRigidbody2D.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            }
        }

        if(groundCheckScript.isGrounded == true)
        {
            thisRigidbody2D.gravityScale = 1;
        }

        else
        {
            thisRigidbody2D.gravityScale = gravityInAir;
        }
    }
}
