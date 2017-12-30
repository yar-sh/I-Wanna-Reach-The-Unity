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
public class DisplayManager
{
    uint resolutionIndex = 0;
    Resolution[] resolutions;
    Resolution resolution;
    CameraAdjuster camAdjuster;

    // Constructs a DisplayManager with all available resolutions and camera CameraAdjuster
    public DisplayManager(Resolution[] _resolutions, CameraAdjuster _camAdjuster)
    {
        camAdjuster = _camAdjuster;
        resolutions = _resolutions;
        
        // TODO: Check if Unity saves chosen screen resolution

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

    // Returns current resolution
    public Resolution Resolution
    {
        get
        {
            return resolution;
        }
    }

    // Returns current resolution index
    public uint ResolutionIndex
    {
        get
        {
            return resolutionIndex;
        }
    }

    // Applies resolution to the screen and adjusts camera view
    public void ApplyResolution(uint resIndex)
    {
        ApplyResolution(new ResolutionData {
            resolution = resolutions[resIndex],
            index = resIndex,
        });
    }

    // Applies resolution to the screen and adjusts camera view
    public void ApplyResolution(ResolutionData resolutionData)
    {
        resolution = resolutionData.resolution;

        // Set screen size without changing fullscreen mode
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        // Keep track of the currently applied resolution
        resolutionIndex = resolutionData.index;

        // If aspect ratio is less than 16:9 (eg: 4:3), then we'll have camera "track"
        // the player so the entire level still fits on the screen
        camAdjuster.NewResolution(resolution);
    }

    // Returns next resolution from the default list
    public ResolutionData NextResolution()
    {
        resolutionIndex++;

        if (resolutionIndex == resolutions.Length)
        {
            resolutionIndex = 0;
        }
        
        return new ResolutionData
        {
            resolution = resolutions[resolutionIndex],
            index = resolutionIndex,
        };
    }

    // Returns previous resolution from the default list
    public ResolutionData PrevResolution()
    {
        resolutionIndex--;

        if (resolutionIndex == uint.MaxValue)
        {
            resolutionIndex = (uint)resolutions.Length - 1;
        }
        
        return new ResolutionData
        {
            resolution = resolutions[resolutionIndex],
            index = resolutionIndex,
        };
    }
}
