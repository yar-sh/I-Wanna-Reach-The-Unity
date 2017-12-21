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
    public float playerX;
    public float playerY;
}

public class SaveLoadManager : MonoBehaviour
{
    public void SaveGame()
    {
        GameObject player = GameObject.Find("Player");
        GameData data = new GameData
        {
            playerX = player.transform.position.x,
            playerY = player.transform.position.y,
        };

        // TODO: Room number
        data.playerX = Mathf.Round(data.playerX);
        data.playerY = Mathf.Round(data.playerY);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create("save");
        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadGame()
    {
        // TODO: Load on game load
        GameObject player = GameObject.Find("Player");
        GameData data = new GameData();

        // TODO: Room checks, save exists checks, etc
        if (File.Exists("save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open("save", FileMode.Open);
            data = (GameData)bf.Deserialize(file);
            file.Close();
        }

        Debug.Log("LoadedX: " + data.playerX + ", LoadedY: " + data.playerY);
        player.transform.position = new Vector3(data.playerX, data.playerY);
    }
}
