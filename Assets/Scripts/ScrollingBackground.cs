using UnityEngine;
using UnityEngine.UIElements;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField]
    private Renderer bgRenderer;

    public float speedHorizontal;
    public float speedVertical;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(speedHorizontal * Time.deltaTime, speedVertical * Time.deltaTime);
    }
}
