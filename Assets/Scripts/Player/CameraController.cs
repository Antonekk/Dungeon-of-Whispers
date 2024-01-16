using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public void SetCameraXZCoords(Vector3 pos)
    {
        transform.position = new Vector3(pos.x,transform.position.y,pos.z);
    }
}
