using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cam;

    private void FixedUpdate()
    {
        transform.position = new Vector3(cam.position.x, transform.position.y, transform.position.z);
    }
}
