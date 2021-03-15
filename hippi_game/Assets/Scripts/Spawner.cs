using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private bool isStart;
    public float spawnSpeed;
    private float spawnSpeedStart; 
    private Vector3 spawnerPoint;
    private int counter;

    public GameObject spawnerObject;
    public GameObject leafObject;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        spawnerPoint = this.gameObject.transform.position;
        spawnSpeedStart = spawnSpeed;
        isStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            spawnSpeed -= 1*Time.deltaTime;
            if (spawnSpeed <= 0)
            {
                if (counter < 5)
                {
                    int rand = (int)UnityEngine.Random.Range(0.0f, 4.0f);
                    if (rand == 1)
                    {
                        Vector3 target = spawnerPoint + new Vector3(0, 0, -2);
                        Instantiate(spawnerObject, target, transform.rotation);
                        counter++;
                    }
                    if (rand == 2)
                    {
                        Vector3 target = spawnerPoint;
                        Instantiate(spawnerObject, target, transform.rotation);
                        counter++;
                    }
                    if (rand == 3)
                    {
                        Vector3 target = spawnerPoint + new Vector3(0, 0, 2);
                        Instantiate(spawnerObject, target, transform.rotation);
                        counter++;
                    }
                }
                else
                {
                    int rand = (int)UnityEngine.Random.Range(0.0f, 4.0f);
                    if (rand == 1)
                    {
                        Vector3 target = spawnerPoint + new Vector3(0, 0, -2);
                        Instantiate(leafObject, target, transform.rotation);
                        counter++;
                    }
                    if (rand == 2)
                    {
                        Vector3 target = spawnerPoint;
                        Instantiate(leafObject, target, transform.rotation);
                        counter++;
                    }
                    if (rand == 3)
                    {
                        Vector3 target = spawnerPoint + new Vector3(0, 0, 2);
                        Instantiate(leafObject, target, transform.rotation);
                        counter++;
                    }
                    counter = 0;
                }
                spawnSpeed = spawnSpeedStart;
            }
        }
    }

    public void SetStart()
    {
        isStart = true;
    }
    public void SetDown()
    {
        isStart = false;
    }
}
