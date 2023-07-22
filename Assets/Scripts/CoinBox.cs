using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : HittableFromBelow
{
    [SerializeField] int _totalCoins = 3;
    int _remainingCoins;

    protected override bool CanUse => _remainingCoins>0; 

    void Start()
    {
        _remainingCoins = _totalCoins;
    }


    protected override void Use()
    {
        base.Use();
        Coin.CoinsCollected++;
        _remainingCoins--;
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    var player = collision.collider.GetComponent<Player>();
    //    if (player == null)
    //        return;
    //    if (collision.contacts[0].normal.y > 0 && _remainingCoins > 0)
    //    {
    //        Coin.CoinsCollected++;
    //        _remainingCoins--;
    //        if (_remainingCoins <= 0)
    //            GetComponent<SpriteRenderer>().sprite = _usedSprite;

    //    }
    //}                   
}
