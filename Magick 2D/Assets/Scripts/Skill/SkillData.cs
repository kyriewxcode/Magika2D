using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SkillData
{
    public string skillName;
    public string skillPreAnimName;
    public string skillAnimName;

    public GameObject bulletPrefab;
    
    public float sillDamage;
    public float skillRange;

    public bool havaPre;
    

    public Transform bulletPos;
}
