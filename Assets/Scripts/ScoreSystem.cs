using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreSystem 
{
   static int _score;

    public static void Add(int points)
    {
        _score += points;
    }
}
