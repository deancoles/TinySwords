using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Public allows us to see and edit inside of the Unity inspector
    public float speed = 5; // Movement Speed
    public int facingDirection = 1; // Sprite facing right


    public Rigidbody2D rb;
    public Animator anim;


    // Fixed Update is called fifty times per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(horizontal > 0 && transform.localScale.x < 0 ||  // Pressing right but facing left
            horizontal < 0 && transform.localScale.x > 0)   // Pressing left but facing right
        {
            Flip();
        }

        // Matches animator's float to button presses
        anim.SetFloat("horizontal", Mathf.Abs(horizontal));
        anim.SetFloat("vertical", Mathf.Abs(vertical));

        rb.velocity = new Vector2(horizontal, vertical) * speed;
    }

    // Change facing direction
    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);   // Flip sprite x axis
    }
}
