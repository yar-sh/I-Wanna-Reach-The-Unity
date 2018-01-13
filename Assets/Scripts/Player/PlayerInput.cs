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
        // Pressed C for quick restart
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (player.isFrozen && !player.isDead)
            {
                return;
            }

            // Stop all playing sounds
            GameManager.Instance.StopAllSounds();

            SaveLoadManager.SaveCurrentData();

            // Get saved data
            GameData data = SaveLoadManager.data;

            // If the last save was made in the other room and the save data is valid, then go to that room
            if (data.sceneIndex != NewSceneManager.SceneIndex && data.valid)
            {
                NewSceneManager.GotoScene(data.sceneIndex);
            }
            else
            {
                // Otherwise (player is in the same room where save was made) reload the room
                NewSceneManager.ReloadScene();
            }
        }
        
        // Escape for going back into the main menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            player.isFrozen = true;
            SaveLoadManager.SaveCurrentData();

            NewSceneManager.GotoScene("sMainMenu", 0.5f,0.5f);
        }

        // Debug mode or game clear allow you to go to the stage hub/menu
        if (Input.GetKeyDown(KeyCode.F5) && (GameManager.debugMode || SaveLoadManager.data.gameClear))
        {
            NewSceneManager.GotoScene("sStageHub", 0.5f, 1.0f);
        }

        // Everything below this if statement requires player to be alive
        if (player.isDead)
        {
            return;
        }
        
        // Move left-right
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

        // Tab press to show stats
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            player.statsDisplayComponent.Show();
        }

        // Tab release to hide stats
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            player.statsDisplayComponent.Hide();
        }

        // Suicide key. Just because it exists in GM:S games
        if (Input.GetKeyDown(KeyCode.Q))
        {
            player.Die();
        }

        // Shooting key
        if (Input.GetKeyDown(KeyCode.X))
        {
            // Shooting when colliding on save will result in saving a game
            if (player.collidingSave != null)
            {
                player.collidingSave.GetComponent<Save>().SaveGame();
            }

            player.Shoot();
        }

        // Jumping key down
        if (Input.GetKeyDown(KeyCode.Z))
        {
            player.OnJumpInputDown();
        }

        // Jumping key up
        if (Input.GetKeyUp(KeyCode.Z))
        {
            player.OnJumpInputUp();
        }
        
        // Everything below this if statement requires debugMode enabled
        if (!GameManager.debugMode)
        {
            return;
        }

        // When left control is held - player will be moved to mouse cursor coordinates
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

        // Make player be affected by gravity again when left control is released
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            player.isFrozen = false;
        }

        // Save player at the current spot
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameManager.Instance.PlaySound("Save");
            SaveLoadManager.SaveGame();
        }
    }
}