using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneScriptGame : MonoBehaviour
{
    //Player Variables
    [SerializeField] private int playerHealth;
    [SerializeField] private int playerAttack;
    [SerializeField] private int playerDefence;

    [SerializeField] private int experience;
    [SerializeField] private int level;

    //Enemy Variables
    [SerializeField] private int enemyHealth;
    [SerializeField] private int enemyAttack;
    [SerializeField] private int enemyDefence;

    //Just some text related boolians so we don't get repeat messages while debugging. Just cannot figure out why the Debug won't run??
    private bool levelOneMessageOnce = false;
    private bool levelTwoMessageOnce = false;
    private bool levelThreeMessageOnce = false;
    private bool levelFourMessageOnce = false;
    private bool levelFiveMessageOnce = false;

    //Extra fun
    [SerializeField] private int enemiesSlain;
    private int experienceGained;
    private int restBonusHealth;

    public AudioSource source;
    public AudioClip damage;
    public AudioClip playerDeath;
    public AudioClip enemyDeath;


    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100;
        playerAttack = 10;
        playerDefence = 10;

        experience = 0;
        level = 0;

        enemyHealth = 50;
        enemyAttack = Random.Range(5, 10);
        enemyDefence = Random.Range(5, 10);

        enemiesSlain = 0;

        Debug.Log("Press spacebar to fight. ");
    }

    // Update is called once per frame
    void Update()
    {
        if(level == 5)
        {
            WinCondition();
        }

        //Level System
        if(experience > 10)
        {
            level = 1;
            //playerHealth = 100;
            if(levelOneMessageOnce = false)
            {
                Debug.Log("You've just reached level One. ");
                levelOneMessageOnce = true;
            }
        }
        if(experience > 25)
        {
            level = 2;
            //playerHealth = 100;
            if(levelTwoMessageOnce = false)
            {
                Debug.Log("You've just reached level Two. ");
                levelTwoMessageOnce = true;
            }
        }
        if(experience > 60)
        {
            level = 3;
            //playerHealth = 100;
            if (levelThreeMessageOnce = false)
            {
                Debug.Log("You've just reached level Three. ");
                levelThreeMessageOnce = true;
            }
        }
        if(experience > 95)
        {
            level = 4;
            //playerHealth = 100;
            if (levelFourMessageOnce = false)
            {
                Debug.Log("You've just reached level Four. ");
                levelFourMessageOnce= true;
            }
        }
        if(experience > 125)
        {
            level = 5;
            //playerHealth = 100;
            if (levelFiveMessageOnce = false)
            {
                Debug.Log("You've just reached level Five, and you know what that means. ");
                levelFiveMessageOnce = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //If spacebar is pressed initiate combat.
            Debug.Log("You've entered into a violent meelee. ");
            Combat();
        }
    }

    //void LevelUpSystem()

    void Combat()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            source.PlayOneShot(damage);


            //Rolling Player Stats
            playerAttack = playerAttack + (level + Random.Range(1, 15));
            playerDefence = playerDefence + (level + Random.Range(1, 15));

            //Level Curve
            if (level > 0) ;
            {
                //enemyHealth = enemyHealth + (level + Random.Range(1, 50));
                enemyAttack = enemyAttack + (level * Random.Range(1, 7));
                enemyDefence = enemyDefence + (level + Random.Range(1, 5));
            }

            //Dealing Damage
            enemyHealth = enemyHealth - playerAttack;
            if(playerAttack > 30)
            {
                Debug.Log("You dealt a critical hit! ");
            }
            Debug.Log("You dealt " + playerAttack + " damage! Your enemy has " + enemyHealth + " health left. ");

            //Taking Damage
            playerHealth = playerHealth - enemyAttack;
            Debug.Log("You took " + enemyAttack + " damage! You have " + playerHealth + " health left. ");

            //Reverting Stats For Logic
            playerAttack = 10;
            playerDefence = 10;

            enemyAttack = Random.Range(5, 10);
            enemyDefence = Random.Range(5, 10);
            
        }

        if(playerHealth <= 0)
        {
            source.PlayOneShot(playerDeath);
            Debug.Log("You have died. ");
            LoseCondition();
        }

        if (enemyHealth <=0)
        {
            source.PlayOneShot(enemyDeath);
            enemiesSlain++;
            Debug.Log("You've defeated the enemy. You slump to the ground for a rest. ");
            experienceGained = (level * level) + Random.Range(3, 10);
            experience = experience + experienceGained;
            Debug.Log("You've gathered " + experienceGained + " experience. ");

            //Give Player Health back AND cap it at 100.
            restBonusHealth = Random.Range(20, 50);
            playerHealth = playerHealth + restBonusHealth;
            Debug.Log("You recovered your breath and stemmed the bleeding. For now. You regained " + restBonusHealth + " health. ");

            //Just going to max out health for now..
            //playerHealth = 100;
            if (playerHealth > 100)
            {
                playerHealth = 100;
            }
            Debug.Log("Your body has recovered and you assessed yourself to have " + playerHealth + " health. ");


            //Revert Enemy Stats for next fight
            enemyHealth = 50;
            enemyAttack = 7;
            enemyDefence = 7;

            //Rerun Update Method
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Press spacebar to pick yourself up off the ground and resume the fight. ");
                Update();
            }
        }

    }

    void WinCondition()
    {
            Debug.Log("You win. ");
            enabled = false;
    }

    void LoseCondition()
    {
        //Just going to disable the game lmao.
        enabled = false;
    }
}

