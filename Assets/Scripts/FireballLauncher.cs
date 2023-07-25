using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballLauncher : MonoBehaviour
{
    [SerializeField] Fireball _fireballPrefab;
    Player _player;
    string _fireButton;

   void Start()
    {
        _player = GetComponent<Player>();
        _fireButton = $"P{_player.PlayerNumber}Fire";
        
    }

    void Update()
    {
        if (Input.GetButtonDown(_fireButton))
        {
            Instantiate(_fireballPrefab, transform.position, Quaternion.identity);
        }
    }
}
