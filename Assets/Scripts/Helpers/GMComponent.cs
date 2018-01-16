///////////////////////////////////////////////////////////////////////
//
//      GMComponent.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// Since I'm kinda used to the GM:S and how it works and behaves, I'm creating
// this helper class for all objects in the boss fight. This will make easier all the required calculations
// that I used in GM:S (especially for the boss fight)
public class GMComponent : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[1];
    
    Vector2 velocity = Vector2.zero;

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

    public Vector2 Velocity
    {
        get
        {
            return velocity;
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
                    Mathf.Clamp01(value)
                    );
            }
        }
    }

    public float ImageAngle
    {
        get
        {
            return angle;
        }

        set
        {
            Quaternion rot = new Quaternion();
            rot.eulerAngles = new Vector3(0.0f,0.0f,value);
            transform.rotation = rot;
            angle = value;
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
                value,
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
                value,
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
    public float friction = 0.0f;
    public float gravity = 0.0f;
    public float acceleration = 0.0f;
    public bool _applySpeed = true;

    float dir = 0.0f;
    float angle = 0;
    float speed = 0.0f;
    uint imageIndex = 0;
    SpriteRenderer image;

    void Awake()
    {
        image = GetComponent<SpriteRenderer>();

        if (sprites[0] == null && image != null)
        {
            sprites[0] = image.sprite;
        }
        
        ImageAlpha = (image != null) ? image.color.a : 1.0f;
        ImageScaleX = transform.localScale.x;
        ImageScaleY = transform.localScale.y;

        if (!Mathf.Approximately(ImageSpeed, 0.0f))
        {
            IncrementImageIndex();
        }
    }

    void FixedUpdate()
    {
        if (speed > 0)
        {
            Speed = Mathf.Max(0.0f, speed - friction);
        }
        else if (speed < 0)
        {
            Speed = Mathf.Min(0.0f, speed + friction);
        }

        if (!Mathf.Approximately(acceleration, 0.0f))
        {
            Speed += acceleration;
        }

        if (!Mathf.Approximately(gravity, 0.0f))
        {
            velocity.y += gravity;

            speed = Mathf.Sqrt(velocity.y * velocity.y + velocity.x * velocity.x);
            dir = Mathf.Atan(Mathf.Abs(velocity.y) / Mathf.Abs(velocity.x)) * Mathf.Rad2Deg;

            if (velocity.x < 0 && velocity.y > 0)
            {
                dir = 180.0f - dir;
            }
            else if(velocity.x < 0 && velocity.y < 0)
            {
                dir += 180.0f;
            }
            else if (velocity.x > 0 && velocity.y < 0)
            {
                dir = 360.0f - dir;
            }
        }

        if (_applySpeed)
        {
            transform.position += (Vector3)velocity;
        }
    }

    public static float PointDistance(float x1, float y1, float x2, float y2)
    {
        return Vector2.Distance(new Vector2(x1,y1), new Vector2(x2,y2));
    }

    public static float PointDirection(float x1, float y1, float x2, float y2)
    {
        Vector2 from = new Vector2(x1,y1);
        Vector2 to = new Vector2(x2, y2);

        float angle = Mathf.Atan2(to.y - from.y, to.x - from.x) * Mathf.Rad2Deg;

        if (angle < 0.0f)
        {
            angle += 360.0f;
        }

        SetToZeroIf360(ref angle);
        
        return angle;
    }

    public void MoveTowardsPoint(float x, float y, float speed)
    {
        Vector2 end = new Vector2(x,y);
        Vector2 direction = (end - (Vector2)transform.position);

        direction.Normalize();

        transform.position += (Vector3)direction * speed;
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

    static void SetToZeroIf360(ref float angle)
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
