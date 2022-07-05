using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainM : MonoBehaviour
{
    public static MainM Instance;

    public int MaxScore, score;
    public string PlayerName, PlayerRecordName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadNameAndScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int MaxScore;
        public string PlayerName;
        public string PlayerRecordName;
    }

    public void SaveNameAndScore()
    {
        SaveData data = new SaveData();
        data.MaxScore = MaxScore;
        data.PlayerName = PlayerName;
        data.PlayerRecordName = PlayerRecordName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadNameAndScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            MaxScore = data.MaxScore;
            PlayerName = data.PlayerName;
            PlayerRecordName = data.PlayerRecordName;
        }
        else
        {
            Debug.Log("No root file");
            MaxScore = 0;
            PlayerName = "";
            PlayerRecordName = "";
        }
    }
}
