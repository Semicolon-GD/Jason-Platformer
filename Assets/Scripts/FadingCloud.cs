using System;
using System.Collections;
using UnityEngine;

public class FadingCloud : HittableFromBelow
{
    [SerializeField] float _resetTime;

    SpriteRenderer _spriteRenderer;
    Collider2D _collider;
    

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
    }
    protected override void Use()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        StartCoroutine(ResetAfterDelay());
    }

    private IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(_resetTime);
    }
}
