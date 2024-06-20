using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
   

    Vector2 movement;
    bool jump;
    bool onGround;

    public float ascendingGravity;
    public float descendingGravity;
    public float jumpForce;
    public float speed;
    public float coyoteTime;
    float ct;
    public Rigidbody2D rb;
    public Transform gc;
    public float gcrad;
    public LayerMask groundLayers;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
            ct = 0;
        }
        rb.velocityX = movement.x * speed;
        if (jump)
        {
            rb.AddForceY(jumpForce,ForceMode2D.Impulse);
            jump = false;
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
        movement = Vector2.right *ctx.ReadValue<float>();
    }
    public void OnJump(InputAction.CallbackContext ctx)
    {
        jump = ctx.ReadValueAsButton() && (onGround || ct<=coyoteTime) ;

    }
}
