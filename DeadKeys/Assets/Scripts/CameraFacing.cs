using UnityEngine;

public class CameraFacing : MonoBehaviour
{
    private Transform _thisTransform;

    public void Awake ()
    {
        _thisTransform = GetComponent<Transform>();
    }
    
    public void LateUpdate ()
    {
        _thisTransform.LookAt(Camera.main.transform);
    }
}
