using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool playing;
    public int maxSparks;
    public static GameObject[] sparks;
    public GameObject spark;
    public Vector2 spawnArea;
    public float frequency;
    float waitReal;
    // Start is called before the first frame update
    void Awake()
    {
        sparks = new GameObject[maxSparks];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!playing)
            return;

        if(waitReal <= 0)
        {
            waitReal = frequency;
            Vector3 spawnPos = new Vector3(Random.Range(-spawnArea.x, spawnArea.x), 0 , Random.Range(-spawnArea.y, spawnArea.y));
            GameObject newSpark = Instantiate(spark, spawnPos, transform.rotation);
            for (int i = 0; i < maxSparks; i++)
            {
                if (sparks[i] == null)
                {
                    sparks[i] = newSpark;
                    i = maxSparks;
                }
                else if (i == (maxSparks - 1))
                    Destroy(newSpark);
            }
        }
        else
            waitReal -= Time.deltaTime;
    }
}
