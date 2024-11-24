using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerControl control;
    float direction = 0;
    public Rigidbody2D player;
    public Animator animator;
    public Transform groundCheck;
    public LayerMask ground;
    public float speed = 400f;
    public float jumpForce = 10f;
    int jumpCount = 0;
    bool isFacingRight = true;
    bool isGrounded = true;
    private void Awake()
    {
        control = new PlayerControl();
        control.Enable();

        control.OnLand.Move.performed += ctx => {
            direction = ctx.ReadValue<float>();
        };
        control.OnLand.Jump.performed += ctx => Jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
        animator.SetBool("IsJumping", !isGrounded);
        player.linearVelocity = new Vector2(direction * speed * Time.fixedDeltaTime, player.linearVelocity.y);
        animator.SetFloat("Speed", Mathf.Abs(direction));
        if (direction > 0 && !isFacingRight || direction < 0 && isFacingRight) Flip();

    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    void Jump()
    {
        if (isGrounded)
        {
            jumpCount=0;
            player.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            AudioManager.instance.Play("jump1");
            jumpCount++;
        }
        else if(jumpCount<2)
        {
            player.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            AudioManager.instance.Play("jump2");
            jumpCount++;
        }
    }
}
