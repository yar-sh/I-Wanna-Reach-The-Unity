///////////////////////////////////////////////////////////////////////
//
//      StageCurscene.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class StageCurscene : MonoBehaviour
{
    public void NextScene()
    {
        NewSceneManager.NextScene(1.0f,1.5f);
    }
}
