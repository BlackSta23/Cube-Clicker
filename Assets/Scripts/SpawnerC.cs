using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerC : MonoBehaviour
{
    // настройки
    [SerializeField] GameObject[] cubePrefab;
    [SerializeField] Text timerText, scoreText;
    [SerializeField] float spawnCooldown = 1f, startCooldown = 1f;//, timerScale = 40f;

    // публичные
    public bool isGameActive;
    public List<GameObject> cubes = new List<GameObject>();

    // закрытые
    int spawnOffset = 11;
    float time = 100;
    Vector3Int spawnPos;

    public void Start()
    {
        isGameActive = true;
        MainM.Instance.score = 0;
        Invoke("StartGame", startCooldown);
        StartCoroutine(SpawnCubes());
    }
    void StartGame()
    {
        StartCoroutine(SpawnCubes());
        StartCoroutine(ChangeTime());
    }

    IEnumerator SpawnCubes()
    {
        while (isGameActive)
        {
            int x = Random.Range(-2, 3);
            int y = Random.Range(-2, 3);
            spawnPos = new Vector3Int(spawnOffset * x, spawnOffset * y, 127);
            if (CheckCoords(spawnPos))
            {
                int r = Random.Range(0, cubePrefab.Length);
                GameObject cube = Instantiate(cubePrefab[r], spawnPos, Quaternion.identity, transform);
                cubes.Add(cube);
            }
            yield return new WaitForSeconds(spawnCooldown);
        }
    }
    bool CheckCoords(Vector3Int pos)
    {
        foreach (GameObject go in cubes)
            if (go.transform.position == pos)
                return false;
        return true;
    }
    public void RemoveCube(GameObject cube, int time)
    {
        cubes.Remove(cube);
        AddTime(time);
    }
    void AddTime(int i)
    {
        MainM.Instance.score += i;
        time += i;
        timerText.text = "Time left: " + time;
        scoreText.text = "Score: " + MainM.Instance.score;
    }

    IEnumerator ChangeTime()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnCooldown * 40 * Time.deltaTime);
            time--;
            spawnCooldown -= 0.01f;
            timerText.text = "Time left: " + time;
            if (time <= 0)
            {
                isGameActive = false;
                
                GetComponent<PlayerC>().GameOver();
            }
        }
    }
}
