using System.Linq;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] Collectible[] _collectibles;

    private void Update()
    {
        if (_collectibles.Any(t => t.gameObject.activeSelf == true))
            return;

        Debug.Log("got all gems");
    }
}
