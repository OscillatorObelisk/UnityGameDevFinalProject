using UnityEngine;

public class StarFallSpawner : MonoBehaviour
{
    public GameObject star;
    public float spawnInterval = 1f;
    private Transform[] spawnPoints;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(Spawn), 0f, spawnInterval);
    }

    void Awake()
    {
        spawnPoints = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            spawnPoints[i] = transform.GetChild(i);
        }
    }

    void Spawn()
    {

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(star, spawnPoint.position, star.transform.rotation);
    }
    
}
