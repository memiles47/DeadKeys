using UnityEngine;

public class CameraFacing : MonoBehaviour
{
    private Transform _thisTransform;

    // Use this for initialization
    public void Awake ()
    {
        _thisTransform = GetComponent<Transform>();
    }
    
    // Update is called once per frame
    public void LateUpdate ()
    {
        _thisTransform.LookAt(Camera.main.transform);
    }
}
