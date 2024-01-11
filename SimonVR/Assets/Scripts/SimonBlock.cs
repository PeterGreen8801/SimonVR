using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SimonBlock : MonoBehaviour
{
    public Material originalMaterial; // The cube's original material
    public Material glowMaterial; // The material for the glow effect
    public float glowDuration = 1.0f; // Duration for the glow effect
    public Renderer simonBlockRenderer; // Reference to the cube's renderer


    //To track which block is which color
    //0 = Green, 1 = Red, 2 = Yellow, 3 = Blue
    public int colorNumber;


    // Start is called before the first frame update
    void Start()
    {
        // Get the cube's renderer component
        simonBlockRenderer = GetComponent<Renderer>();

        // Store the original material of the cube
        originalMaterial = simonBlockRenderer.material;
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

    public void ShowGlow()
    {
        // Change the cube's color to the glow color temporarily
        simonBlockRenderer.material = glowMaterial;

        // Wait for a short duration to display the glow effect
        StartCoroutine(ResetColorAfterDelay(glowDuration));
    }

    IEnumerator ResetColorAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Reset the cube's color back to its original color after the delay
        simonBlockRenderer.material = originalMaterial;
    }

    public int GetColorNumber()
    {
        return colorNumber;
    }
}
