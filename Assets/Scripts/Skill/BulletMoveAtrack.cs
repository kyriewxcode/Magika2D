using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BulletMoveAtrack : MonoBehaviour
{
    public float bulletSpeed;
    public Vector3 enemyPos;
    Color color;
    GameObject player;
    SkillManagement enemyList;
    [System.Obsolete]
    private void Awake()
    {
        color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        GetComponent<SpriteRenderer>().color = color;
        GetComponent<TrailRenderer>().startColor = color;
        GetComponentInChildren<ParticleSystem>().startColor = color;
        player = GameObject.FindGameObjectWithTag("Player");

        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float minDistanceEnemy = 100f;
        Vector3 minEnemyPos = Vector3.zero;
        //Debug.Log(SkillManagement.enemiesMeteor[0].name);

        for(int i =0;i<SkillManagement.enemiesMeteor.Length;i++)
        {
            if (Vector3.Distance(SkillManagement.enemiesMeteor[i].transform.position, player.transform.position) < minDistanceEnemy)
            {
                minDistanceEnemy = Vector3.Distance(SkillManagement.enemiesMeteor[i].transform.position, player.transform.position);
                minEnemyPos = SkillManagement.enemiesMeteor[i].transform.position;
                Debug.Log(SkillManagement.enemiesMeteor[i].name);
            }
        }
        enemyPos = minEnemyPos;


        Vector3 direction = transform.position - enemyPos;
	    float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
	    transform.eulerAngles = new Vector3(0, 0, angle+Random.Range(-360f,360f));
    }

    [System.Obsolete]
    void Update()
    {
        transform.up = Vector3.Slerp(transform.up, enemyPos - transform.position, 0.25f / Vector2.Distance(transform.position, enemyPos));
        transform.position += transform.up * bulletSpeed * Time.deltaTime;
        if(Vector2.Distance(transform.position,enemyPos)<0.1f) 
        {
            Destroy(gameObject);
        }
    }
}
