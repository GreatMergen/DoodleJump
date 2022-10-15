using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject platform;
    [SerializeField] GameObject platformSpawnTrigger;
    [SerializeField] float y;
    [SerializeField] float x;
    [SerializeField]int spawnCount;

    public static PlatformSpawner Instance;


    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }


        PlatformSpawn();
    }

    public void PlatformSpawn()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(platform, new Vector3(Random.Range(-x, x), y), Quaternion.identity);
            y += 3.2f;

            if(i == spawnCount - 4)
            {
                Instantiate(platformSpawnTrigger, new Vector3(0, y), Quaternion.identity);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
