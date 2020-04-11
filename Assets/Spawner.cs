using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    void Update()
    {       
        if (Random.Range(0, 100) < 5)
        {
            GameObject asteroid = Pool.singleton.Get("asteroid");
            if (asteroid != null)
            {
                asteroid.SetActive(true);
                asteroid.transform.position = new Vector3(Random.Range(-5, 5), Random.Range(0, 10), 0);               
            }
        }           
    }
}
