using UnityEngine;

public class jellyfish : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float speed = 1f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position = startPos + Vector3.up * Mathf.Sin(Time.time * speed) * amplitude;
    }
}
