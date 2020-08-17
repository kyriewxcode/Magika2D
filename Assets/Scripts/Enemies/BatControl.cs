using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatControl : EnemyAI
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == target && target.position.y - transform.position.y < 0)
        {
            rb.AddForce(-(target.position - transform.position).normalized * 8f, ForceMode2D.Impulse);
        }
    }
    protected override void AtkControl()
    {
        float Dir = Vector2.Distance(transform.position, target.position);
        if (Dir <= nextWaypointDistance)
        {
            isAtk = true;
            if (Time.time - lastAtkTime > AtkRate)
            {
                lastAtkTime = Time.time;
                rb.AddForce((target.position - transform.position).normalized * 8f, ForceMode2D.Impulse);
            }

        }
        else
        {
            isAtk = false;
        }
        if (rb.transform.position.y < -3f)
        {
            rb.AddForce(transform.up * 10f);
        }
    }

}
