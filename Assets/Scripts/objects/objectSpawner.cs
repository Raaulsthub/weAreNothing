using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private float spawningInterval;

    void Start()
    {
        StartCoroutine(spawnObject(spawningInterval, objectPrefab));
    }

    private IEnumerator spawnObject(float interval, GameObject spawnedObject)
    {   
        yield return new WaitForSeconds(interval);
        GameObject newObject = Instantiate(spawnedObject, new Vector3(100f, Random.Range(-20, 20f), 0), Quaternion.identity);
        StartCoroutine(spawnObject(interval, newObject));
    
    }
}
