using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
   

    Vector2 movement;
    bool jump;
    bool onGround;
    bool jumping;
    bool sprint;
    public float ascendingGravity;
    public float descendingGravity;
    public float jumpForce;
    public float speed;
    public float sprintspeed;
    public float ladderClimbSpeed;
    public float coyoteTime;
    public float DeclperS;
    float ct;
    public Rigidbody2D rb;
    public Transform gc;
    public Transform lc;
    public float gcrad;
    public LayerMask groundLayers;
    public LayerMask LadderLayers;
    public bool hasGem ;
    public Gem g;
    public bool facingRight;
    public SpriteRenderer spr;
    public Animator anim;
    bool onLadder;

    public bool isActive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hasGem = false;
        g = null;
        rb.gravityScale = ascendingGravity;
        ct = 0;
     
    }

    private void Update()
    {
      
        onGround = Physics2D.OverlapCircleAll(gc.position, gcrad, groundLayers|LadderLayers).Length > 0;
        onLadder = Physics2D.OverlapCircleAll(lc.position, gcrad, LadderLayers).Length > 0;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isActive)
        {
            spr.flipX = facingRight;
            if (!onGround)
            {
                ct += Time.fixedDeltaTime;
            }
            else
            {
                if (jumping)
                {
                    jumping = false;
                }
                ct = 0;
            }
            if (movement.sqrMagnitude > 0)
            {
                if (sprint)
                {
                    rb.velocityX = movement.x * sprintspeed;
                }
                else
                {
                    rb.velocityX = movement.x * speed;
                }
            }
           
            if (jump)
            {
                if (!onLadder)
                {
                    rb.AddForceY(jumpForce, ForceMode2D.Impulse);
                    jump = false;
                    jumping = true;
                }
                else {
                    if (sprint)
                    {
                        rb.velocityY = -ladderClimbSpeed;
                    }
                    else
                    {
                        rb.velocityY = ladderClimbSpeed;
                    }
                }
            }

            if (rb.velocityY < 0)
            {
                rb.gravityScale = descendingGravity;
            }
            else
            {
                if (onLadder) {
                    rb.gravityScale = 0;
                }
                else {
                    rb.gravityScale = ascendingGravity;
                }
            }
        }
        if (Mathf.Approximately(movement.sqrMagnitude, 0) && !Mathf.Approximately(rb.velocityX, 0))
        {
            if (rb.velocityX is < 0.5f and > -0.5f)
            {
                rb.velocityX = 0;
            }
            if (rb.velocityX > 0)
            {
                rb.velocityX -= DeclperS * Time.fixedDeltaTime;
            }
            else if (rb.velocityX < 0)
            {
                rb.velocityX += DeclperS * Time.fixedDeltaTime;
            }
        }
        if (onLadder) {
            if (!jump) {
                rb.velocityY = 0;
            }
        }
        anim.SetBool("jumping", jumping);
        anim.SetBool("moving", rb.velocity.sqrMagnitude > 0);
        anim.SetBool("running", sprint);
    }

    public void OnMove(InputAction.CallbackContext ctx) {
        if (isActive)
        {
            float v = ctx.ReadValue<float>();
            movement = Vector2.right * v;
            if (v > 0)
            {
                facingRight = true;
            }
            else if (v < 0)
            {
                facingRight = false;
            }
        }
    }
    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (isActive)
        {
            if (!onLadder)
            {
                jump = ctx.ReadValueAsButton() && (onGround || ct <= coyoteTime) && !jumping;
            }
            else {
                jump = ctx.ReadValueAsButton();
            }
        }

    }

    public void OnSprint(InputAction.CallbackContext ctx)
    {
        if (isActive)
        {
            sprint = ctx.ReadValueAsButton();
        }

    }
}
