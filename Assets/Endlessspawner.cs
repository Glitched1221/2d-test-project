using System.Collections;
using System.Collections.Generic;


using UnityEngine;

public class Endlessspawner : MonoBehaviour
{
    public GameObject[] objectToSpawn;
    public Transform[] spawnPoints;

    // public GameObject spawnPoint2;
    //  public GameObject spawnPoint3;


    float spawnInterval = 2f;
    float mininumSpawnInterval =1f;
    float intervalDeacrease = 0.5f;
    int maxEnimesNum;
    bool maxenimes;
    public float enimessamount;
    private IEnumerator spawnCoroutine;

    



    

    // Start is called before the first frame update
    void Start()
    {
        spawnCoroutine = SpawnEnemies();
        StartCoroutine(SpawnEnemies());

        enimessamount = 0;
        maxEnimesNum = 10;
    }

    void Update()
    {
        if (enimessamount >= maxEnimesNum)
        {
         maxenimes = true;
        } 
    }

    // Update is called once per fram

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            
            if (objectToSpawn != null)// && spawnPoint != null)
            {
                if (maxenimes == false)
                { 
                enimessamount += 1f;
                int randEnemy = Random.Range(0, objectToSpawn.Length);
                int randSpawnPoint = Random.Range(0, spawnPoints.Length);

                Instantiate(objectToSpawn[0], spawnPoints[randSpawnPoint].position, transform.rotation);
                // Instantiate(objectToSpawn, spawnPoint1.position, spawnPoint1.rotation);
                // Instantiate(objectToSpawn, spawnPoint2.position, spawnPoint1.rotation);
                // Instantiate(objectToSpawn, spawnPoint3.position, spawnPoint1.rotation);

                }  
            

                
            }
            
            yield return new WaitForSeconds(spawnInterval);
            spawnInterval = Mathf.Max(mininumSpawnInterval, spawnInterval - intervalDeacrease);
        }
        
        
    }
    public void DestoyObjects()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject target in gameObjects)
        {
            GameObject.Destroy (target);
        }
    }

    public void StopSpawning()
    {
        StopCoroutine(spawnCoroutine);
    }

    
    
    
}
