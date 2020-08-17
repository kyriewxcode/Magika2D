using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Character : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody2D rb;
 
    [Header("属性")]
    public float Health;
    public string Name;
    public int Id;
    public float Speed;
    public float jumpForce;
    public int jumpCount;
    public BoxCollider2D cd;

    [Header("状态")]
    public bool isFighting = false;
    public bool isRunning = false;
    public bool isCrouching = false;
    public bool isJumping = false;
    public bool isFalling = false;
    public bool isCliming = false;
    public bool isSliding = false;
    public bool isGrabingWall = false;
    public bool isWallSliding = false;
    public bool isCast = false;
    public float AtkTime;
    public bool Atk;
    public bool isHurt = false;
    public bool isDie = false;
    [Space]
    public bool isGround = false;
    public bool isAir = false;
    public bool isNearWall = false;
}
