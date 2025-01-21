using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Endlessspawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnPoint;
    float spawnInterval = 2f;
    float mininumSpawnInterval =1f;
    float intervalDeacrease = 0.5f;

    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per fram

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (objectToSpawn != null && spawnPoint != null)
            {
                Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
               }   
                else
                {
                    Debug.LogWarning("Ah");
                }
          
            
            yield return new WaitForSeconds(spawnInterval);
            spawnInterval = Mathf.Max(mininumSpawnInterval, spawnInterval - intervalDeacrease);
        }
    }

    
}
