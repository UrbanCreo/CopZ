using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float horizontalInput;

    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip rollSound;
    [SerializeField] private AudioClip SpinningSound;

    private void Awake()
    {
        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //Flip player when facing left/right.
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        //Set animator parametres
        anim.SetBool("walk", horizontalInput != 0);
        anim.SetBool("grounded", IsGrounded());

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //Jump
        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            Jump();

            if (Input.GetKeyDown(KeyCode.Space))
                SoundManager.instance.PlaySound(jumpSound);
        }

        //Dodge
        if (Input.GetKeyDown(KeyCode.C))
        {
            Dodge();

            Vector3 dodgePosition = transform.position - transform.right * 2f;
            transform.position = dodgePosition;
        }

        // High Kick
        if (Input.GetKeyDown(KeyCode.X))
        {
            HighKick();
        }

        //Strike
        if (Input.GetKeyDown(KeyCode.V))
        {
            Strike();
        }
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpPower);
        SoundManager.instance.PlaySound(jumpSound);
        anim.SetTrigger("jump");
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    public bool CanAttack()
    {
        return horizontalInput == 0 && IsGrounded();
    }

    private void Dodge()
    {
        SoundManager.instance.PlaySound(rollSound);
        anim.SetTrigger("dodge");
    }

    private void HighKick()
    {
        SoundManager.instance.PlaySound(SpinningSound);
        anim.SetTrigger("highkick");
    }

    private void Strike()
    {
        anim.SetTrigger("strike");
    }
}