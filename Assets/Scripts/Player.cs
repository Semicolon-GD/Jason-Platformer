using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed = 1;
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal")*_speed;
        var rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(horizontal,rigidbody2D.velocity.y);
        var animator = GetComponent<Animator>();

        animator.SetBool("Walk", horizontal!=0);


        if (horizontal!=0)
        {
            var spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.flipX = horizontal < 0;
        }
        
    }
}
