using UnityEngine;

public class PunchPlayer : MonoBehaviour
{
    public Animator anim;
    public GameObject punchObject;
    public float punchDuration = 0.2f;

    private float punchTimer = 0f;
    private bool isPunching = false;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isPunching)
        {
            //anim.SetTrigger("Punch");
            punchObject.SetActive(true);
            isPunching = true;
            punchTimer = 0f;
        }

        if (isPunching)
        {
            punchTimer += Time.deltaTime;
            if (punchTimer >= punchDuration)
            {
                punchObject.SetActive(false);
                isPunching = false;
            }
        }
    }
}
