using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NumberDice : MonoBehaviour
{

    // Array of dice sides sprites to load from Resources folder
    public Sprite[] diceSides;

    // Reference to sprite renderer to change sprites
    private Image rend;

    // Use this for initialization
    private void Start()
    {

        // Assign Renderer component
        rend = GetComponent<Image>();

        // Load dice sides sprites to array from DiceSides subfolder of Resources folder
        //diceSides = Resources.LoadAll<Sprite>("DiceSides/");
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
        int finalSide = 0;
        //Debug.Log("Number Dice Rolled!!");
        // Loop to switch dice sides ramdomly
        // before final side appears. 20 itterations here.
        for (int i = 0; i <= 20; i++)
        {
            // Pick up random value from 0 to 5 (All inclusive)
            randomDiceSide = Random.Range(0, 6);

            //Debug.Log("Hey!!!");
            // Set sprite to upper face of dice from array according to random value
            rend.sprite = diceSides[randomDiceSide];

            // Pause before next itteration
            yield return new WaitForSeconds(0.05f);
        }

        // Assigning final side so you can use this value later in your game
        // for player movement for example
        finalSide = randomDiceSide + 1;

        // Show final dice value in Console
        //Debug.Log(finalSide);

        GameController.Instance.rollDiceCount++;
        //Debug.Log("Selecterd Level: " + AppManager.Instance.SelectedLevel + " Roll Dice Count: " + GameController.Instance.rollDiceCount);

        if (AppManager.Instance.SelectedLevel == ELevels.BEG && GameController.Instance.rollDiceCount %4 ==0)
        {
            GameController.Instance.SpawnBlock.Invoke();
        }

        else if (AppManager.Instance.SelectedLevel == ELevels.INTER && GameController.Instance.rollDiceCount % 3 == 0)
        {

            GameController.Instance.SpawnBlock.Invoke();
        }
        else if (AppManager.Instance.SelectedLevel == ELevels.PRO && GameController.Instance.rollDiceCount % 2 == 0)
        {
            //Debug.Log("Selecterd Level: "+  AppManager.Instance.SelectedLevel);
            GameController.Instance.SpawnBlock.Invoke();
        }

        //if (GameController.Instance.rollDiceCount % 3 == 0)
        //{
        //    //GameController.Instance.rollDiceCount = 0;
        //    GameController.Instance.SpawnBlock.Invoke();
        //}
       // Debug.Log("Dice roll count: " + GameController.Instance.rollDiceCount);

        GameController.Instance.diceCount = randomDiceSide + 1;

        GameController.Instance.breakCount = 0;

        GameController.Instance.animRef.SetActive(false);

    }


}

