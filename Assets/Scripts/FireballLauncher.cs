using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballLauncher : MonoBehaviour
{
    [SerializeField] Fireball _fireballPrefab;

    private void Start()
    {
        Instantiate(_fireballPrefab,transform.position,Quaternion.identity);
    }
}
