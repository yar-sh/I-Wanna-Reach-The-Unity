///////////////////////////////////////////////////////////////////////
//
//      ChooseRandomSprite.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class ChooseRandomSprite : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[2];

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length - 1)];
    }
}
