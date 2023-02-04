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
    [SerializeField] float _maxJumpDuration=.1f;

    Vector2 _startPosition;
    int _jumpsRemaining;
    float _fallTimer;
    float _jumpTimer;
    Rigidbody2D _rigidbody2D;
    Animator _animator;
    SpriteRenderer _spriteRenderer;
    float _horizontal;
    bool _isGrounded;

    void Start()
    {
        _startPosition = transform.position;
        _jumpsRemaining = _maxJumps;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        UpdateIsGrounded();
        ReadHorizontalInput();
        MoveHorizontal();

        UpdateAnimator();

        UpdateSpriteDirection();

        if (ShouldStartJump())
            Jump();
        else if (ShouldContinueJump())
            ContinueJump();
        JumpTimerControll();
        ManageFall();
    }



    #region Methods
    void JumpTimerControll()
    {
        _jumpTimer += Time.deltaTime;
    }

    void ManageFall()
    {
        if (_isGrounded && _fallTimer > 0)
        {
            _fallTimer = 0;
            _jumpsRemaining = _maxJumps;
        }
        else
        {
            _fallTimer += Time.deltaTime;
            var _downForce = _downPull * _fallTimer * _fallTimer;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _rigidbody2D.velocity.y - _downForce);
        }
    }
    void ContinueJump()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpVelocity);
        _fallTimer = 0;
    }

    bool ShouldContinueJump()
    {
        return Input.GetButton("Jump") && _jumpTimer <= _maxJumpDuration;
    }

    void Jump()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpVelocity);
        _jumpsRemaining--;
        _fallTimer = 0;
        _jumpTimer = 0;
    }

    bool ShouldStartJump()
    {
        return Input.GetButtonDown("Jump") && _jumpsRemaining > 0;
    }

    void MoveHorizontal()
    {
        if (Mathf.Abs(_horizontal) >= 1)
        {
            _rigidbody2D.velocity = new Vector2(_horizontal, _rigidbody2D.velocity.y);
        }
    }

    void ReadHorizontalInput()
    {
        _horizontal = Input.GetAxis("Horizontal") * _speed;
    }

    void UpdateSpriteDirection()
    {
        if (_horizontal != 0)
        {

            _spriteRenderer.flipX = _horizontal < 0;
        }
    }

    void UpdateAnimator()
    {
        bool walking = _horizontal != 0;
        _animator.SetBool("Walk", _horizontal != 0);
    }

    void UpdateIsGrounded()
    {
        var hit = Physics2D.OverlapCircle(_feet.position, .1f, LayerMask.GetMask("Default", "Mushroom"));
        _isGrounded = hit != null; 
    }

    internal void ResetToStart()
    {
        transform.position = _startPosition;
    }

    #endregion
}
