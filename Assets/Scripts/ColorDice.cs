using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ColorDice : MonoBehaviour
{

    // Array of dice sides sprites to load from Resources folder
    //public GameObject[] diceSides;
     public Sprite[] diceSides;

    // Reference to sprite renderer to change sprites
     private Image diceImg;
    //private GameObject diceImg;

    // Use this for initialization
    private void Start()
    {

        // Assign Renderer component
        diceImg = GetComponent<Image>();

        // Load dice sides sprites to array from DiceSides subfolder of Resources folder
        //diceSides = Resources.LoadAll<Sprite>("DiceColour/");
    }

    // If you left click over the dice then RollTheDice coroutine is started
    public void OnMouseDown()
    {
        StartCoroutine("RollTheDice");
    }

    // Coroutine that rolls the dice
    public IEnumerator RollTheDice()
    {
        // Variable to contain random dice side number.
        // It needs to be assigned. Let it be 0 initially
        SoundManager.Instance.PlaySfxOneShot(EAudioSource.AUDIO_SOURCE_SFX, EGameSfx.SFX_CLICK);
        int randomDiceSide = 0;


    // Final side or value that dice reads in the end of coroutine
    //int finalSide = 0;
    //Debug.Log("Color Dice Rolled!!");
    // Loop to switch dice sides ramdomly
    // before final side appears. 20 itterations here.
    x: for (int i = 0; i <= 20; i++)
        {
            // Pick up random value from 0 to 5 (All inclusive)
            randomDiceSide = Random.Range(0, 6);

            //Debug.Log("Hey!!!");
            // Set sprite to upper face of dice from array according to random value
            diceImg.sprite = diceSides[randomDiceSide];

            // Pause before next itteration
            yield return new WaitForSeconds(0.05f);
        }



        //check list if dice color is on the board

        bool Cell_check = IsValidDiceColor(randomDiceSide);
        Debug.Log("color Exists: "+Cell_check);
        if (Cell_check == false)
        {
            goto x;
        }



        // Debug.Log("SUCCESS");
        GameController.Instance.diceRollColorTag = (EDiceTag)randomDiceSide;

        // Assigning final side so you can use this value later in your game
        // for player movement for example
        //finalSide = randomDiceSide + 1;

        // Show final dice value in Console
       // Debug.Log("Colour Dice: " + (EDiceTag)randomDiceSide);



    }

    bool IsValidDiceColor(int col)
    {
        GameObject obj = GameController.Instance.list.FirstOrDefault(x => x.GetComponent<PointerTester>().Tag.Equals((EDiceTag)col));
        //Debug.Log("Test=> " + obj == null +" *** "+obj != null);
        return (obj != null ? true : false);
    }

}
