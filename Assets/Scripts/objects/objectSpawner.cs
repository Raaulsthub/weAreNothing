using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private float spawningInterval;
    [SerializeField] private float spawnPosY;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float yRange;
  

    void Start()
    {
        StartCoroutine(spawnObject(spawningInterval, objectPrefab));
        spawnPos = GetComponent<Transform>();   
    }

    private IEnumerator spawnObject(float interval, GameObject spawnedObject)
    {   
        yield return new WaitForSeconds(interval);
        GameObject newObject = Instantiate(spawnedObject, new Vector3(spawnPos.position.x, Random.Range(spawnPosY, spawnPosY + yRange), 0), Quaternion.identity);
        StartCoroutine(spawnObject(interval, newObject));
    
    }
}
