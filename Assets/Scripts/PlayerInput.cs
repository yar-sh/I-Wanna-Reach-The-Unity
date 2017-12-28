///////////////////////////////////////////////////////////////////////
//
//      PlayerInput.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Camera c = GameObject.Find("Camera").GetComponent<Camera>();

            Vector3 pos = transform.position;
            Vector3 mousePos = c.ScreenToWorldPoint(Input.mousePosition);

            pos.x = mousePos.x;
            pos.y = mousePos.y;

            transform.position = pos;
            player.isFrozen = true;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            GameManager.Instance.SaveLoadManager.SaveGame();
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            player.isFrozen = false;
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.SetMoveDir(1);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.SetMoveDir(-1);
        }
        else
        {
            player.SetMoveDir(0);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            player.Die();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            // Get save data
            GameData data = GameManager.Instance.SaveLoadManager.data;

            // If the last save was made in the other room and the save data is valid, then go to that room
            if (data.sceneIndex != GameManager.Instance.NewSceneManager.SceneIndex &&
                data.valid)
            {
                GameManager.Instance.NewSceneManager.GotoScene(data.sceneIndex);
            }
            else
            {
                // Otherwise (player is in the same room where save was made) reload the room
                GameManager.Instance.NewSceneManager.ReloadScene();
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            player.Shoot();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            player.OnJumpInputDown();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            player.OnJumpInputUp();
        }
    }
}