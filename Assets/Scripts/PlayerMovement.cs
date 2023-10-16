using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private bool moveLeft;
    private bool moveRight;
    private bool moveJump;
    private bool facingRight;
    private float horizontalMove;
    public float speed = 5;
    public float jumpspeed = 5;

    [SerializeField] private AudioSource jumpEffect;

    //private enum MovementState { idle, running, jumping, falling }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        moveLeft = false;
        moveRight = false;
        moveJump = false;
        facingRight = false;
    }

    public void PointerDownLeft()
    {
        moveLeft = true;
        

    }
    public void PointerUpLeft()
    {
        moveLeft = false;
       
    }
    public void PointerDownRight()
    {
        moveRight = true;

    }
    public void PointerUpRight()
    {
        moveRight = false;

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        moveJump = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        moveJump = false;
    }


    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        UpdateAnimation();
    }

    private void MovePlayer()
    {
       
        if (moveLeft == true)
        {
            
            horizontalMove = -speed;
            animator.SetBool("running", true);

        }
        else if (moveRight == true )
        {
            
            horizontalMove = speed;
            animator.SetBool("running", true);
        }
        else
        {
            
            horizontalMove = 0;
            animator.SetBool("running", false);
        }
        
    }
    public void JumpButton()
    {
        //MovementState state;
        if (moveJump == true)
        {
            //state = MovementState.jumping;
            rb.velocity = Vector2.up * jumpspeed;
            jumpEffect.Play();
        }
       // animator.SetInteger("state", (int)state);

    }
    private void UpdateAnimation()
    {
        if (moveJump == false)
        {
            animator.SetBool("jumping", true);
        }
        else
        {
            animator.SetBool("jumping", false);
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
        if(moveLeft == true && facingRight == false)
        {
            Flip();
        }
        else if(moveRight == true && facingRight == true)
        {
            Flip();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

}
