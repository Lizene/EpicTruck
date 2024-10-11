using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTransform;
    float camZ;
    void Start()
    {
        camZ = transform.position.z;
    }

    void Update()
    {
        Vector2 newCamPos2D = Vector2.Lerp(transform.position, followTransform.position, 0.7f * Time.deltaTime * 60f);
        transform.position = new Vector3(newCamPos2D.x, newCamPos2D.y, camZ);
    }
}
