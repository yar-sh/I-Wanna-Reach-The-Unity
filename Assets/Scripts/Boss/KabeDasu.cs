///////////////////////////////////////////////////////////////////////
//
//      KabeDasu.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class KabeDasu : MonoBehaviour
{
    public GameObject Black3;
    GMComponent gmc;
    GameObject idx;

    void Start()
    {
        gmc = GetComponent<GMComponent>();
        
        gmc.ImageAlpha = 0.0f;
    }

    public void Alarm0()
    {
        idx = Instantiate(Black3, transform.position, Quaternion.identity);
        idx.GetComponent<GMComponent>().Speed = 17.0f;
        idx.GetComponent<GMComponent>().Direction = -90.0f;
        //Invoke("Alarm0", 0.0f);
    }
}
