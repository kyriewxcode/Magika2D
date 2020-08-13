using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    public Transform targetPos;
    // Start is called before the first frame update
    void Start()
    {
        Seeker seeker;
        seeker = GetComponent<Seeker>();
        seeker.StartPath(transform.position, targetPos.position, OnPathComplete);
    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("Yay, we got a path back. Did it have an error? " + p.error);
    }
}
