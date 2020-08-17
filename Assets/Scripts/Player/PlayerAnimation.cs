using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    PlayerChracterMove player;
    AttackControl atk;
    public Animator anim;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<PlayerChracterMove>();
        anim = GetComponentInChildren<Animator>();
        atk = GetComponentInChildren<AttackControl>();
    }
    private void Update()
    {
        AnimChange();
    }
    private void FixedUpdate()
    {
        AnimChange();
    }

    void AnimChange()
    {
        if (player.isFighting)//战斗状态
            anim.SetBool("isFighting", true);
        else
            anim.SetBool("isFighting", false);

        if (GetComponent<EnemyCheck>().enemySign)
            anim.SetBool("FoughtChange",true);
        else
            anim.SetBool("FoughtChange", false);

        if (player.isRunning)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);

        if (player.isCrouching)
            anim.SetBool("isCrouching", true);
        else
            anim.SetBool("isCrouching", false);

        if (player.isJumping)
            anim.SetBool("isJumping", true);
        else
            anim.SetBool("isJumping", false);

        if (player.isFalling)
            anim.SetBool("isFalling", true);
        else
            anim.SetBool("isFalling", false);

        if (player.isSliding)
            anim.SetBool("isSliding", true);
        else
            anim.SetBool("isSliding", false);

        anim.SetInteger("AtkNum", atk.atkNum);
        if (atk.isAirAtk && player.isFalling && rb.velocity.y < 0.1f)
            anim.SetBool("AirAtk", true);
        else if (!atk.isAirAtk)
            anim.SetBool("AirAtk", false);

        if (player.Atk && player.isFighting)
            anim.SetBool("Atk", true);
        else
            anim.SetBool("Atk", false);
    }

}
