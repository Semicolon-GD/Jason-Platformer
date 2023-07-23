using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStartLevelButton : MonoBehaviour
{
    [SerializeField] string _levelName;

    public void LoadLevel()
    {
        SceneManager.LoadScene(_levelName);
    }

    //private void OnValidate()
    //{
    //    GetComponentInChildren<TMP_Text>()?.SetText(_levelName);
    //}
}
