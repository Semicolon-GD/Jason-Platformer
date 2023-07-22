using UnityEngine;
using UnityEngine.Events;

public class ToggleSwitch : MonoBehaviour
{
    [SerializeField] Sprite _toggleLeft;
    [SerializeField] Sprite _toggleRight;
    [SerializeField] Sprite _toggleCenter;

    [SerializeField] UnityEvent _onLeft;
    [SerializeField] UnityEvent _onRight;
    [SerializeField] UnityEvent _onCenter;

    SpriteRenderer _spriteRenderer;
    ToggleDirection _currentDirection;
    

    enum ToggleDirection
    {
        Left,
        Center,
        Right,
    }

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
            SetToogleDirection(ToggleDirection.Right);
        else if(wasOnRight == false && playerWalkingLeft)
            SetToogleDirection(ToggleDirection.Left);

    }

    void SetToogleDirection(ToggleDirection direction)
    {
        if (_currentDirection == direction)
            return;

        _currentDirection = direction;
        switch (direction)
        {
            case ToggleDirection.Left:
                _spriteRenderer.sprite = _toggleLeft;
                _onLeft.Invoke();
                break;
            case ToggleDirection.Center:
                _spriteRenderer.sprite = _toggleCenter;
                _onCenter.Invoke();
                break;
            case ToggleDirection.Right:
                _spriteRenderer.sprite = _toggleRight;
                _onRight.Invoke();
                break;
            default:
                break;
        }

       
    }

}
