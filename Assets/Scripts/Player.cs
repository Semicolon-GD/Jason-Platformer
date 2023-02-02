using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed = 1;
    [SerializeField] float _jumpVelocity = 10;
    [SerializeField] int _maxJumps = 2;
    [SerializeField] Transform _feet;
    [SerializeField] float _downPull=5;

    Vector2 _startPosition;
    int _jumpsRemaining;
    float _fallTimer;
    

    void Start()
    {
        _startPosition = transform.position;
        _jumpsRemaining = _maxJumps;
    }

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


        if (Input.GetButtonDown("Jump") && _jumpsRemaining>0)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,_jumpVelocity);
            _jumpsRemaining--;
            _fallTimer = 0;
        }
        var hit = Physics2D.OverlapCircle(_feet.position, .1f, LayerMask.GetMask("Default"));
        bool isGrounded = hit != null;

        if (isGrounded)
        {
            _fallTimer = 0;
            _jumpsRemaining = _maxJumps;
        }
        else
        {
            _fallTimer += Time.deltaTime;
            var _downForce = _downPull * _fallTimer * _fallTimer;
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y-_downForce);
        }
    }

    internal void ResetToStart()
    {
        transform.position = _startPosition;
    }
}
