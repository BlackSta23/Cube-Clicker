using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [SerializeField] Text maxScoreText;
    [SerializeField] InputField playerName;

    void Start()
    {
        maxScoreText.text = "Max Score: " + MainM.Instance.PlayerRecordName + " - " + MainM.Instance.MaxScore;
        playerName.text = MainM.Instance.PlayerName;
    }

    public void StartGame()
    {
        MainM.Instance.PlayerName = playerName.text;
        Debug.Log(MainM.Instance.PlayerName);
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        MainM.Instance.SaveNameAndScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
