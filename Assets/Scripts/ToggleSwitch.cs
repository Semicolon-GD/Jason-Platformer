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


    private void OnTriggerStay2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (player == null)
            return;

        var playerRigidbody = player.GetComponent<Rigidbody2D>();
        if (playerRigidbody == null)
            return;

        bool wasOnRight = collision.transform.position.x > transform.position.x;
        bool playerWalkingRight = playerRigidbody.velocity.x > 0;
        bool playerWalkingLeft = playerRigidbody.velocity.x < 0;

        if (wasOnRight && playerWalkingRight)
        {
            _spriteRenderer.sprite = _toggleRight;
        }
        else if(wasOnRight == false && playerWalkingLeft)
        {
            _spriteRenderer.sprite = _toggleLeft;
        }
    }

    //if (collider.contacts[0].normal.x > 0)
    //         GetComponent<SpriteRenderer>().sprite = _toggleLeft;
    //     else if (collider.contacts[0].normal.x< 0)
    //         GetComponent<SpriteRenderer>().sprite = _toggleRight;

}
