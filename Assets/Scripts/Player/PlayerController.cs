using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor.Experimental.GraphView;
using UnityEditorInternal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isTuchWall;
    private bool isFR = true;
    private bool canNormalJump;
    private bool canWallJump;
    private bool isWalking;
    private bool isGrounded;
    private bool isWallSliding;
    private bool isAttemptingtoJ;
    private bool checkJumpM;
    private bool canMove;
    private bool canFlip;
    private bool hasWllj;
    private bool isDashing;
    private bool knockBack;

    private int lastWallJumpD;
    public int amountOfJumps = 1;
    private int amountOfJumpsLedt;
    private int facingDriction = 1;

    private float wallJumpT;
    public float wallJumpTS = 0.5f;
    private float turnTimer;
    public float turnTimerS = 0.1f;
    public float MfInAir;
    public float speed = 10;
    public float jumpF = 16;
    public float groundChekr;
    private float mInputD;
    public float WallCgaeckDistance;
    public float WallSSpeed;
    public float airDragMulty = 0.95f;
    public float VeriableJumpHM = 0.5f;
    public float wallHopF;
    public float wallJumpF;
    private float JumpT;
    public float JumpTS = 0.15f;
    public float dashTime;
    public float dashSpeed;
    public float distanceBetweenImages;
    public float dashCoolDown;
    private float dashTimeLeft;
    private float lastImageXpos;
    private float lastDash = -100;
    private float KBstartTime;
    [SerializeField]
    private float KBduration;

    [SerializeField]
    private Vector2 KBSpeed;

    public Vector2 wallHopDirect;
    public Vector2 wallJumpDirect;


    public LayerMask whatIsGround;
    private Rigidbody2D rb;
    public Transform GroundChek;
    public Transform WallCgaeck;
    private Animator anim;
    public Transform ledgeChek;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        amountOfJumpsLedt = amountOfJumps;
        wallHopDirect.Normalize();
        wallJumpDirect.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        CheckMD();
        UpdateAnim();
        CheckCanJump();
        CheckIfWallSliding();
        CheckJump();
        ChaeckDash();
        CheckKB();
    }
    private void CheckG()
    {
        isGrounded = Physics2D.OverlapCircle(GroundChek.position, groundChekr, whatIsGround);
        isTuchWall = Physics2D.Raycast(WallCgaeck.position, transform.right, WallCgaeckDistance, whatIsGround);
  
    }
    private void CheckIfWallSliding()
    {
        if (isTuchWall && mInputD == facingDriction && rb.velocity.y <0)
        {
            isWallSliding = true;
        }
        else
        {
            isWallSliding = false;
        }
    }

    public bool GetDashStatus()
    {
        return isDashing;
    }

    public void KnockBack(int direction)
    {
        knockBack = true;
        KBstartTime = Time.time;
        rb.velocity = new Vector2(KBSpeed.x * direction, KBSpeed.y);
    }

    private void CheckKB()
    {
        if (Time.time >= KBstartTime + KBduration && knockBack)
        {
            knockBack = false;
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }
    }

    private void FixedUpdate()
    {
        Apllymove();
        CheckG();
    }
    private void CheckCanJump()
    {
        if (isGrounded && rb.velocity.y <= 0.01f)
        {
            amountOfJumpsLedt = amountOfJumps;
        }
        if (isTuchWall)
        {
            canWallJump = true;
        }
        if (amountOfJumpsLedt <= 0)
        {
            canNormalJump = false;

        }
        else
        {
            canNormalJump = true;
        }
    }
    private void CheckMD()
    {
        if (isFR && mInputD < 0)
        {
            Flip();
        }
        else if (!isFR && mInputD > 0)
        {
            Flip();
        }

        if (Mathf.Abs(rb.velocity.x) >= 0.01f)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }
    private void UpdateAnim()
    {
        anim.SetBool("W", isWalking);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVel", rb.velocity.y);
        anim.SetBool("WallS", isWallSliding);
    }
    private void CheckInput()
    {
        mInputD = Input.GetAxisRaw("Horizontal");
        
          if (Input.GetButtonDown("Jump"))
         {
            if (isGrounded || (amountOfJumpsLedt > 0 && !isTuchWall))
            {
                NormalJump();
            }
            else
            {
                JumpT = JumpTS;
                isAttemptingtoJ = true;
            }    
        }
        
        if (Input.GetButtonDown("Horizontal") && isTuchWall)
        {
            if (!isGrounded && mInputD != facingDriction)
            {
                canMove = false;
                canFlip = false;
                turnTimer = turnTimerS;
            }
        }

        if (turnTimer>=0)
        {
            turnTimer -= Time.deltaTime;
            if (turnTimer <=0)
            {
                canMove = true;
                canFlip = true;
            }
        }

        if (checkJumpM && !Input.GetButton("Jump"))
        {
            checkJumpM = false;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * VeriableJumpHM);
        }

        if (Input.GetButtonDown("Dash"))
        {
            if(Time.time >= (lastDash + dashCoolDown))
            AttemtToDash();
        }
    }

    private void AttemtToDash()
    {
        isDashing = true;
        dashTimeLeft = dashTime;
        lastDash = Time.time;

        plyerAfterImgePool2.Instance.GetFromPool();
        lastImageXpos = transform.position.x;
    }

    public int GetFacingDirection()
    {
        return facingDriction;
    }

    private void ChaeckDash()
    {
        if (isDashing)
        {
            if (dashTimeLeft > 0)
            {
                canMove = false;
                canFlip = false;
                rb.velocity = new Vector2(dashSpeed * facingDriction, 0);
                dashTimeLeft -= Time.deltaTime;

                if (Mathf.Abs(transform.position.x - lastImageXpos) > distanceBetweenImages)
                {
                    plyerAfterImgePool2.Instance.GetFromPool();
                    lastImageXpos = transform.position.x;
                }
            }
            if (dashTimeLeft < 0 || isTuchWall)
            {
                isDashing = false;
                canFlip = true;
                canMove = true;
            }
        }
    }
    private void CheckJump()
    {

        if (JumpT > 0)
        {
            if (!isGrounded && isTuchWall && mInputD != 0 && mInputD != facingDriction)
            {
                WallJump();
            }
            else if (isGrounded)
            {
                NormalJump();
            }
        }
            if(isAttemptingtoJ)
            {
                JumpT -= Time.deltaTime;
            if (hasWllj && mInputD == -lastWallJumpD)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0.0f);
                hasWllj = false;
            }
            else if (wallJumpT <= 0)
            {
                hasWllj = false;
            }
            else
            {
                wallJumpT -= Time.deltaTime;
            }

            }
        
    }
    private void NormalJump()
    {
        if (canNormalJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpF);
            amountOfJumpsLedt--;
            JumpT = 0;
            isAttemptingtoJ = false;
            checkJumpM = true;
        }
    }
    private void WallJump()
    {
       if (canWallJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0.0f);
            isWallSliding = false;
            amountOfJumpsLedt = amountOfJumps;
            amountOfJumpsLedt--;
            Vector2 forceToAdd = new Vector2(wallJumpF * wallJumpDirect.x * mInputD, wallJumpF * wallJumpDirect.y);
            rb.AddForce(forceToAdd, ForceMode2D.Impulse);
            JumpT = 0;
            isAttemptingtoJ = false;
            checkJumpM = true;
            turnTimer = 0;
            canFlip = true;
            canMove = true;
            hasWllj = true;
            wallJumpT = wallJumpTS;
            lastWallJumpD = -facingDriction;
        }

    }
    private void Apllymove()
    {
          if (!isGrounded && !isWallSliding && mInputD == 0 && !knockBack)
        {
            rb.velocity = new Vector2(rb.velocity.x * airDragMulty, rb.velocity.y);
        }
        else if(canMove && !knockBack) 
        {
            rb.velocity = new Vector2(speed * mInputD, rb.velocity.y);
        }
          
        if (isWallSliding)
        {
            if (rb.velocity.y < -WallSSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, -WallSSpeed);
            }
        }
    }
    public void DisableFlip()
    {
        canFlip = false;
    }
    public void EnableFlip()
    {
        canFlip = true;
    }
    private void Flip()
    {
        if (!isWallSliding && canFlip && !knockBack)
        {
            facingDriction *= -1;
            isFR = !isFR;
            transform.Rotate(0.0f, 180.0f, 0.0f);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(GroundChek.position, groundChekr);
        Gizmos.DrawLine(WallCgaeck.position, new Vector3(WallCgaeck.position.x + WallCgaeckDistance, WallCgaeck.position.y, WallCgaeck.position.z));
    }
}
