using UnityEngine;

public class BlinkingBackground : MonoBehaviour
{
    public SpriteRenderer[] backgrounds;
    public float interval = 2f;
    private int index = 0;
    

    void Start()
    {
        InvokeRepeating(nameof(SwapBackground), interval, interval);
    }

    void SwapBackground()
    {
        backgrounds[index].gameObject.SetActive(false);
        index = (index + 1) % backgrounds.Length;
        backgrounds[index].gameObject.SetActive(true);
    }
}
