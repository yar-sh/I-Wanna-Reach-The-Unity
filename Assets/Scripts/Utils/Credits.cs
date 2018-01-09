///////////////////////////////////////////////////////////////////////
//
//      Credits.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// TODO: this
public class Credits : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            NewSceneManager.NextScene(2.0f, 0.5f);
        }
    }
}
