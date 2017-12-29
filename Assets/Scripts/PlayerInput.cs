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
        // Pressed R for quick restart
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Stop all playing sounds
            GameManager.Instance.StopAllSounds();

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
        
        // Suicide key. Just because it exists in GM:S games
        if (Input.GetKeyDown(KeyCode.Q))
        {
            player.Die();
        }

        // Shooting key
        if (Input.GetKeyDown(KeyCode.X))
        {
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
        if (!GameManager.Instance.debugMode)
        {
            return;
        }

        // Go to the next scene
        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            NewSceneManager.NextScene();
        }

        // Go to the previous scene
        if (Input.GetKeyDown(KeyCode.PageDown))
        {
            NewSceneManager.PrevScene();
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
            SaveLoadManager.SaveGame();
        }
    }
}