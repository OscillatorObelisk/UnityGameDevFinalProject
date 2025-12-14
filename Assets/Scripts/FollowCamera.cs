using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform cam;
    public Vector3 offset;

    void LateUpdate()
    {
        transform.position = cam.position + offset;
    }
}
