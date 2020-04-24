using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float rateOfSpawn;
    public GameObject[] enemies;
    public int numberOfWaves;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemy", rateOfSpawn);
    }

    // Update is called once per frame
    void SpawnEnemy()
    {
        for(int i = 0; i < numberOfWaves; i++)
        {
            Instantiate(enemies[(int)Random.Range(0, enemies.Length)], new Vector3(Random.Range(-8.5f, 8.5f), transform.position.y, 0), Quaternion.identity);
        }
        
    }
}
