using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonManager : MonoBehaviour
{
    // Enum representing colors
    public enum ColorEnum
    {
        Green,
        Red,
        Yellow,
        Blue
    }

    private List<ColorEnum> sequence = new List<ColorEnum>();
    private List<ColorEnum> playerInput = new List<ColorEnum>();

    // Method to generate a random sequence
    public void GenerateSequence(int length)
    {
        sequence.Clear();
        for (int i = 0; i < length; i++)
        {
            ColorEnum randomColor = (ColorEnum)Random.Range(0, 4); // Random color
            Debug.Log(randomColor);
            sequence.Add(randomColor);
            // Show visual/audio feedback for the color (light up button, play sound, etc.)
        }
    }

    // Method to check player input against the sequence
    /*
    public bool CheckPlayerInput()
    {
        // Check if player input matches the generated sequence
        // Compare playerInput list with sequence list
        // Return true if match, false otherwise
    }
    */

    // Other methods for handling player input, showing sequence, etc.
}

