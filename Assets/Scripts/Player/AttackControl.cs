using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControl : MonoBehaviour
{
    PlayerChracterMove player;
    public bool isAirAtk;
    public int atkNum = 0;
    float lastAtkTime = 0;
    float maxComboDelay = 1.5f;

    public Transform atkPos1;
    public Transform atkPos2;
    public float atkRadius;
    public int atkDamage;
    Collider2D[] atkEnemies;

    public Transform airAtkPos1;
    public Transform airAtkPos2;
    public float airAtkRadius;
    public int airAtkDamage;
    Collider2D[] airAtkEnemies;

    public LayerMask enemyLayer;
    void Start()
    {
        player = GetComponentInParent<PlayerChracterMove>();
    }
    private void FixedUpdate()
    {
    }
    void Update()
    {
        atkEnemies = Physics2D.OverlapAreaAll(atkPos1.position, atkPos2.position, enemyLayer);
        airAtkEnemies = Physics2D.OverlapAreaAll(airAtkPos1.position, airAtkPos2.position, enemyLayer);
        if (Time.time - lastAtkTime > maxComboDelay)
            atkNum = 0;

        if (atkNum > 3)
            atkNum = 1;
        if (UserKeyListener.getKeyDownJ && !player.isGround && player.isFighting)
        {
            isAirAtk = true;
        }
        else if (UserKeyListener.getKeyDownJ && player.isGround && player.isFighting)
        {
            lastAtkTime = Time.time;
            atkNum++;
            player.Atk = true;
        }
    }

    void AtkDamage()//把AtkDamage放到Update里，为敌人添加已经被攻击过的标记
    {
        if(atkEnemies.Length!=0 && player.Atk)
        {
            Debug.Log("atk");
            foreach (Collider2D enemy in airAtkEnemies)
            {
                enemy.GetComponent<EnemyAI>().TakeDamage(atkDamage);
            }
            GetComponent<Shock>().相机震动();
        }
        if(airAtkEnemies.Length!=0 && isAirAtk)
        {
            Debug.Log("airAtk");
            foreach (Collider2D enemy in airAtkEnemies)
            {
                enemy.GetComponent<EnemyAI>().TakeDamage(airAtkDamage);
            }
            GetComponent<Shock>().相机震动();
        }
    }

    void AtkFinish()
    {
        isAirAtk = false;
        player.Atk = false;
    }
}
