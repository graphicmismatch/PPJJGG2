using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
   

    Vector2 movement;
    bool jump;
    bool onGround;
    bool jumping;
    public float ascendingGravity;
    public float descendingGravity;
    public float jumpForce;
    public float speed;
    public float coyoteTime;
    public float DeclperS;
    float ct;
    public Rigidbody2D rb;
    public Transform gc;
    public float gcrad;
    public LayerMask groundLayers;
    public bool hasGem ;
    public Gem g;
    public bool facingRight;

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
      
        onGround = Physics2D.OverlapCircleAll(gc.position, gcrad, groundLayers).Length > 0;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!onGround)
        {
            ct += Time.fixedDeltaTime;
        }
        else {
            if (jumping) {
                jumping = false;
            }
            ct = 0;
        }
        if (movement.sqrMagnitude > 0)
        {
            rb.velocityX = movement.x * speed;
        }
        else if(Mathf.Approximately(movement.sqrMagnitude, 0)&& !Mathf.Approximately(rb.velocityX, 0))
        {
            if (rb.velocityX is < 0.5f and > -0.5f) {
                rb.velocityX = 0;
            }
            if (rb.velocityX > 0)
            {
                rb.velocityX -= DeclperS * Time.fixedDeltaTime;
            }
            else if(rb.velocityX < 0) {
                rb.velocityX += DeclperS * Time.fixedDeltaTime;
            }
        }
        if (jump)
        {
            rb.AddForceY(jumpForce,ForceMode2D.Impulse);
            jump = false;
            jumping = true;
        }

        if (rb.velocityY < 0)
        {
            rb.gravityScale = descendingGravity;
        }
        else {
            rb.gravityScale = ascendingGravity;
        }
    }

    public void OnMove(InputAction.CallbackContext ctx) {
        float v = ctx.ReadValue<float>();
        movement = Vector2.right *v;
        if (v>0) {
            facingRight = true;
        }
        else if (v < 0) {
            facingRight = false;
        }
    }
    public void OnJump(InputAction.CallbackContext ctx)
    {
        jump = ctx.ReadValueAsButton() && (onGround || ct<=coyoteTime)&&!jumping ;

    }
}
