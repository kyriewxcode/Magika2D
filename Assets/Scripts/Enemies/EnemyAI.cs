using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("A*寻路")]
    protected Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    protected Path path;
    protected int currentWaypoint = 0;
    public bool endOfPath = true;
    protected Seeker seeker;
    protected Rigidbody2D rb;
    public Transform Ground;

    [Header("属性")]
    public int hp;
    public float AtkRate = 5f;
    public float lastAtkTime;
    protected Animator Anim;

    [Header("状态")]
    public bool isAtk = false;
    public bool isFinding = false;
    public bool isHurt = false;
    public bool isDie = false;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();
        Anim = GetComponent<Animator>();
        InvokeRepeating("UpdatePath", 0f, .5f);
        
    }
    private void Update()
    {
        OnAnimatorChange();
    }
    void FixedUpdate()
    {
        PathFinding();
        AtkControl();
    }
    void UpdatePath()
    {
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    protected virtual void PathFinding()
    {
        if (path == null)
            return;
        if (currentWaypoint >= path.vectorPath.Count)
        {
            endOfPath = true;
            return;
        }
        else endOfPath = false;

        Vector2 dir = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = dir * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
            currentWaypoint++;

        if (force.x >= 0.01f)
            transform.localScale = new Vector3(-1f, 1f, 1f);
        else if (force.x <= -0.01f)
            transform.localScale = new Vector3(1f, 1f, 1f);
    }

    protected virtual void AtkControl()
    {
    }

    void OnAnimatorChange()
    {
        if(isAtk)
        {
            Anim.SetBool("isAtk", true);
        }
        else
        {
            Anim.SetBool("isAtk", false);
        }

        if(isDie)
        {
            Anim.SetBool("isDie", true);
        }

    }

    public void TakeDamage(int damage)
    {
        Anim.SetBool("isHurt", true);
        hp -= damage;
        if(hp<=0)
        {
            Anim.SetBool("isDie", true);
        }
        Debug.Log(hp);
    }

    void AnimReset()
    {
        Anim.SetBool("isHurt", false);
        isAtk = false;
    }
    void DestoryGameObeject()
    {
        if (Anim.GetBool("isDie"))
        {
            Destroy(gameObject);
        }
    }
}
