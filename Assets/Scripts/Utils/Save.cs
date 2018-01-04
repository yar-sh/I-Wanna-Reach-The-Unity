///////////////////////////////////////////////////////////////////////
//
//      Save.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Save objects
public class Save : MonoBehaviour
{
    public Sprite ActiveSave;
    public float lightsOutFadeTime = 5.0f;

    Sprite NormalSave;
    SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        NormalSave = sprite.sprite;
    }

    // Saves the game and turns object into the active sprite
    public void SaveGame()
    {
        CancelInvoke("TurnBackNormal");

        sprite.sprite = ActiveSave;

        SaveLoadManager.data.lastLightsOutTime = lightsOutFadeTime;
        SaveLoadManager.SaveGame();

        GetComponentInChildren<ParticleSystem>().Play();
        GameManager.Instance.PlaySound("Save");

        Invoke("TurnBackNormal", 0.7f);
    }

    // Turns object back to having inactive/normal sprite
    void TurnBackNormal()
    {
        sprite.sprite = NormalSave;
    }
}
