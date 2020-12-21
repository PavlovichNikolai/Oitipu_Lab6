using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    private float randY, randX;

    Vector2 whereToSpawn;
    [SerializeField]
    private float spawnRate = 2f;
    private float nextSpawn = 0.0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randY = Random.Range(20f, 70.57f);
            randX = Random.Range(-2.5f, 2.5f);
            whereToSpawn = new Vector2(randX, randY);

            Instantiate(obj, whereToSpawn, Quaternion.identity);
        }
    }
}
