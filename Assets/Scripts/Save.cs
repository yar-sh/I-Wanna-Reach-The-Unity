///////////////////////////////////////////////////////////////////////
//
//      Save.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Save : MonoBehaviour
{
    public Sprite ActiveSave;

    Sprite NormalSave;
    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        NormalSave = sprite.sprite;
    }

    public void SaveGame()
    {
        CancelInvoke("TurnBackRed");

        sprite.sprite = ActiveSave;

        Invoke("TurnBackRed", 0.7f);

        GameManager.Instance.SaveLoadManager.SaveGame();
    }

    void TurnBackRed()
    {
        sprite.sprite = NormalSave;
    }
}
