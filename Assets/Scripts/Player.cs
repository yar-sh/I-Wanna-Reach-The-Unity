///////////////////////////////////////////////////////////////////////
//
//      Player.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxJumpHeight = 85.0f;
    public float minJumpHeight = 5.0f;
    public float timeToJumpApex = 0.4f;
    public float moveSpeed = 140.0f;
    public float maxYVelocity = 600.0f;
    public RuntimeAnimatorController RunningAnimation;
    public RuntimeAnimatorController IdlingAnimation;
    public RuntimeAnimatorController JumpingAnimation;
    public RuntimeAnimatorController FallingAnimation;
    public GameObject bullet;

    int faceDir = 1;
    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;
    bool hasDoubleJump = true;
    NewCollider2D controller;
    Animator animator;
    Vector3 velocity;
    Vector2 directionalInput;
    
    void Start()
    {
        controller = GetComponent<NewCollider2D>();
        animator = GetComponent<Animator>();

        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
    }

    void Update()
    {
        CalculateVelocity();

        // Move player and account for all collisions
        controller.Move(velocity * Time.deltaTime, directionalInput);

        faceDir = controller.collisions.faceDir;

        // Flip sprite
        Vector3 q = transform.localScale;
        q.x = faceDir;
        transform.localScale = q;

        // Set animations based on how player moved
        if (controller.collisions.below)
        {
            if (velocity.x != 0 && animator.runtimeAnimatorController != RunningAnimation)
            {
                animator.runtimeAnimatorController = RunningAnimation;
            }
            else if (velocity.x == 0 && animator.runtimeAnimatorController != IdlingAnimation)
            {
                animator.runtimeAnimatorController = IdlingAnimation;
            }
        }
        else
        {
            if (velocity.y > 0 && animator.runtimeAnimatorController != JumpingAnimation)
            {
                animator.runtimeAnimatorController = JumpingAnimation;
            }
            else if (velocity.y < 0 && animator.runtimeAnimatorController != FallingAnimation)
            {
                animator.runtimeAnimatorController = FallingAnimation;
            }
        }

        // If on the ground
        if (controller.collisions.below || controller.collisions.above)
        {
            // On slope
            if (controller.collisions.slidingDownMaxSlope)
            {
                velocity.y += controller.collisions.slopeNormal.y * -gravity * Time.deltaTime;
            }
            else if (controller.collisions.below)
            {
                velocity.y = 0;
            }
            else
            {
                // If bonking on the ceiling
                velocity.y = -maxYVelocity / 6.2f;
            }
        }

        // Refill double jump if on the ground
        if (controller.collisions.below && !hasDoubleJump)
        {
            hasDoubleJump = true;
        }
    }

    public void SetDirectionalInput(Vector2 input)
    {
        directionalInput = input;
    }

    public void Shoot()
    {
        GameObject bul = Instantiate(bullet, transform.position + Vector3.down * 6.5f - Vector3.right * faceDir * 8.0f, Quaternion.identity);
        bul.GetComponent<Bullet>().faceDir = faceDir;
    }

    public void OnJumpInputDown()
    {
        if (controller.collisions.below || hasDoubleJump)
        {
            if (!controller.collisions.below)
            {
                hasDoubleJump = false;
            }

            if (controller.collisions.slidingDownMaxSlope)
            {
                if (directionalInput.x != -Mathf.Sign(controller.collisions.slopeNormal.x))
                {
                    velocity.y = maxJumpVelocity * (hasDoubleJump ? 1.0f : 0.86f) * controller.collisions.slopeNormal.y;
                    velocity.x = maxJumpVelocity * (hasDoubleJump ? 1.0f : 0.86f) * controller.collisions.slopeNormal.x;
                }
            }
            else
            {
                velocity.y = maxJumpVelocity * (hasDoubleJump ? 1.0f : 0.86f);
            }
        }
    }

    public void OnJumpInputUp()
    {
        if (velocity.y > minJumpVelocity)
        {
            velocity.y = minJumpVelocity;
        }
    }
    
    // Calculate in what directions what velocities should apply
    void CalculateVelocity()
    {
        velocity.x = directionalInput.x * moveSpeed;
        velocity.y += gravity * Time.deltaTime;
        velocity.y = Mathf.Max(velocity.y, -maxYVelocity);
    }
}
