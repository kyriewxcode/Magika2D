using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shock : MonoBehaviour
{
    private Cinemachine.CinemachineCollisionImpulseSource MyInpulse;
    // Start is called before the first frame update
    void Start()
    {
        MyInpulse = GetComponentInParent<Cinemachine.CinemachineCollisionImpulseSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void 相机震动()
    {
        MyInpulse.GenerateImpulse();
    }
}
