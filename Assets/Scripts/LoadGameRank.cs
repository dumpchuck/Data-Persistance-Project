using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadGameRank : MonoBehaviour
{
    // Used to display player info 

    public TextMeshProUGUI bestPlayerName;

    // Static variables to hold player info across scenes 
    private static int bestScore;
    private static string bestPlayer;

    // Start is called before the first frame update
    void Awake()
    {
        LoadGameScore();
        
    }

    private void SetBestPlayer()
    {
        if (bestPlayer == null && bestScore == 0)
        {
            bestPlayerName.text = "";
        }
        else
        {
            bestPlayerName.text = $"Best Score - {bestPlayer}: {bestScore}";
        }
    }

    public void LoadGameScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            // Debug.Log(json);

            bestPlayer = data.theBestPlayer;
            bestScore = data.highestScore;
            SetBestPlayer();
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string theBestPlayer;
        public int highestScore;
    }
}
