using UnityEngine;
using UnityEngine.Events;

public class ToggleSwitch : MonoBehaviour
{
    [SerializeField] Sprite _toggleLeft;
    [SerializeField] Sprite _toggleRight;
    [SerializeField] UnityEvent _onLeft;
    [SerializeField] UnityEvent _onRight;

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
            SetPosition(true);
        else if(wasOnRight == false && playerWalkingLeft)
            SetPosition(false);

    }

    void SetPosition(bool right)
    {
        if (right)
        {
            _spriteRenderer.sprite = _toggleRight;
            _onRight.Invoke();
        }
        else
        {
            _spriteRenderer.sprite = _toggleLeft;
            _onLeft.Invoke();
        }
       
    }

}
