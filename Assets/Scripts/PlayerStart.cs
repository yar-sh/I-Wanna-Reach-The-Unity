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
        GameManager.Instance.SaveLoadManager.LoadGame();

        Vector3 pos = new Vector3(0, 0, -5.0f);
        GameData data = GameManager.Instance.SaveLoadManager.data;
        
        if (data.valid && data.sceneIndex == GameManager.Instance.NewSceneManager.SceneIndex)
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
            GameManager.Instance.SaveLoadManager.SaveGame();
        }

        Destroy(gameObject);
    }
}
