using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int CoinsCollected;

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();

        if (player == null)
            return;


        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

        UpdateCoinAndScore();

        GetComponent<AudioSource>().Play();
    }

    public static void UpdateCoinAndScore()
    {
        CoinsCollected++;
        ScoreSystem.Add(100);
    }
}
