///////////////////////////////////////////////////////////////////////
//
//      ChooseRandomSprite.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Small helper class. When attached to the object picks a random sprite for
// SpriteRenderer from the array
public class ChooseRandomSprite : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[2];

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
