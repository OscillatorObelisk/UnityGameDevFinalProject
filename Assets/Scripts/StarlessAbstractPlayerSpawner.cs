using UnityEngine;

public class StarlessAbstractPlayerSpawner : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    public GameObject[] aiPrefabs;

    private Transform[] spawnPoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int id = PlayerData.selectedCharacter;

        // Shuffle spawn points
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Transform temp = spawnPoints[i];
            int randomIndex = Random.Range(i, spawnPoints.Length);
            spawnPoints[i] = spawnPoints[randomIndex];
            spawnPoints[randomIndex] = temp;
        }

        Instantiate(playerPrefabs[id], spawnPoints[0].position, playerPrefabs[id].transform.rotation);

        int aiIndex = 0;
        for (int i = 1; i < spawnPoints.Length; i++)
        {
            int aiCharID = aiIndex;
            if (aiCharID >= id)
            {
                aiCharID++;
            }
            Instantiate(aiPrefabs[aiCharID], spawnPoints[i].position, Quaternion.identity);
            aiIndex++;
        }
    }
    void Awake()
    {
        spawnPoints = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            spawnPoints[i] = transform.GetChild(i);
        }
    }
}
