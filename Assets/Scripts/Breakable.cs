using System;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.collider.GetComponent<Player>();
        if (player == null)
            return;

        if (collision.contacts[0].normal.y > 0)
        {
            TakeHit();
        }
    }

    void TakeHit()
    {
        gameObject.SetActive(false);
    }
}
