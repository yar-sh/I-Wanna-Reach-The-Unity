///////////////////////////////////////////////////////////////////////
//
//      CameraAdjuster.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class CameraAdjuster : MonoBehaviour
{
    public bool IsTracking = false;
    bool _TrackingByResolution = false;
    Vector2 _Offset = new Vector2(512,256);

    public Vector2 Offset
    {
        get
        {
            return _Offset;
        }

        set
        {
            transform.position -= new Vector3(_Offset.x, _Offset.y);
            _Offset = value;
            transform.position += new Vector3(_Offset.x, _Offset.y);
        }
    }

    public bool TrackingByResolution
    {
        get
        {
            return _TrackingByResolution;
        }

        set
        {
            _TrackingByResolution = value;
            Debug.Log("New _TrackingByResolution value: " + _TrackingByResolution);
        }
    }

    void Update()
    {
        if (IsTracking || _TrackingByResolution)
        {

        }
    }
}
