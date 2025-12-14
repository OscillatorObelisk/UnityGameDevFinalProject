using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveRiderPlayer : MonoBehaviour
{
    public SpriteRenderer surfboardRenderer;
    public SpriteRenderer[] players;
    public float speed;
    public float jumpForce;
    Rigidbody2D rb;
    private int usedJumps = 0;
    public int maxJumps = 2;
    public AudioSource audioSource;
    public AudioClip jumpSFX;
    public PauseManager pm;
    public WaveRiderGameManager wgm;
    public GameObject waves;
    public Sprite[] surfboardSprites;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        int id = PlayerData.selectedCharacter;

        for (int i = 0; i < players.Length; i++)
        {
            if(i == id)
            {
                players[i].gameObject.SetActive(true);
            }
        }

        //color of the surfboard
        surfboardRenderer.sprite = surfboardSprites[id];

    }

    // Update is called once per frame
    void Update()
    {
        if (pm.isPaused) return;
        if (wgm.finished) return;

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0)) && usedJumps < maxJumps)
        {

            audioSource.clip = jumpSFX;
            audioSource.Play();

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            usedJumps++;
        }
    }

    private void FixedUpdate()
    {

        Vector2 vel = rb.linearVelocity;
        vel.x = speed;
        rb.linearVelocity = vel;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        if (tag == "Water" || tag == "WaveSmall" || tag == "WaveBig")
        {
            usedJumps = 0;

            if (tag == "Water")
            {
                waves.SetActive(true);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        if (tag == "Water")
        {
            waves.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FinishLine")
        {
            WaveRiderGameManager.Instance.reachFinishLine();
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

}
