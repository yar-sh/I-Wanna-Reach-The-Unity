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

        Invoke("TurnBackNormal", 0.7f);

        GameManager.Instance.SaveLoadManager.SaveGame();
    }

    void TurnBackNormal()
    {
        sprite.sprite = NormalSave;
    }
}
