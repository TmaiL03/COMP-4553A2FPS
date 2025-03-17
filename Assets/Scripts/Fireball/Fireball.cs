using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    public float speed = 10.0f;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Translating the fireball's position.
        transform.Translate(0, 0, speed * Time.deltaTime);

        // Checking if the fireball goes beyond the bounds of the map.
        if(transform.position.x > Mathf.Abs(25f) || transform.position.z > Mathf.Abs(25f)) {

            Destroy(this.gameObject);

        }

    }

    // When a collision with a trigger is registered.
    void OnTriggerEnter(Collider other) {

        // Retrieving PlayerCharacter information from the collider when applicable.
        PlayerCharacter player = other.GetComponent<PlayerCharacter>();
        Debug.Log("Fireball collided with: " + other.gameObject.name);
        
        if(player != null) {

            // If colliding with a player, apply damage.
            player.Hurt(damage);

        }
        
        // Once handled, destroy this object.
        Destroy(this.gameObject);

    }
}
