using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    //Variables here!
    [SerializeField] private string playerName = "Nameless Fella";
    [SerializeField] private int vitality;
    [SerializeField] private int physicalInstrument;
    [SerializeField] private int painThreshold;
    [SerializeField] private int endurance;
    [SerializeField] public int experience;
    [SerializeField] public int volitionPlayer;

    [SerializeField] private bool winCondition;

    //Then Methods!


    // Start is called before the first frame update
    void Start()
    {
        vitality = 100;
        physicalInstrument = 10;
        painThreshold = 10;
        endurance = 1;
        experience = 0;
        volitionPlayer = 1;

        winCondition = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (volitionPlayer == 5)
        {
            winCondition = true;
        }

        //Setting my win condition from the get-go
        if (winCondition == true)
        {

        //Runs the YouWin method, AND disables the script as a component. Basically disables the script.
            YouWin();
            enabled = false;
        }
        //Since winCondition will only == true once volition == 5, the script will run this every update until then.
        else
        {
            //If the player presses the spacebar...
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Do a thing!
                Debug.Log("You just hit the spacebar. ");
                //volitionPlayer++ <--- this will add exactly one to the volition variable. Useful for XP Threshold.
                volitionPlayer++;
            }

        }

    }

    void YouWin()
    {
        Debug.Log("You Win. ");
    }
}
