using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMove : MonoBehaviour
{
    private bool isStart;

    public GameObject tree;
    public float spawnSpeed;
    private float spawnSpeedStart;
    // Start is called before the first frame update
    void Start()
    {
        spawnSpeedStart = spawnSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            spawnSpeed -= 1 * Time.deltaTime;
            if (spawnSpeed <= 0)
            {
                float rand = (int)UnityEngine.Random.Range(8.0f, 10.0f);
                GameObject bigTree = Instantiate(tree, this.gameObject.transform.position, transform.rotation);
                bigTree.GetComponent<ConstantForce>().relativeForce = new Vector3(-1*rand, 0, 0);
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
