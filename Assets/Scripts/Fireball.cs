using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] float _launchForce=8;
    [SerializeField] float _bounceForce = 5f;
    int _bounceRemaining=3;
    Rigidbody2D _rigidbody;

    public float Direction { get; set; }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
       _rigidbody.velocity= new Vector2(_launchForce* Direction,_bounceForce);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        _bounceRemaining--;
        if (_bounceRemaining < 0)
            Destroy(gameObject);
        else
            _rigidbody.velocity = new Vector2(_launchForce * Direction, _bounceForce);
    }
}
