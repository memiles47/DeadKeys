using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFacing : MonoBehaviour
{
    private Transform _thisTransform;

    // Use this for initialization
    void Awake ()
    {
        _thisTransform = GetComponent<Transform>();
    }
    
    // Update is called once per frame
    void LateUpdate ()
    {
        _thisTransform.LookAt(Camera.main.transform);
    }
}
