///////////////////////////////////////////////////////////////////////
//
//      PlayerInput.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        player.SetDirectionalInput(directionalInput);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            player.OnJumpInputDown();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            player.OnJumpInputUp();
        }
    }
}