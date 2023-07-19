using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] List<Collectible> _collectibles;
    TMP_Text _remainingText;

    private void Start()
    {
        _remainingText = GetComponentInChildren<TMP_Text>();
    }

    private void Update()
    {
        int countRemaining = 0;
        foreach (var collectible in _collectibles)
        {
            if (collectible.isActiveAndEnabled)
                countRemaining++;
        }

        _remainingText?.SetText(countRemaining.ToString());

        if (countRemaining > 0)
            return;
        Debug.Log("got all gems");
    }

    void OnValidate()
    {
        _collectibles = _collectibles.Distinct().ToList();  
    }
}
