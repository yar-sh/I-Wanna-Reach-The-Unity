///////////////////////////////////////////////////////////////////////
//
//      SaveLoadManager.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

// Structure that represents all the data that is being saved
[System.Serializable]
public struct GameData
{
    public bool valid;
    public int sceneIndex;
    public int playerX;
    public int playerY;
    public float time;
    public uint deaths;
    public bool facingRight;
    public float lastLightsOutTime;
    public bool gameClear;
}

// Class for saving and loading game data
public static class SaveLoadManager
{
    public readonly static GameData defaultData = new GameData
    {
        valid = false,
        sceneIndex = -1,
        playerX = 0,
        playerY = 0,
        time = 0,
        deaths = 0,
        facingRight = true,
        lastLightsOutTime = 5.0f,
        gameClear = false,
    };

    public static GameData data = defaultData;

    // Saves game by updating the current data
    public static void SaveGame()
    {
        GameObject player = GameObject.Find("Player");

        // Update all this
        data.playerX = (int)Mathf.Round(player.transform.position.x);
        data.playerY = (int)Mathf.Round(player.transform.position.y);
        data.sceneIndex = NewSceneManager.SceneIndex;
        data.facingRight = player.GetComponent<Player>().faceDir == 1;
        data.valid = true;

        // And save
        SaveCurrentData();
    }

    // Saves game by using the current data
    public static void SaveCurrentData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create("save");
        bf.Serialize(file, data);
        file.Close();
    }

    // Loads game from save file
    public static void LoadGame()
    {
        if (File.Exists("save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open("save", FileMode.Open);
            data = (GameData)bf.Deserialize(file);
            file.Close();
        }
        else
        {
            data.valid = false;
        }
    }
}
