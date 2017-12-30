///////////////////////////////////////////////////////////////////////
//
//      CameraAdjuster.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Adjusts camera for different screen resolutions (supports 4:3 and 16:9 aspect ratios)
public class CameraAdjuster : MonoBehaviour
{
    public bool disableTrackerInThisLevel = false;

    bool trackPlayerByResolution = false;
    Vector3 offset = new Vector3(544, 272, -100);
    GameObject player = null;
    Camera cam;
    
    void Start()
    {
        cam = GetComponent<Camera>();

        // These settings are always the same. They are just based on the level 16:9 (1088x608) size
        cam.orthographicSize = GM.TILE_SIZE_UNITS * GM.N_TILES_VER / 2;
        offset.x = GM.TILE_SIZE_UNITS * GM.N_TILES_HOR / 2;
        offset.y = GM.TILE_SIZE_UNITS * GM.N_TILES_VER / 2 - GM.TILE_SIZE_UNITS;
    }

    void Update()
    {
        // Optimizations
        if (!trackPlayerByResolution || disableTrackerInThisLevel)
        {
            return;
        }

        if (player != null || GameObject.FindGameObjectWithTag("Player") != null)
        {
            // Cache player gameobject
            player = GameObject.FindGameObjectWithTag("Player");

            // Do not track the player when he is dead
            if (player.GetComponent<Player>().isDead)
            {
                return;
            }

            // Apply tracking coordinates
            Vector3 newPos = player.transform.position;
            newPos.x = Mathf.Max(newPos.x, cam.orthographicSize * cam.aspect);
            newPos.x = Mathf.Min(newPos.x, GM.N_TILES_HOR * GM.TILE_SIZE_UNITS - cam.orthographicSize * cam.aspect);
            newPos.y = transform.position.y;
            newPos.z = transform.position.z;
            transform.position = newPos;
        }
    }
    
    // Adjusts camera's behaviour based on the newly applied resolution
    public void NewResolution(Resolution res)
    {
        // When aspect ratio is not 16:9 (1.7~) (eg 4:3 - 1.3~) then enable camera tracking the player
        // so the entire level still fits on the screen
        if (res.width / (float)res.height < 1.76f)
        {
            trackPlayerByResolution = true;
        }
        else
        {
            trackPlayerByResolution = false;
            transform.position = offset;
        }
    }
}
