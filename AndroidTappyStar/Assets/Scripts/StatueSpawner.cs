using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueSpawner : MonoBehaviour {

    public float maxYpos;
    public float spawnTime;
    public GameObject statue;
    int count;
    bool keepSpawning;
    public static StatueSpawner instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start() {
        keepSpawning = true;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    { 
        
    }
    
    public void StopSpawningStatues()
    {
        keepSpawning = false;
    }

    public void StartSpawningStatues()
    {
        StartCoroutine(SpawnAtIntervals(spawnTime));
    }

    IEnumerator SpawnAtIntervals(float secondsBetweenSpawns)
    {
        // Repeat until keepSpawning == false or this GameObject is disabled/destroyed.
        while (keepSpawning)
        {
            if(count <= 20)
            {
                SpawnStatue();
                yield return new WaitForSeconds(4);
            }
            else if(count <= 40)
            {
                SpawnStatue();
                yield return new WaitForSeconds(3);
            }
            else
            {
                SpawnStatue();
                yield return new WaitForSeconds(2);
            }    
        }
    }

    void SpawnStatue()
    {
        count++;
        Instantiate(statue, new Vector3(transform.position.x, Random.Range(-maxYpos, maxYpos), 0), Quaternion.identity);
    }
}

/*


    StartCoroutine(SpawnAtIntervals(spawnTime));
        

    IEnumerator SpawnAtIntervals(float secondsBetweenSpawns)
    {
        // Repeat until keepSpawning == false or this GameObject is disabled/destroyed.
        while (keepSpawning)
        {
            checkScore();
            // Put this coroutine to sleep until the next spawn time.
            yield return new WaitForSeconds(spawnTime);
            
            // Now it's time to spawn again.
            SpawnStatue();
        }
    }

    void checkScore ()
    {
        if(ScoreManager.instance.getInitialScore() == 2 || ScoreManager.instance.getInitialScore() == 4 || ScoreManager.instance.getInitialScore() == 6)
        {
            ScoreManager.instance.setInitialScore(600);
            spawnTime -= 1;
        }
    }



    void fastSpawning()
    {
        //newSpawnTime = false;
        CancelInvoke("SpawnStatue");
        spawnTime -= 0.5f;
        StartSpawningStatues();
        //Instantiate(statue, new Vector3(transform.position.x, Random.Range(-maxYpos, maxYpos), 0), Quaternion.identity);
    }


*/
