using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveRiderPlayer : MonoBehaviour
{
    public SpriteRenderer[] players;

    public float speed;
    public float jumpForce;

    Rigidbody2D rb;

    private int usedJumps = 0;
    public int maxJumps = 2;




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

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && usedJumps < maxJumps)
        {
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

            //if (tag == "WaveSmall")
            //{
                
            //}
            //else if (tag == "WaveBig")
            //{
                
            //}
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //if (tag == "Water")
        //{
            
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FinishLine")
        {
            WaveRiderGameManager.Instance.reachFinishLine();
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("WaveRider");
        }
    }
}
