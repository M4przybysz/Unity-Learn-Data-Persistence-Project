using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    private string playerName = "";
    public bool isPlayerNameSet = false;
    private InputField nameInput;

    private void Start()
    {
        nameInput = GameObject.Find("NameInput").GetComponent<InputField>();
    }

    public void SetPlayerName()
    {
        playerName = nameInput.text;
        if (playerName.Length > 0)
        {
            isPlayerNameSet = true;
        }
    }

    public void StartGame()
    {
        if (isPlayerNameSet)
        {
            DataPersistance.Instance.currentPlayerName = playerName;
            SceneManager.LoadScene(1);
        }
    }

    public void ExitGame()
    {
        DataPersistance.Instance.SaveHighScore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
