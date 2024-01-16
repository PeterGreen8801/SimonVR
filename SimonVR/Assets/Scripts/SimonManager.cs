using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class SimonManager : MonoBehaviour
{

    public static SimonManager Instance;

    public SimonBlock simonBlock1;
    public SimonBlock simonBlock2;
    public SimonBlock simonBlock3;
    public SimonBlock simonBlock4;

    public bool isPlaying = false;

    public float timeBetweenBlocks = 2f;

    public TextMeshProUGUI currentScoreText;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

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

    // Method to generate a random sequence of 4 blocks at a time
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

    public void EndRound()
    {
        isPlaying = false;
    }

    public void PlayGame()
    {
        //create isPlaying bool, set to true when game starts. When player messes up, set to false, will end game
        //while(isPlaying){}

        //isPlaying = true;

        /*
        while (isPlaying)
        {
            ColorEnum randomColor = (ColorEnum)Random.Range(0, 4); // Random color
            Debug.Log(randomColor);
            sequence.Add(randomColor);
        }
        */

        //End Game down here, update UI and show score, etc.

        AddNewBlockToSequence();

    }


    // Method to generate a random sequence 1 block at a time
    public void AddNewBlockToSequence()
    {
        ColorEnum randomColor = (ColorEnum)Random.Range(0, 4); // Random color
        Debug.Log(randomColor);
        //Repeat and light up previous sequence
        /*
        if (sequence.Count > 0)
        {
            repeatSequence();
        }
        */
        if (randomColor.ToString() == "Green")
        {
            Debug.Log("WORKS gre" + randomColor);
            //Make glow and play sound for a sec
            simonBlock1.ShowGlow();
        }
        if (randomColor.ToString() == "Red")
        {
            Debug.Log("WORKS red" + randomColor);
            simonBlock2.ShowGlow();
        }
        if (randomColor.ToString() == "Yellow")
        {
            Debug.Log("WORKS yel" + randomColor);
            simonBlock3.ShowGlow();
        }
        if (randomColor.ToString() == "Blue")
        {
            Debug.Log("WORKS blu" + randomColor);
            simonBlock4.ShowGlow();
        }
        sequence.Add(randomColor);
    }

    public void repeatSequence()
    {
        StartCoroutine(RepeatSequenceWithDelay());
    }

    IEnumerator RepeatSequenceWithDelay()
    {
        // Create a copy of the sequence to avoid modifying it while iterating
        List<ColorEnum> sequenceCopy = new List<ColorEnum>(sequence);

        foreach (var color in sequenceCopy)
        {
            ShowBlock(color);
            yield return new WaitForSeconds(timeBetweenBlocks);
        }

        // You might want to add an additional delay here before clearing the sequence
        // yield return new WaitForSeconds(timeBeforeClearing);

        sequenceCopy.Clear();
        AddNewBlockToSequence();
    }

    void ShowBlock(ColorEnum color)
    {
        switch (color)
        {
            case ColorEnum.Green:
                simonBlock1.ShowGlow();
                break;
            case ColorEnum.Red:
                simonBlock2.ShowGlow();
                break;
            case ColorEnum.Yellow:
                simonBlock3.ShowGlow();
                break;
            case ColorEnum.Blue:
                simonBlock4.ShowGlow();
                break;
        }
    }

    public void GetPlayerInput(int colorNumber)
    {
        ColorEnum playerColor = (ColorEnum)colorNumber;

        playerInput.Add(playerColor);
        Debug.Log("Color Added is: " + playerColor);

        //call this at the very end of the whole sequence
        if (playerInput.Count == sequence.Count)
        {
            CheckPlayerInput();
        }

    }


    public void CheckPlayerInput()
    {
        Debug.Log(sequence);
        Debug.Log(playerInput);

        if (playerInput.SequenceEqual(sequence))
        {
            Debug.Log("True, it matches");
            //Can do something here if matches, UPDATE UI.
            currentScoreText.text = "Your Score: " + sequence.Count.ToString();
            repeatSequence();
            //AddNewBlockToSequence();
        }
        else
        {
            Debug.Log("False");
            //Can do something here if it does not match, GAME ENDS.
        }

        //Will Clear the Player's Input each time the sequence is checked.
        ClearPlayerInput();

    }

}

