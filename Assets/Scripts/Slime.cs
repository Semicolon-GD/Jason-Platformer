using System;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] Transform _leftSensor;
    [SerializeField] Transform _rightSensor;
    Rigidbody2D _rigidbody2D;
    float _direction = -1;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rigidbody2D.velocity = new Vector2(_direction, _rigidbody2D.velocity.y);

        if (_direction<0)
            ScanSensor(_leftSensor);
        else
            ScanSensor(_rightSensor);


    }

    private void ScanSensor(Transform sensor)
    {
        var result = Physics2D.Raycast(sensor.position, Vector2.down, 0.1f);
        if (result.collider == null)
            TurnAround();

        var sideResult = Physics2D.Raycast(sensor.position, new Vector2(_direction,0), 0.1f);
        if (sideResult.collider != null)
            TurnAround();
    }

    private void TurnAround()
    {
        _direction *= -1;
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = _direction > 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.collider.GetComponent<Player>();
        if (player == null)
            return;

        var contact = collision.contacts[0];
        Vector2 normal = contact.normal;
        Debug.Log("Normal = " + normal);

        if (normal.y <= -0.5)
            Die();
        else
            player.ResetToStart();
        
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
