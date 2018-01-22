///////////////////////////////////////////////////////////////////////
//
//      Dasuyo.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Dasuyo : MonoBehaviour
{
    public GameObject hanabi;
    
    GMComponent gmc;
    Player player;

    void Start()
    {
        gmc = GetComponent<GMComponent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        gmc.ImageSpeed = 0.0f;
        gmc.ImageScaleX = 2;
        gmc.ImageScaleY = 2;
    }

    void OnDestroy()
    {
        float a = GMComponent.PointDirection(
            transform.position.x,
            transform.position.y,
            player.transform.position.x,
            player.transform.position.y);
        float asd = 0;

        for (int i = 0; i<10;i++)
        {
            GMComponent gmcObj = Instantiate(hanabi, transform.position, Quaternion.identity)
                .GetComponent<GMComponent>();

            gmcObj.Speed = 16;
            gmcObj.Direction = a + asd;
            asd += 360 / 10;
        }
    }
}
