///////////////////////////////////////////////////////////////////////
//
//      SadTromboneTrigger.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class SadTromboneTrigger : MonoBehaviour
{
    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

    public void Trigger()
    {
        GameManager.Instance.PlaySound("SadTrombone");
        Destroy(gameObject);
    }
}
