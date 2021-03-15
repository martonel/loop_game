using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    private bool isMove;
    private Vector3 target;
    public int number;
    public Animator anim;
    private bool isStart;
    public Spawner spanwner;
    public TreeMove treeMove;
    public Animator ButtonAnim;
    // Start is called before the first frame update
    void Start()
    {
        isStart = false;
        isMove = true;
        number = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            if (isMove)
            {
                if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && number < 1)
                {
                    target = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z + 2);
                    isMove = false;
                    number++;
                }
                if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && number > -1)
                {
                    target = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z - 2);
                    isMove = false;
                    number--;
                }
            }
            else
            {
                this.gameObject.transform.position = Vector3.MoveTowards(this.transform.position, target, Time.deltaTime * speed);
                if (this.gameObject.transform.position == target)
                {
                    isMove = true;
                }
            }
        }
    }



    public void SetStart()
    {
        anim.SetBool("isRunning", true);
        isStart = true;
    }
    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Spawned")
        {
            anim.SetBool("isRunning", false); 
            anim.SetBool("isEnd",true);
            Destroy(other.gameObject);
            GameObject[] spawnOjbects = GameObject.FindGameObjectsWithTag("Spawned");
            foreach (var item in spawnOjbects)
            {
                item.GetComponent<ConstantForce>().relativeForce = new Vector3(0, 0, 0);
            }
            StartCoroutine(Wait());
            spanwner.SetDown();
            treeMove.SetDown();
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.7f); 
        GameObject[] spawnOjbects = GameObject.FindGameObjectsWithTag("Spawned");
        foreach (var item in spawnOjbects)
        {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        spawnOjbects = GameObject.FindGameObjectsWithTag("Leaf");
        foreach (var item in spawnOjbects)
        {
            item.GetComponent<ConstantForce>().relativeForce = new Vector3(0, 0, 0);
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        ButtonAnim.Play("setEnd");
    }
}
