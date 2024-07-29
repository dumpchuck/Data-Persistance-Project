using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataHandle : MonoBehaviour
{
    // Static class to save player data, singleton pattern 

    public static PlayerDataHandle Instance;

    public string playerName;

    public int score;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null) // Don't actually need this if-statement because we can't return to menu where Player Data object exists. Could implement? 
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
