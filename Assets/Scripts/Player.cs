///////////////////////////////////////////////////////////////////////
//
//      Player.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float maxYVelocity = 9.0f;
    public bool isDead = false;
    public bool isFrozen = false;
    public RuntimeAnimatorController RunningAnimation;
    public RuntimeAnimatorController IdlingAnimation;
    public RuntimeAnimatorController JumpingAnimation;
    public RuntimeAnimatorController FallingAnimation;
    public GameObject bullet;
    public GameObject gameOver;
    public GameObject bloodEmitter;
    public GameObject jumpFallParticleEmitter;

    int faceDir = 1;
    int moveDir = 0;
    float jumpVelocity1 = 8.5f;
    float jumpVelocity2 = 7.0f;
    float minJumpVelocity;
    bool hasDoubleJump = true;
    bool onGround = true;
    NewCollider2D obstaclesController;
    NewCollider2D warpsController;
    NewCollider2D dangersController;
    Animator animator;
    Camera camera;
    Vector3 velocity;

    void Start()
    {   
        camera = FindObjectOfType<Camera>();
        animator = GetComponent<Animator>();

        NewCollider2D[] newColliders = GetComponents<NewCollider2D>();
        obstaclesController = newColliders[0];
        warpsController = newColliders[1];
        dangersController = newColliders[2];

        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(GM.gravity) * 7.8f);
    }

    // Calculate in what directions what velocities should apply
    void CalculateVelocity()
    {
        // Frozen - no movement at all. Not even gravity
        if (isFrozen)
        {
            velocity = Vector2.zero;
            return;
        }

        velocity.x = moveDir * moveSpeed;
        velocity.y += GM.gravity;

        velocity.y = Mathf.Max(velocity.y, -maxYVelocity);
    }

    // Called 50 times a second
    void FixedUpdate()
    {
        CalculateVelocity();

        // Move player and account for all collisions
        obstaclesController.Move(velocity);
        warpsController.Move(velocity * Mathf.Epsilon);
        dangersController.Move(velocity * Mathf.Epsilon);

        // Set onGround and play jump paricles when landing
        if (obstaclesController.collisions.below && !onGround)
        {
            onGround = true;
            PlayJumpFallParticles();
        }
        else if (!obstaclesController.collisions.below && onGround)
        {
            onGround = false;
        }

        // If on the ground - no gravity and refill double jump
        if (onGround)
        {
            velocity.y = 0;
            hasDoubleJump = true;
        }
        else if (obstaclesController.collisions.above)
        {
            // If bonking on the ceiling
            velocity.y = -maxYVelocity / 9.0f;
        }
    }

    void Update()
    {
        // If colliding with killer object - die
        if (dangersController.collisions.below || dangersController.collisions.above ||
            dangersController.collisions.left || dangersController.collisions.right)
        {
            Die();
        }

        // If outside of the camera view - die
        Vector3 pos = transform.position;
        if (pos.x < camera.transform.position.x - (GM.N_TILES_HOR + 0.5f) / 2.0f * GM.TILE_SIZE_UNITS ||
            pos.x > camera.transform.position.x + (GM.N_TILES_HOR + 0.5f) / 2.0f * GM.TILE_SIZE_UNITS ||
            pos.y > camera.transform.position.y + (GM.N_TILES_VER + 0.5f) / 2.0f * GM.TILE_SIZE_UNITS ||
            pos.y < camera.transform.position.y - (GM.N_TILES_VER + 0.5f) / 2.0f * GM.TILE_SIZE_UNITS)

        {
            Die();
        }

        // If colliding with warp - warp
        if (warpsController.collisions.below || warpsController.collisions.above ||
            warpsController.collisions.left || warpsController.collisions.right)
        {
            warpsController.collisions.target.GetComponent<Warp>().DoWarp();
        }
        
        faceDir = obstaclesController.collisions.faceDir;

        // Flip sprite
        GetComponent<SpriteRenderer>().flipX = faceDir == -1;

        // Set animations based on how player moved
        if (obstaclesController.collisions.below)
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
    }

    // Spawns a small amount of particles
    // Used when player lands OR when makes a double jump
    void PlayJumpFallParticles()
    {
        Instantiate(jumpFallParticleEmitter, transform.position, Quaternion.identity)
            .GetComponent<ParticleSystem>()
            .Play();
    }


    public void SetMoveDir(int movedir)
    {
        moveDir = movedir;
    }

    public void Shoot()
    {
        GameObject bul = Instantiate(bullet, transform.position + Vector3.down * 6.5f - Vector3.right * faceDir * 8.0f, Quaternion.identity);
        bul.GetComponent<Bullet>().faceDir = faceDir;
    }

    public void OnJumpInputDown()
    {
        if (onGround || hasDoubleJump)
        {
            if (!obstaclesController.collisions.below)
            {
                hasDoubleJump = false;
            }
            
            if (hasDoubleJump)
            {
                velocity.y = jumpVelocity1;
            }
            else
            {
                PlayJumpFallParticles();
                velocity.y = jumpVelocity2;
            }

            onGround = false;
        }
    }

    public void OnJumpInputUp()
    {
        if (velocity.y > minJumpVelocity)
        {
            velocity.y = minJumpVelocity;
        }
    }

    public void Die()
    {
        if (isDead)
        {
            return;
        }

        foreach(GameObject gm in GameObject.FindGameObjectsWithTag("Bullet"))
        {
            Destroy(gm);
        }
        
        Instantiate(bloodEmitter, transform.position, Quaternion.identity);

        isDead = true;
        isFrozen = true;
        transform.position = new Vector2(-50, -50);

        Vector3 newPos = camera.transform.position;
        newPos.z = -9;

        Instantiate(gameOver, newPos, Quaternion.identity);
    }
}
