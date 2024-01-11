using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SimonBlock : MonoBehaviour
{
    //To track which block is which color
    //0 = Green, 1 = Red, 2 = Yellow, 3 = Blue
    public int colorNumber;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + " Hit " + other.gameObject.name);

        //Send data to sequence to be compared

        //Trying singleton pattern instead of direct object reference from scene
        SimonManager.Instance.GetPlayerInput(colorNumber);

    }

    public int GetColorNumber()
    {
        return colorNumber;
    }
}
