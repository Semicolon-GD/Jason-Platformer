using UnityEngine;

public class FireballLauncher : MonoBehaviour
{
    [SerializeField] Fireball _fireballPrefab;
    [SerializeField] float _fireRate;

    Player _player;
    string _fireButton;
    string _horizontalAxis;
    float _nextFireTime;
    

    void Start()
    {
        _player = GetComponent<Player>();
        _fireButton = $"P{_player.PlayerNumber}Fire";
        _horizontalAxis = $"P{_player.PlayerNumber}Horizontal";
        
    }

    void Update()
    {
        if (Input.GetButtonDown(_fireButton) && Time.time >= _nextFireTime)
        {
            var horizontal = Input.GetAxis(_horizontalAxis);
            Fireball fireball= Instantiate(_fireballPrefab, transform.position, Quaternion.identity);
            fireball.Direction = horizontal >= 0 ? 1f : -1f;
            _nextFireTime = Time.time + _fireRate;
        }
    }
}
