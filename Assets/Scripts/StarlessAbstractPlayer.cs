using UnityEngine;

public class StarlessAbstractPlayer : MonoBehaviour
{

    private Rigidbody2D playerRigidBody;
    private float inputHorizontal;
    public float movementSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        if (inputHorizontal != 0)
        {
            playerRigidBody.linearVelocity = new Vector2(movementSpeed * inputHorizontal, playerRigidBody.linearVelocity.y);

            
            //flipPlayerSprite(inputHorizontal);

            //playerAnimator.SetBool("isWalking", true);
        }
        else
        {            
            playerRigidBody.linearVelocity = new Vector2(0, playerRigidBody.linearVelocity.y);            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }        
    }
}
