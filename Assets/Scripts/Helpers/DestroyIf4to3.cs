///////////////////////////////////////////////////////////////////////
//
//      DestroyIf4to3.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Small helper that destroys the object if current resolution is 4:3
public class DestroyIf4to3 : MonoBehaviour
{
    void Start()
    {
        Resolution curRes = GameManager.Instance.DisplayManager.Resolution;
        if ((float)curRes.width / (float)curRes.height < 1.76f)
        {
            Destroy(gameObject);
        }
    }
}
