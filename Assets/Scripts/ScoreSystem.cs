using System;
using UnityEngine;

public class ScoreSystem : MonoBehaviour 
{
    public static event Action<int> OnScoreChanged;
    public static event Action<int> OnHighScoreChanged;

    static int _score;
    static int _highScore;

    void Start()
    {
        _highScore = PlayerPrefs.GetInt("HighScore");
    }

    public static void Add(int points)
    {
        _score += points;
        if (_score>_highScore)
        {
            _highScore = _score;
            OnHighScoreChanged.Invoke(_highScore);
            PlayerPrefs.SetInt("HighScore", _highScore);
        }
        OnScoreChanged.Invoke(_score);
    }
}
