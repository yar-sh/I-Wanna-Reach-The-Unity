///////////////////////////////////////////////////////////////////////
//
//      HyenaTrigger.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Fun stuff. Triggers the hyena
public class HyenaTrigger : MonoBehaviour
{
    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

    public void Trigger()
    {
        GameManager.Instance.PlaySound("QUACK");

        transform.parent.GetComponent<GMComponent>().Direction = 180.0f;
        transform.parent.GetComponent<GMComponent>().Speed = 20.0f;

        Destroy(gameObject);
    }
}
