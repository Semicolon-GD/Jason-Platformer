using System;
using System.Collections;
using UnityEngine;

public class Slime : MonoBehaviour, ITakeDamage
{
    [SerializeField] Transform _leftSensor;
    [SerializeField] Transform _rightSensor;
    [SerializeField] Sprite _deadSprite;
    Rigidbody2D _rigidbody2D;
    AudioSource _audioSource;
    float _direction = -1;
    

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        _rigidbody2D.velocity = new Vector2(_direction, _rigidbody2D.velocity.y);

        if (_direction<0)
            ScanSensor(_leftSensor);
        else
            ScanSensor(_rightSensor);


    }

    public void TakeDamage()
    {
        StartCoroutine(Die());
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
            TakeDamage();
        else
            player.ResetToStart();
        
    }

    IEnumerator Die()
    {
        GetComponent<Animator>().enabled=false;
        GetComponent<Collider2D>().enabled = false;
        enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = _deadSprite;
        if (_audioSource != null)
            _audioSource.Play();
        float alpha = 1;

        while (alpha>0)
        {
            yield return null;
            alpha -= Time.deltaTime;
            spriteRenderer.color = new Color(1, 1, 1, alpha);
        }
        

    }
}
