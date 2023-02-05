using UnityEngine;

public class Slime : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;

   void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.collider.GetComponent<Player>();
        if (player == null)
            return;

        player.ResetToStart();
        
    }

}
