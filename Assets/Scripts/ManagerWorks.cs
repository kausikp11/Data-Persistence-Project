using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ManagerWorks : MonoBehaviour
{
    public static ManagerWorks Instance;
    public string CurrentPlayer;
    public string Name;
    public int highScore;
    public bool GameOver = false;

    private void Awake(){
        if (Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }
    [System.Serializable]
    class SaveData
    {
        public string Name;
        public int highScore;
    }
    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.Name = Name;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
    
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Name = data.Name;
            highScore = data.highScore;
        }
    }
}
