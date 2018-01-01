///////////////////////////////////////////////////////////////////////
//
//      GMComponent.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Since I'm kinda used to the GM:S and how it works and behaves, I'm creating
// this helper class for all objects in the boss fight. This will make all the required calculations
// that I used in GM:S
public class GMComponent : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[1];

    [HideInInspector]
    public Vector2 velocity = Vector2.zero;

    public float Direction
    {
        get
        {
            return dir;
        }

        set
        {
            if (value < 0.0f)
            {
                dir = 360.0f + value - ((int)Mathf.Round(value) / 360) * 360;
            }
            else
            {
                dir = value - ((int)Mathf.Round(value) / 360) * 360;
            }

            SetToZeroIf360(ref dir);

            CalculateVelocity();
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
            CalculateVelocity();
        }
    }

    public float ImageAlpha
    {
        get
        {
            if (image == null)
            {
                return 0.0f;
            }
            else
            {
                return image.color.a;
            }
        }

        set
        {
            if (image != null)
            {
                image.color = new Color(
                    image.color.r,
                    image.color.g,
                    image.color.b,
                    value - ((int)Mathf.Round(Mathf.Abs(value)) / 1) * 1
                    );
            }
        }
    }

    public float ImageScaleX
    {
        get
        {
            return transform.localScale.x;
        }

        set
        {
            transform.localScale = new Vector3(
                value - ((int)Mathf.Round(Mathf.Abs(value)) / 1) * 1,
                transform.localScale.y,
                transform.localScale.z
                );
        }
    }

    public float ImageScaleY
    {
        get
        {
            return transform.localScale.y;
        }

        set
        {
            transform.localScale = new Vector3(
                transform.localScale.x,
                value - ((int)Mathf.Round(Mathf.Abs(value)) / 1) * 1,
                transform.localScale.z
                );
        }
    }

    public uint ImageIndex
    {
        get
        {
            return imageIndex;
        }

        set
        {
            imageIndex = value - (value / (uint)sprites.Length * (uint)sprites.Length);
            image.sprite = sprites[imageIndex];
        }
    }

    public float ImageSpeed = 0.0f;

    float dir = 0.0f;
    float speed = 0.0f;
    uint imageIndex = 0;
    SpriteRenderer image;

    void Start()
    {
        image = GetComponent<SpriteRenderer>();

        if (sprites[0] == null)
        {
            sprites[0] = image.sprite;
        }

        Speed = Random.Range(3.0f, 7.0f);

        Invoke("IncrementImageIndex", 0.0f);
    }

    void FixedUpdate()
    {
        transform.position += (Vector3)velocity;
    }

    public float PointDistance(Vector2 to)
    {
        Vector2 from = transform.position;
        return Vector2.Distance(from, to);
    }

    public float PointDirection(Vector2 to)
    {
        Vector2 from = transform.position;

        float angle = Mathf.Atan2(to.y - from.y, to.x - from.x) * Mathf.Rad2Deg;

        if (angle < 0.0f)
        {
            angle += 360.0f;
        }

        SetToZeroIf360(ref angle);
        
        return angle;
    }

    /*
     * Guess I don't need it
     * 
    public Vector2 LengthDir(float distance, float angle)
    {
        return new Vector2(
            distance * Mathf.Cos(angle * Mathf.Deg2Rad),
            distance * -Mathf.Sin(angle * Mathf.Deg2Rad)
            );
    }*/

    void CalculateVelocity()
    {
        velocity = new Vector2(
            Mathf.Cos(dir * Mathf.Deg2Rad) * speed,
            Mathf.Sin(dir * Mathf.Deg2Rad) * speed);
    }

    void SetToZeroIf360(ref float angle)
    {
        if (360.0f - angle < Mathf.Epsilon)
        {
            angle = 0.0f;
        }
    }

    void IncrementImageIndex()
    {
        ImageIndex++;
        Invoke("IncrementImageIndex", 1.0f / GM.fps * (1.0f/ImageSpeed));
    }
}
