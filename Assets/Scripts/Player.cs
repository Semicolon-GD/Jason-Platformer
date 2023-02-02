using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed = 1;
    [SerializeField] float _jumpForce = 200;
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal")*_speed;
        var rigidbody2D = GetComponent<Rigidbody2D>();
        if (Mathf.Abs(horizontal)>=1)
        {
            rigidbody2D.velocity = new Vector2(horizontal, rigidbody2D.velocity.y);
        }
        
        var animator = GetComponent<Animator>();

        animator.SetBool("Walk", horizontal!=0);


        if (horizontal!=0)
        {
            var spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = horizontal < 0;
        }


        if (Input.GetButtonDown("Fire1"))
        {
            rigidbody2D.AddForce(Vector2.up*_jumpForce);
        }
    }
}
