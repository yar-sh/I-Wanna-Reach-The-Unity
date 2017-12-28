///////////////////////////////////////////////////////////////////////
//
//      CameraAdjuster.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class CameraAdjuster : MonoBehaviour
{
    bool _TrackingByResolution = false;
    Vector3 _Offset = new Vector3(544, 272, -10);
    GameObject player = null;

    public Vector2 Offset
    {
        get
        {
            return _Offset;
        }

        set
        {
            transform.position -= new Vector3(_Offset.x, _Offset.y);

            _Offset.x = value.x;
            _Offset.y = value.y;

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
            if (!value)
            {
                transform.position = _Offset;
            }
        }
    }

    void Update()
    {
        if (_TrackingByResolution && (player != null || GameObject.Find("Player") != null))
        {
            if (player == null)
            {
                player = GameObject.Find("Player");
            }

            if (player.GetComponent<Player>().isDead)
            {
                return;
            }
            
            Vector3 newPos = player.transform.position;
            Camera c = GetComponent<Camera>();
            newPos.x = Mathf.Max(newPos.x, c.orthographicSize * c.aspect);
            newPos.x = Mathf.Min(newPos.x, GM.N_TILES_HOR * GM.TILE_SIZE_UNITS - c.orthographicSize * c.aspect);
            newPos.y = transform.position.y;
            newPos.z = transform.position.z;
            transform.position = newPos;
        }
    }
}
