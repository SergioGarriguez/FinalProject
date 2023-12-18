using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingManager : MonoBehaviour
{

    public GameObject fishPrefab;
    public int numFish;
    public GameObject[] allFish;
    public float neighbourDistance, maxSpeed, minSpeed,rotationSpeed;


    // Start is called before the first frame update
    void Start()
    {
        allFish = new GameObject[numFish];
        for (int i = 0; i < numFish; ++i)
        {
            Vector3 randomVector = new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f));
            Vector3 pos = this.transform.position + randomVector; // random position
            Vector3 randomize = new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f)); // random vector direction
            allFish[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.LookRotation(randomize));
            allFish[i].GetComponent<Flocking>().myManager = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
