using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerC : MonoBehaviour
{
    [SerializeField] GameObject gamePlayUi, gameOverUi;
    [SerializeField] Text maxScoreText;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            Physics.Raycast(ray, out hitInfo);
            if (hitInfo.collider != null)
            {
                GameObject target = hitInfo.collider.gameObject;
                if (target.CompareTag("Cube")) // нажали на куб
                {
                    target.GetComponent<CubeC>().Clicked();
                }
                else if (target.CompareTag("Bomb")) // нажали на бомбу
                {
                    GetComponent<SpawnerC>().isGameActive = false;
                    GameOver();
                }
            }
        }
    }
    public void GameOver()
    {
        gamePlayUi.SetActive(false);
        gameOverUi.SetActive(true);
        if (MainM.Instance.score > MainM.Instance.MaxScore)
        {

            MainM.Instance.MaxScore = MainM.Instance.score;
            MainM.Instance.PlayerRecordName = MainM.Instance.PlayerName;
        }
        maxScoreText.text = "Max Score: " + MainM.Instance.PlayerRecordName + " - " + MainM.Instance.MaxScore;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
