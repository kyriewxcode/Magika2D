using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    PlayerChracterMove player;
    int enemyCount = 0;
    public bool enemySign = false;
    public float CheckRange = 5f;
    public LayerMask enemiesLayer;
    public List<Collider2D> Enemies = new List<Collider2D>();
    //Collider2D[] Enemies;

    void Start()
    {
        player = GetComponent<PlayerChracterMove>();
    }

    void Update()
    {
        Enemies = Physics2D.OverlapCircleAll(transform.position, CheckRange,enemiesLayer).ToList();
        enemyCount = Enemies.Count;
        //IsFighting();
    }

    /*void IsFighting()
    {

        if (Enemies.Count != 0)
        {
            enemySign = enemyCount == 0;
            player.isFighting = true;
        }
        else
        {
            enemySign = enemyCount != 0;
            player.isFighting = false;
        }
        if(!player.isRunning)
        {
            enemyCount = Enemies.Count;
        }
    }*/

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, CheckRange);
    }
}
