///////////////////////////////////////////////////////////////////////
//
//      BrokenLightsController.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Broken lights effect for stage 1
public class BrokenLightsController : MonoBehaviour
{
    SpriteMask[] sms = new SpriteMask[3];

    void Start()
    {
        for (int i =0; i < 3;i++)
        {
            sms[i] = transform.GetChild(i).GetComponent<SpriteMask>();
        }

        TurnLightsOff();
    }

    void TurnLightsOn()
    {

        foreach (SpriteMask sm in sms)
        {
            sm.enabled = true;
        }

        Invoke("TurnLightsOff", Random.Range(0.25f, 1.0f));
    }

    void TurnLightsOff()
    {
        foreach(SpriteMask sm in sms)
        {
            sm.enabled = false;
        }

        Invoke("TurnLightsOn", Random.Range(1.0f, 1.7f));
    }
}
