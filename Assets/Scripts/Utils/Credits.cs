///////////////////////////////////////////////////////////////////////
//
//      Credits.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// roll them. friccin finally
public class Credits : MonoBehaviour
{
    float speed = 36.0f;

    void Start()
    {
        Invoke("StopCredits", 3*60 + 58.5f);
    }

    void Update()
    {
        transform.position += (Vector3)(Vector2.up * Time.deltaTime * speed);
    }

    void StopCredits()
    {
        speed = 0;
        Invoke("Transition", 10);
    }

    void Transition()
    {
        NewSceneManager.NextScene(4.0f, 1.0f);
    }
}
