using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour
{

    public int healing = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {

        // Retrieving PlayerCharacter information from the collider when applicable.
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        Debug.Log("Med Kit collided with: " + other.gameObject.name);

        if(player != null) {

            // If colliding with a player, heal then remove med kit.
            player.Heal(healing);
            Destroy(this.gameObject);

        }

    }

}
