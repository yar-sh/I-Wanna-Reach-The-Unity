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
        CancelInvoke("TurnBackNormal");

        sprite.sprite = ActiveSave;
        GetComponentInChildren<ParticleSystem>().Play();
        GameManager.Instance.PlaySound("Save");

        Invoke("TurnBackNormal", 0.7f);

        SaveLoadManager.SaveGame();
    }

    void TurnBackNormal()
    {
        sprite.sprite = NormalSave;
    }
}
