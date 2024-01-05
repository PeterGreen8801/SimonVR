using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        playerInput.Clear();
        for (int i = 0; i < length; i++)
        {
            ColorEnum randomColor = (ColorEnum)Random.Range(0, 4); // Random color
            Debug.Log(randomColor);
            sequence.Add(randomColor);
            // Show visual/audio feedback for the color (light up button, play sound, etc.)
        }
    }

    public void ClearGame()
    {
        sequence.Clear();
        playerInput.Clear();
    }

    public void ClearSequence()
    {
        sequence.Clear();
    }

    public void ClearPlayerInput()
    {
        playerInput.Clear();
    }

    public void PlayGame()
    {
        //create isPlaying bool, set to true when game starts. When player messes up, set to false, will end game
        //while(isPlaying){}

        ColorEnum randomColor = (ColorEnum)Random.Range(0, 4); // Random color
        Debug.Log(randomColor);
        sequence.Add(randomColor);

        //End Game down here, update UI and show score, etc.
    }

    public void GetPlayerInput(int colorNumber)
    {
        ColorEnum playerColor = (ColorEnum)colorNumber;

        playerInput.Add(playerColor);
        Debug.Log("Color Added is: " + playerColor);
    }

    public void CheckPlayerInput()
    {
        Debug.Log(sequence);
        Debug.Log(playerInput);

        if (playerInput.SequenceEqual(sequence))
        {
            Debug.Log("True, it matches");
            //Can do something here if matches

        }
        else
        {
            Debug.Log("False");
            //Can do something here if it does not match, game ends.
        }

        //Will Clear the Player's Input each time the sequence is checked.
        ClearPlayerInput();

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

