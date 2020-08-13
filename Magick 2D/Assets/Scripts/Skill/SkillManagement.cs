using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SkillManagement : MonoBehaviour
{
    [SerializeField]
    public static List<GameObject> enemyList = new List<GameObject>();
    public static Collider2D[] enemiesMeteor;
    public static Collider2D[] enemiesCombat;

    public Transform combatPos;
    public LayerMask enmeyLayers;
    public SkillData[] skill;
    public bool isAtking = false;//正在攻击

    Rigidbody2D rb;
    private Animator Anim;
    private void Start()
    {
        Anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        SkillMeteor();
        Combat();
    }
    void Combat()
    {
        enemiesCombat = Physics2D.OverlapCircleAll(skill[0].bulletPos.position, skill[0].skillRange, enmeyLayers);
        if (UserKeyListener.getMouseButtonDown0)
        {
            Anim.SetTrigger(skill[0].skillAnimName);
        }
    }
    void SkillMeteor()
    {
        enemiesMeteor = Physics2D.OverlapCircleAll(skill[1].bulletPos.position, skill[1].skillRange, enmeyLayers);
        if (rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            if (UserKeyListener.getKeyHoldE)
            {
                if (!Anim.GetBool(skill[1].skillAnimName) && Anim.GetBool("Idel"))
                {
                    UserKeyListener.canMove = false;
                    isAtking = true;
                    if (!IsInvoking("MeteorBulletIns"))
                    {
                        InvokeRepeating("MeteorBulletIns", 0.5f, 0.1f);
                    }
                    Anim.SetBool(skill[1].skillAnimName, true);
                }
            }
            if (UserKeyListener.getKeyUpE)
            {
                isAtking = false;
                CancelInvoke("MeteorBulletIns");
                Anim.SetBool(skill[1].skillAnimName, false);
                UserKeyListener.canMove = true;
            }
        }
    }
    void MeteorBulletIns()
    {
        if (isAtking == true && enemiesMeteor.Length!=0)
        {
            GameObject bulletObject = Instantiate(skill[1].bulletPrefab, skill[1].bulletPos.position, Quaternion.identity);
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(skill[0].bulletPos.position, skill[0].skillRange);
        Gizmos.DrawWireSphere(skill[1].bulletPos.position, skill[1].skillRange);
    }
}