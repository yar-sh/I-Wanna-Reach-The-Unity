///////////////////////////////////////////////////////////////////////
//
//      SaveLoadManager.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


[System.Serializable]
public struct GameData
{
    public bool valid;
    public int sceneIndex;
    public int playerX;
    public int playerY;
}

public static class SaveLoadManager
{
    public static GameData data = new GameData
    {
        valid = false,
        sceneIndex = -1,
        playerX = 0,
        playerY = 0,
    };

    public static void SaveGame()
    {
        GameObject player = GameObject.Find("Player");
        data.playerX = (int)Mathf.Round(player.transform.position.x);
        data.playerY = (int)Mathf.Round(player.transform.position.y);
        data.sceneIndex = NewSceneManager.SceneIndex;
        data.valid = true;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create("save");
        bf.Serialize(file, data);
        file.Close();
    }

    public static void LoadGame()
    {
        // TODO: Room checks, save exists checks, etc
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
