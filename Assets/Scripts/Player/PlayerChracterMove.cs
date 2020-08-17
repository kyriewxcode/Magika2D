using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChracterMove : Character
{
    [Header("交互")]
    public float moveX = 0;
    public float moveY = 0;
    public bool jumpPressed = false;
    public float SlideTime = 0.7f;

    [Header("子物体")]
    public GameObject body;
    public Transform topPos;
    public Transform downPos;
    public Transform leftPos;
    public Transform rightPos;

    [Header("碰撞层")]
    public LayerMask groundLayer;
    public LayerMask objectLayer;

    [Header("物理材质")]
    public PhysicsMaterial2D groundMaterial;
    public PhysicsMaterial2D airMaterial;

    [Header("参数")]
    public float haftOffsetY;
    public float haftSizeY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Health = 100;
        Name = "Player";
        Id = 0;
        jumpCount = 2;
        haftOffsetY = cd.offset.y * 2.8f;
        haftSizeY = cd.bounds.size.y / 2;
    }
    void Update()
    {
        UserKeyListener.GetInstance().KeyListener();
        IsGround();//检测接地
        IsNearWall();//判断触墙
        UserInput();//用户输入
    }
    private void FixedUpdate()
    {
        Run();//跑
        FaceDir();//角色朝向
        Jump();//跳
        Slide();//滑
        Crouch();//蹲
        BetterJump();//按键时长跳跃
    }

    //====================================================================================================================================================

    private void UserInput()
    {
        moveX = UserKeyListener.horizontalValueRaw;
        moveY = UserKeyListener.verticalValueRaw;
        
        if (moveX != 0)//判读奔跑
        { isRunning = true; }
        else
        { isRunning = false; }

        if (UserKeyListener.jumpButtonDown && jumpCount > 0)//判断跳跃按下
            jumpPressed = true;

        if(UserKeyListener.getKeyHoldCtrl)
        {
            isCrouching = true;
        }

        if (UserKeyListener.getKeyDownE && isFighting)
        {
            isFighting = false;
        }
        else if (UserKeyListener.getKeyDownE && !isFighting)
        {
            isFighting = true;
        }
    }
    private void IsNearWall()
    {
        if (Physics2D.OverlapCircle(leftPos.position, 0.1f, objectLayer))
        {
            Debug.DrawLine(leftPos.position, new Vector3(leftPos.position.x + 0.1f, leftPos.position.y), Color.green);
            isNearWall = true;
        }
        else
        {
            isNearWall = false;
        }
        if (isNearWall) rb.sharedMaterial = airMaterial;
    }
    private void IsGround()
    {

        if (Physics2D.OverlapCircle(downPos.position, 0.1f, groundLayer))
        {
            Debug.DrawLine(downPos.position, new Vector3(downPos.position.x, downPos.position.y - 0.1f), Color.green);
            rb.sharedMaterial = groundMaterial;
            isGround = true;
            jumpCount = 2;
            isFalling = false;
            isJumping = false;
        }
        else
        {
            rb.sharedMaterial = airMaterial;
            isGround = false;
        }
    }
    private void FaceDir()
    {
        if (rb.velocity.x > 0.1f)
            transform.localScale = new Vector3(1, 1, 1);
        else if (rb.velocity.x < -0.1f)
            transform.localScale = new Vector3(-1, 1, 1);
    }
    void Run()
    {
        if(isRunning&&UserKeyListener.canMove)
        {
            rb.velocity = new Vector2(moveX * Speed * Time.fixedDeltaTime, rb.velocity.y);
        }
    }
    void BetterJump()
    {
        if (rb.velocity.y > 0.1 && !UserKeyListener.jumpButtonHold)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * 2f * Time.deltaTime;
        }
        if (rb.velocity.y > 0.1)
        {
            isJumping = true;
            isFalling = false;
        }
        if (rb.velocity.y < -0.1f)
        {
            isJumping = false;
            isFalling = true;
            rb.velocity += Vector2.up * Physics2D.gravity * 1.5f * Time.deltaTime;
        }
    }
    void Crouch()
    {
        if(isCrouching)
        {
            cd.offset = new Vector2(cd.offset.x,haftOffsetY);
            cd.size = new Vector2(cd.bounds.size.x, haftSizeY);
            isCrouching = false;
            if (isRunning)
                rb.velocity -= new Vector2(rb.velocity.x / 2, rb.velocity.y);
        }
        else
        {
            cd.offset = new Vector2(cd.offset.x, haftOffsetY/2.8f);
            cd.size = new Vector2(cd.bounds.size.x, haftSizeY*2);
        }
    }
    void Slide()
    {
        if (UserKeyListener.getKeyHoldShift && rb.velocity.x != 0)
        {
            SlideTime -= Time.deltaTime;
            isSliding = true;
            rb.velocity += Vector2.right * 1.5f * transform.localScale.x;
            if (SlideTime < 0)
                isSliding = false;
        }
        else
        {
            isSliding = false;
            SlideTime = 0.7f;
        }
            
    }
    void Jump()
    {
        if (jumpPressed && isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
            jumpPressed = false;
            jumpCount = 1;
        }
        else if(jumpPressed && !isGround && jumpCount>0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
            jumpPressed = false;
            jumpCount = 0;
        }
    }
}
