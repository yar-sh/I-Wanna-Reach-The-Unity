///////////////////////////////////////////////////////////////////////
//
//      PlayerStart.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class PlayerStart : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        Vector3 pos = new Vector3(0, 0, -5.0f);
        GameData data = SaveLoadManager.data;
        
        if (data.valid && data.sceneIndex == NewSceneManager.SceneIndex)
        {
            pos.x = data.playerX;
            pos.y = data.playerY;
        }
        else
        {
            pos.x = transform.position.x;
            pos.y = transform.position.y;
        }

        GameObject newPlayer = Instantiate(player, pos, Quaternion.identity);
        newPlayer.name = player.name;
        
        if (!data.valid)
        {
            SaveLoadManager.SaveGame();
        }

        Destroy(gameObject);
    }
}
