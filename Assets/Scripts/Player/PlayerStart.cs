///////////////////////////////////////////////////////////////////////
//
//      PlayerStart.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Used as a starting point in the level
public class PlayerStart : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        Vector3 pos = new Vector3(0, 0, -5.0f);
        GameData data = SaveLoadManager.data;
        
        // If player saves in this room - set his coords to the saves ones
        if (data.valid && data.sceneIndex == NewSceneManager.SceneIndex)
        {
            pos.x = data.playerX;
            pos.y = data.playerY;
        }
        else
        {
            // Otherwise use player start coords
            pos.x = transform.position.x;
            pos.y = transform.position.y;
        }

        GameObject newPlayer = Instantiate(player, pos, Quaternion.identity);
        newPlayer.name = player.name;

        //TODO: load the direction player is looking in. SOmehow. No idea how though.

        // If data is invalid (new save) or player is currently in the boss area (autosave on each restart)
        if (!data.valid || NewSceneManager.SceneName == "sBoss")
        {
            SaveLoadManager.SaveGame();
        }

        // If currently in stage hub - give "infinite" jump
        if (NewSceneManager.SceneName == "sStageHub")
        {
            newPlayer.GetComponent<Player>().jumpCount = uint.MaxValue;
        }

        Destroy(gameObject);
    }
}
