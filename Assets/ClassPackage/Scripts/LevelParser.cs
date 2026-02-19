using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.InputSystem.Controls;

/*
 * This script is responsible for reading a level layout from a text file and constructing the level
 * in a Unity scene by instantiating block GameObjects. The level file should be placed in the
 * Resources folder, and each line in the file represents a row of blocks.
 *
 * WHAT YOU NEED TO DO:
 * 1. In the for loop that iterates over each character (i.e. letter) in the current row, determine
 *    which type of block to create based on the letter (e.g., use 'R' for rock, 'B' for brick, etc.).
 *
 * 2. Instantiate the correct prefab (rockPrefab, brickPrefab, questionBoxPrefab, stonePrefab) corresponding
 *    to the letter.
 *
 * 3. Calculate the position for the new block GameObject using the current row and column index.
 *    - You will likely need to maintain a separate column counter as you iterate through the characters.
 *
 * 4. Set the instantiated block’s parent to 'environmentRoot' to keep the hierarchy organized.
 *
 * ADDITIONAL NOTES:
 * - The level reloads when the player presses the 'R' key, which clears all blocks under levelRoot
 *   and then re-parses the level file.
 * - Ensure that the level file's name (without the extension) matches the 'filename' variable.
 *
 * By completing these TODOs, you will enable the level parser to dynamically create and position
 * the blocks based on the level file data.
 */


public class LevelParser : MonoBehaviour
{
    public TextAsset levelFile;
    public Transform levelRoot;

    [Header("Prefabs")]
    public GameObject rockPrefab;
    public GameObject brickPrefab;
    public GameObject questionBoxPrefab;
    public GameObject dirtPrefab;
    public GameObject environmentRoot;

    public TextMeshProUGUI countTime;
    private float timeLeft = 300;
    private float coinTime = 10;
    private bool coinAnimate = false;


    void Start()
    {
        LoadLevel();
        
    }

    void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
            ReloadLevel();

        timeLeft -= Time.deltaTime;
        string count = $"Time{System.Convert.ToInt16(timeLeft)}";
        countTime.text = count;

        if (coinAnimate)
        {
            coinTime -= Time.deltaTime;
        }
         
    }

    void LoadLevel()
    {
        // Push lines onto a stack so we can pop bottom-up rows. This is easy to reason
        //  about, but an index-based loop over the string array is faster.
        Stack<string> levelRows = new Stack<string>();
        levelRoot.position = new Vector3(0f, 0f, 0f);

        foreach (string line in levelFile.text.Split('\n'))
            levelRows.Push(line);

        int row = 0;
        while (levelRows.Count > 0)
        {
            string rowString = levelRows.Pop();
            char[] rowChars = rowString.ToCharArray();
            
            for (var columnIndex = 0; columnIndex < rowChars.Length; columnIndex++)
            {
                var currentChar = rowChars[columnIndex];

                // Todo - Instantiate a new GameObject that matches the type specified by the character
                // Todo - Position the new GameObject at the appropriate location by using row and column
                // Todo - Parent the new GameObject under levelRoot

                
                if (currentChar == 'x')
                {
                    Vector3 newPosition = new Vector3(columnIndex + 0.5f, row + 0.5f, 0);
                    Transform dirtInstance = Instantiate(dirtPrefab).transform;
                    dirtInstance.position = newPosition; 
                    dirtInstance.transform.parent = environmentRoot.transform;
                }

                if (currentChar == 's')
                {
                    Vector3 newPosition = new Vector3(columnIndex + 0.5f, row + 0.5f, 0);
                    Transform rockInstance = Instantiate(rockPrefab).transform;
                    rockInstance.position = newPosition;
                    rockInstance.transform.parent = environmentRoot.transform;
                }

                if (currentChar == 'b')
                {
                    Vector3 newPosition = new Vector3(columnIndex + 0.5f, row + 0.5f, 0);
                    Transform brickInstance = Instantiate(brickPrefab).transform;
                    brickInstance.position = newPosition;
                    brickInstance.transform.parent = environmentRoot.transform;
                }

                if (currentChar == '?')
                {
                    Vector3 newPosition = new Vector3(columnIndex + 0.5f, row + 0.5f, 0);
                    GameObject questionBoxInstance = Instantiate(questionBoxPrefab);
                    questionBoxInstance.transform.position = newPosition;
                    questionBoxInstance.transform.parent = environmentRoot.transform;
                }

            }

            row++;
        }
    }

    // --------------------------------------------------------------------------
    void ReloadLevel()
    {
        foreach (Transform child in levelRoot)
           Destroy(child.gameObject);
        
        LoadLevel();
    }

    public void DestroyBrick(Transform brickInstance)
    {
        Destroy(brickInstance.gameObject);
    }

    // public void CoinAnimation(Transform questionBoxInstance, GameObject coin)
    // {
    //     Vector3 boxPosition = transform.position;
    //     // Debug.Log(boxPosition);
    //     GameObject coinInstance = Instantiate(coin);
    //     coinInstance.transform.position = new Vector3(boxPosition.x, boxPosition.y, -0.1f);

    //     float degrees = 30;
        
    //     coinTime = 0;
    //     coinAnimate = true;
        
    //     // while (coinAnimate == true)
    //     // {
    //     //     coinInstance.transform.Rotate(new Vector3(0f, 0f, degrees * Time.deltaTime));
    //     //     Debug.Log(coinTime);
    //     // }
    
    //     // Destroy(coinInstance);
    //     coinAnimate = false;

    // }

}



