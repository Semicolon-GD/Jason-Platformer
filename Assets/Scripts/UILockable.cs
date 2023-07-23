using UnityEngine;


public class UILockable : MonoBehaviour
{
    private void OnEnable()
    {
        var startButton = GetComponent<UIStartLevelButton>();
        string key = startButton.LevelName + " Unlocked"; //"Level1 Unlocked"
        int unlocked = PlayerPrefs.GetInt(key, 0);

        if (unlocked == 0)
        {
            gameObject.SetActive(false);
        }
    }

    [ContextMenu("Clear a Level Key")]
    void ClearLevelUnlocked()
    {
        var startButton = GetComponent<UIStartLevelButton>();
        string key = startButton.LevelName + " Unlocked"; //"Level1 Unlocked"
        PlayerPrefs.DeleteKey(key);
    }

    [ContextMenu("Clear All Levels")]
    void ClearAllLevelsUnlocked()
    {
        PlayerPrefs.DeleteAll();
    }
}

