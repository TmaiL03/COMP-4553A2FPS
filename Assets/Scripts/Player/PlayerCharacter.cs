using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    
    [Header("External References")]
    public Health healthVal;
    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        // Retrieving the health GameObject and obtaining its value.
        GameObject healthGO = GameObject.Find("Health");
        healthVal = healthGO.GetComponent<Health>();

    }

    // Update is called once per frame
    void Update()
    {

        // If player health goes below 0, end game.
        if(healthVal.health <= 0) {
            
            DisplayGameOverScreen();
            
            // Releasing cursor after loss screen flashes up.
            Cursor.visible = true;
		    Cursor.lockState = CursorLockMode.None;

        }

    }

    // Applies damage to the player.
    public void Hurt(int damage) {

        // Changing value presented in health UI component.
        healthVal.health -= damage;
        Debug.Log("Damaged: " + damage + " Health: " + healthVal.health);

    }

    // Heals the player.
    public void Heal(int heal) {

        // Changing value presented in health UI component.
        healthVal.health += heal;
        Debug.Log("Healed: " + heal + " Health: " + healthVal.health);

    }

    // Displays game over screen.
    void DisplayGameOverScreen() {

        gameOverScreen.SetActive(true);
        Time.timeScale = 0;

    }
}
