using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SimonBlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject.name + " Hit " + collision.gameObject.name);
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + " Hit " + other.gameObject.name);
    }
}
