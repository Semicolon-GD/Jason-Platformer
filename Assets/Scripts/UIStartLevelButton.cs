using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class UIStartLevelButton : MonoBehaviour
{
    [SerializeField] string _levelName;

    public string LevelName => _levelName;

    public void LoadLevel()
    {
        SceneManager.LoadScene(_levelName);
    }
    //private void OnValidate()
    //{
    //    GetComponentInChildren<TMP_Text>()?.SetText(_levelName);
    //}
}
