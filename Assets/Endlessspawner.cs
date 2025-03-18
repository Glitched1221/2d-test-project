using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Endlessspawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
     public Transform spawnPoint3;


    float spawnInterval = 2f;
    float mininumSpawnInterval =1f;
    float intervalDeacrease = 0.5f;
    bool maxenimes;
    public float enimessamount;

    



    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
        enimessamount = 0;
    }

    void Update()
    {
        if (enimessamount >= 5f)
        {
         maxenimes = true;
        } 
    }

    // Update is called once per fram

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (objectToSpawn != null && spawnPoint1 != null)
            {
                if (maxenimes == false)
                { 
                enimessamount += 1f;
                Instantiate(objectToSpawn, spawnPoint1.position, spawnPoint1.rotation);
                Instantiate(objectToSpawn, spawnPoint2.position, spawnPoint1.rotation);
                Instantiate(objectToSpawn, spawnPoint3.position, spawnPoint1.rotation);

                }  
            

                
            }
            
            yield return new WaitForSeconds(spawnInterval);
            spawnInterval = Mathf.Max(mininumSpawnInterval, spawnInterval - intervalDeacrease);
        }
    }

    
}
