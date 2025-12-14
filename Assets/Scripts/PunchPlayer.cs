using UnityEngine;

public class PunchPlayer : MonoBehaviour
{
    //public Animator anim;
    public GameObject punchObject;
    public float punchDuration = 0.2f;

    private float punchTimer = 0f;
    private bool isPunching = false;

    public AudioSource audioSource;
    public AudioClip punchMissSFX;

    //void Awake()
    //{
    //    anim = GetComponent<Animator>();
    //}

    void Update()
    {

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0)) && !isPunching)
        {
            audioSource.PlayOneShot(punchMissSFX);
            //anim.SetTrigger("punch");
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
