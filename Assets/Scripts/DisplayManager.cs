///////////////////////////////////////////////////////////////////////
//
//      DisplayManager.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public struct ResolutionData
{
    public Resolution resolution;
    public uint index;
};

// Class for controlling and adjusting window resolution and fullscreen mode
public class DisplayManager : MonoBehaviour
{
    private uint _resolutionIndex = 0;
    private Resolution[] _resolutions = null;
    private Camera _camera = null;

    public DisplayManager(Resolution[] resolutions, Camera camera)
    {
        _resolutions = resolutions;
        _camera = camera;

        // Have some kind of resolution by default
        // TODO: Reload it from settings in the load process
        ApplyResolution(new ResolutionData {
            resolution = new Resolution
            {
                width = Screen.width,
                height = Screen.height,
            },
            index = 0,
        });
    }

    // Sets window fullscreen
    public bool fullscreen
    {
        get
        {
            return Screen.fullScreen;
        }

        set
        {
            Screen.fullScreen = value;
        }
    }

    // Applies resolution to the screen and adjusts camera view
    public void ApplyResolution(ResolutionData resolutionData)
    {
        Resolution res = resolutionData.resolution;

        // Set screen size without changing fullscreen mode
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);

        // Keep track of the currently applied resolution
        _resolutionIndex = resolutionData.index;
        
        // This doesn't really change, but let's recalculate it anyway
        _camera.orthographicSize = GM.TILE_SIZE_PX * GM.N_TILES_VER / 2;
        _camera.GetComponent<CameraAdjuster>().Offset = new Vector2(
            GM.TILE_SIZE_PX * GM.N_TILES_HOR / 2,
            GM.TILE_SIZE_PX * GM.N_TILES_VER / 2 - GM.TILE_SIZE_PX
        );
        
        // If aspect ratio is less than 16:9 (eg: 4:3), then we'll have camera "track"
        // the player so the entire level still fits on the screen
        _camera.GetComponent<CameraAdjuster>().Tracking = (((float)res.width / res.height) < 1.76f);

        Debug.Log("New resolution: " + res.ToString());
    }

    // Returns next resolution from the default list
    public ResolutionData NextResolution()
    {
        _resolutionIndex++;

        if (_resolutionIndex == _resolutions.Length)
            _resolutionIndex = 0;
        
        return new ResolutionData
        {
            resolution = _resolutions[_resolutionIndex],
            index = _resolutionIndex,
        };
    }

    // Returns previous resolution from the default list
    public ResolutionData PrevResolution()
    {
        _resolutionIndex--;

        if (_resolutionIndex == uint.MaxValue)
            _resolutionIndex = (uint)_resolutions.Length - 1;
        
        return new ResolutionData
        {
            resolution = _resolutions[_resolutionIndex],
            index = _resolutionIndex,
        };
    }
}
