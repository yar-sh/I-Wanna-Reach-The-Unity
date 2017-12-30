///////////////////////////////////////////////////////////////////////
//
//      Player.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

// A player. A thing you control with keyboard. 
// TODO: Make player sprite transparent when invincible?
public class Player : MonoBehaviour
{
    public RuntimeAnimatorController RunningAnimation;
    public RuntimeAnimatorController IdlingAnimation;
    public RuntimeAnimatorController JumpingAnimation;
    public RuntimeAnimatorController FallingAnimation;
    public GameObject bullet;
    public GameObject gameOver;
    public GameObject bloodEmitter;
    public GameObject jumpFallParticleEmitter;
    public GameObject statsDisplay;
    public Vector3 Velocity
    {
        get
        {
            return _velocity;
        }
    }

    [HideInInspector]
    public float moveSpeed = 3.0f;
    [HideInInspector]
    public float maxYVelocity = 9.0f;
    [HideInInspector]
    public bool isDead = false;
    [HideInInspector]
    public bool isFrozen = false;
    [HideInInspector]
    public GameObject collidingSave = null;
    [HideInInspector]
    public StatsDisplay statsDisplayComponent;

    int moveDir = 0;
    public int faceDir = 1;
    float jumpVelocity1 = 8.5f;
    float jumpVelocity2 = 7.0f;
    float minJumpVelocity;
    uint jumpCount = 1;
    bool onGround = true;
    bool collidingWithWarp = false;
    NewCollider2D obstaclesController;
    NewCollider2D warpsController;
    Animator animator;
    Camera camera;
    Vector3 _velocity;

    void Start()
    {   
        camera = FindObjectOfType<Camera>();
        animator = GetComponent<Animator>();

        NewCollider2D[] newColliders = GetComponents<NewCollider2D>();
        obstaclesController = newColliders[0];
        warpsController = newColliders[1];

        GetComponent<SpriteRenderer>().flipX = faceDir == -1;

        statsDisplay = Instantiate(statsDisplay);
        statsDisplayComponent = statsDisplay.GetComponent<StatsDisplay>();

        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(GM.gravity) * 7.8f);
    }

    // Calculate in what directions what velocities should apply
    void CalculateVelocity()
    {
        // Frozen - no movement at all. Not even gravity
        if (isFrozen)
        {
            _velocity = Vector2.zero;
            return;
        }

        _velocity.x = moveDir * moveSpeed;
        _velocity.y += GM.gravity;

        _velocity.y = Mathf.Max(_velocity.y, -maxYVelocity);
    }
    
    void FixedUpdate()
    {
        CalculateVelocity();

        // Move player and account for all collisions
        obstaclesController.Move(_velocity);
        warpsController.Move(_velocity * Mathf.Epsilon);

        // Set onGround and play jump particles when landing
        if (obstaclesController.collisions.below && !onGround)
        {
            onGround = true;
            PlayJumpFallParticles();
        }
        else if (!obstaclesController.collisions.below && onGround)
        {
            onGround = false;
        }

        // If on the ground - reset gravity velocity and refill double jump
        if (onGround)
        {
            _velocity.y = 0;
            jumpCount = 1;
        }
        else if (obstaclesController.collisions.above)
        {
            // If bonking on the ceiling
            _velocity.y = -maxYVelocity / 9.0f;
        }
    }

    void Update()
    {
        // Optimizations
        if (isDead)
        {
            return;
        }

        // When player is on the screen - increase the play time
        SaveLoadManager.data.time += Time.deltaTime;

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
        if ((warpsController.collisions.below || warpsController.collisions.above ||
            warpsController.collisions.left || warpsController.collisions.right) && !collidingWithWarp)
        {
            // Save time and death data first
            SaveLoadManager.SaveCurrentData();

            // Freeze before transtition animation
            isFrozen = true;
            collidingWithWarp = true;

            // Then actually warp
            warpsController.collisions.target.GetComponent<Warp>().DoWarp();
        }
        
        faceDir = obstaclesController.collisions.faceDir;

        // Flip sprite if walking to the left (negative x)
        GetComponent<SpriteRenderer>().flipX = faceDir == -1;

        // Set animations based on how player moved
        if (obstaclesController.collisions.below)
        {
            if (_velocity.x != 0 && animator.runtimeAnimatorController != RunningAnimation)
            {
                animator.runtimeAnimatorController = RunningAnimation;
            }
            else if (_velocity.x == 0 && animator.runtimeAnimatorController != IdlingAnimation)
            {
                animator.runtimeAnimatorController = IdlingAnimation;
            }
        }
        else
        {
            if (_velocity.y > 0 && animator.runtimeAnimatorController != JumpingAnimation)
            {
                animator.runtimeAnimatorController = JumpingAnimation;
            }
            else if (_velocity.y < 0 && animator.runtimeAnimatorController != FallingAnimation)
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

    // Shoots a bullet
    public void Shoot()
    {
        if (isFrozen)
        {
            return;
        }

        GameObject bul = Instantiate(bullet, transform.position + Vector3.down * 6.5f - Vector3.right * faceDir * 8.0f, Quaternion.identity);
        bul.GetComponent<Bullet>().faceDir = faceDir;
    }

    // Jumps
    public void OnJumpInputDown()
    {
        if (onGround || jumpCount >= 1)
        {
            if (!obstaclesController.collisions.below)
            {
                jumpCount--;
            }
            
            // Play different sounds and apply different velocities based on what jump count it is
            if (jumpCount >= 1)
            {
                _velocity.y = jumpVelocity1;
                GameManager.Instance.PlaySound("Jump1");
            }
            else
            {
                PlayJumpFallParticles();
                _velocity.y = jumpVelocity2;
                GameManager.Instance.PlaySound("Jump2");
            }

            onGround = false;
        }
    }

    // Stop aadding jump velocity when shift key is released
    public void OnJumpInputUp()
    {
        if (_velocity.y > minJumpVelocity)
        {
            _velocity.y = minJumpVelocity;
        }
    }

    // Kill player
    public void Die()
    {
        // Can't die more than once OR when invincible OR when is frozen
        if (isDead || GameManager.playerIsInvincible || isFrozen)
        {
            return;
        }

        // Destroy all the bullets just in case
        foreach(GameObject gm in GameObject.FindGameObjectsWithTag("Bullet"))
        {
            Destroy(gm);
        }
        
        // BLOOOOOOOOOOOOOOOOOOOOD
        Instantiate(bloodEmitter, transform.position, Quaternion.identity);
        
        // Increment death counter
        SaveLoadManager.data.deaths++;
        
        // Save current game data
        SaveLoadManager.SaveCurrentData();

        // Stop the background music and play death sounds
        GameManager.Instance.PlaySound("Death1");
        GameManager.Instance.PlaySound("Death2");
        GameManager.Instance.FadeOutLevelMusic();

        // Set the flags and move the object to -50,-50. Yes, it's not actually destroyed
        isDead = true;
        isFrozen = true;
        transform.position = new Vector2(-50, -50);

        // Place gameover animated object at the center of the camera
        Vector3 newPos = camera.transform.position;
        newPos.z = -9;
        Instantiate(gameOver, newPos, Quaternion.identity);
    }
}
