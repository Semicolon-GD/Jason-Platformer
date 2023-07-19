using System.Linq;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] Collectible[] _collectibles;

    private void Update()
    {
        foreach (var collectible in _collectibles)
        {
            if (collectible.isActiveAndEnabled)
                return;
        }

        Debug.Log("got all gems");
    }
}
