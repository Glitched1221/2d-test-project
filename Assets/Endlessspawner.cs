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
            if (objectToSpawn != null && spawnPoint != null)
            {
                if (maxenimes == false)
                { 
                enimessamount += 1f;
                Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
                }  
                else
                {
                    //Debug.LogWarning("Ah");
                }

                
            }
            
            yield return new WaitForSeconds(spawnInterval);
            spawnInterval = Mathf.Max(mininumSpawnInterval, spawnInterval - intervalDeacrease);
        }
    }

    
}
