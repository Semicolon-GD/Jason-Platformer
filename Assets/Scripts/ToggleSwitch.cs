using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSwitch : MonoBehaviour
{
    [SerializeField] Sprite _toggleLeft;
    [SerializeField] Sprite _toggleRight;

    SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (player == null)
            return;

        bool wasOnRight = collision.transform.position.x > transform.position.x;

        _spriteRenderer.sprite = wasOnRight ? _toggleLeft : _toggleRight;
    }

    //if (collider.contacts[0].normal.x > 0)
    //         GetComponent<SpriteRenderer>().sprite = _toggleLeft;
    //     else if (collider.contacts[0].normal.x< 0)
    //         GetComponent<SpriteRenderer>().sprite = _toggleRight;

}
