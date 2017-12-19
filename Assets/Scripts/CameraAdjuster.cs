///////////////////////////////////////////////////////////////////////
//
//      CameraAdjuster.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class CameraAdjuster : MonoBehaviour
{
    private Vector2 _Offset = Vector2.zero;
    private bool _Tracking = false;

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

    public bool Tracking
    {
        get
        {
            return _Tracking;
        }

        set
        {
            _Tracking = value;
            Debug.Log("New _Tracking value: " + _Tracking);
        }
    }
}
