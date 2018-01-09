///////////////////////////////////////////////////////////////////////
//
//      Stage4TrollWarp.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Fun stuff. Moves the warp down to the end of the level
public class Stage4TrollWarp : MonoBehaviour
{
    GMComponent gmc;
    bool wasTriggered = false;

    void Start()
    {
        gmc = GetComponent<GMComponent>();
        gmc.Direction = 270.0f;
    }

    public void Trigger()
    {
        if (wasTriggered)
        {
            return;
        }

        GameManager.Instance.PlaySound("Laughter");
        wasTriggered = true;
        gmc.Speed = 20.0f;
        Invoke("TurnLeft", 0.5f);
    }

    void TurnLeft()
    {
        gmc.Direction = 180.0f;
        Invoke("StopTrigger", 0.12f);
    }

    void StopTrigger()
    {
        gmc.enabled = false;
        gameObject.layer = 11;
    }
}
