///////////////////////////////////////////////////////////////////////
//
//      PlayerStart.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class PlayerStart : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        GameObject newPlayer = Instantiate(player, transform.position, transform.rotation);
        newPlayer.name = player.name;

        Destroy(gameObject);
    }
}
