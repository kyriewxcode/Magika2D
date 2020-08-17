using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class GoblinControl : EnemyAI
{
    float FollowTime;
    protected override void PathFinding()
    {
        if (path == null) return;
        if (currentWaypoint >= path.vectorPath.Count)
        {
            FollowTime = Time.time;
            endOfPath = true;
            return;
        }
        else
        {
            FollowTime -= Time.deltaTime;
            if(Time.time-FollowTime>1f)
                endOfPath = false;
        }

        Vector2 dir = new Vector2(((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized.x
                    , transform.position.normalized.y);
        Vector2 force = dir * speed * Time.deltaTime;

        if(!endOfPath)
            rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
            currentWaypoint++;

        if (force.x >= 0.01f)
            transform.localScale = new Vector3(-1f, 1f, 1f);
        else if (force.x <= -0.01f)
            transform.localScale = new Vector3(1f, 1f, 1f);
    }

    protected override void AtkControl()
    {
        if (endOfPath)
        {
            if(Time.time-lastAtkTime>AtkRate)
            {
                lastAtkTime = Time.time;
                isAtk = true;
            }
        }
    }
}
