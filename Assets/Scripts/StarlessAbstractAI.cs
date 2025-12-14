using UnityEngine;

public class StarlessAbstractAI : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;

    public float movementSpeed = 5f;

    public float decisionInterval = 1.0f;
    private float decisionTimer = 0f;

    private float inputHorizontal = 0f;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        PickNewDirection();
    }

    void FixedUpdate()
    {
        decisionTimer += Time.fixedDeltaTime;

        if (decisionTimer >= decisionInterval)
        {
            decisionTimer = 0f;
            PickNewDirection();
        }

        playerRigidBody.linearVelocity = new Vector2(
            inputHorizontal * movementSpeed,
            playerRigidBody.linearVelocity.y
        );
    }

    void PickNewDirection()
    {
        int choice = Random.Range(0, 3);

        if (choice == 0)
        {
            inputHorizontal = -1f;
        }
        else if (choice == 1)
        {
            inputHorizontal = 0f;
        }
        else
        {
            inputHorizontal = 1f;
        }
    }
}
