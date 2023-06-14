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
    [SerializeField] private int experience;
    [SerializeField] private int volition;

    //Then Methods!


    // Start is called before the first frame update
    void Start()
    {
        vitality = 100;
        physicalInstrument = 10;
        painThreshold = 10;
        endurance = 1;
        experience = 0;
        volition = 1;
    }

    // Update is called once per frame
    void Update()
    {
      // if the player presses the spacebar
      if (Input.GetKeyDown(KeyCode.Space))
        {
            //...do a thing!
            Debug.Log("You know this working now dummy. ");
            // ++ adds one to the variable.
            volition++;
        }

      if(volition == 5)
        {
            Debug.Log("You Win");
        }
    }
}
