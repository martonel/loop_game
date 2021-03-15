using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    public GameObject[] anims;
    public Animator anim;

    public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        anims = GameObject.FindGameObjectsWithTag("halu");
        anim = anims[0].GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
            anim.Play("halu");
        }
    }
}
