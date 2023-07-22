﻿using System;
using UnityEngine;

public class HittableFromBelow : MonoBehaviour
{
    [SerializeField] protected Sprite _usedSprite;
    Animator _animator;

    protected virtual bool CanUse => true;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (CanUse == false)
            return;
        var player = collision.collider.GetComponent<Player>();
        if (player == null)
            return;
        if (collision.contacts[0].normal.y > 0)
        {
            PlayAnimation();
            Use();

            if (CanUse == false)
                GetComponent<SpriteRenderer>().sprite = _usedSprite;
        }
    }

    void PlayAnimation()
    {
        if (_animator != null)
            _animator.SetTrigger("Used");
    }

    protected virtual void Use()
    {
        Debug.Log(gameObject.name);
    }
}
