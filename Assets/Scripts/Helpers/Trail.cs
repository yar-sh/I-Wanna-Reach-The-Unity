///////////////////////////////////////////////////////////////////////
//
//      Trail.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Small helper class. When attached to the object spawns a trail behind it
// of the current sprite
public class Trail : MonoBehaviour
{
    public float spawnEveryNFrames = 1.0f;
    public float startAlpha = 0.9f;
    public float endAlpha = 0.0f;
    public float decreaseAlphaRate = 0.1f;
    public float decreaseAlphaEveryNFrames = 1.0f;

    GameObject trailDummyOriginal;

    void Start()
    {
        trailDummyOriginal = new GameObject("TrailDummy");
        SpawnTrailDummy();
    }

    void SpawnTrailDummy()
    {
        GameObject trailDummy = Instantiate(trailDummyOriginal);
        trailDummy.transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            transform.position.z + 1
        );
        trailDummy.transform.localRotation = transform.localRotation;
        trailDummy.AddComponent<TrailDummy>();
        trailDummy.AddComponent<SpriteRenderer>();

        SpriteRenderer tdSR = trailDummy.GetComponent<SpriteRenderer>();
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        tdSR.sprite = sr.sprite;
        tdSR.sortingOrder = sr.sortingOrder;

        TrailDummy td = trailDummy.GetComponent<TrailDummy>();
        td.startAlpha = startAlpha;
        td.endAlpha = endAlpha;
        td.decreaseAlphaRate = decreaseAlphaRate;
        td.decreaseAlphaEveryNFrames = decreaseAlphaEveryNFrames;

        Invoke("SpawnTrailDummy", 1.0f / GM.fps * spawnEveryNFrames);
    }

    void OnDestroy()
    {
        Destroy(trailDummyOriginal);
    }
}
