using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{

    public const float baseSpeed = 3.0f;

    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    private bool _alive;

    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

    void Start() {

        _alive = true;

    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the enemy is currently alive.
        if(_alive) {    

            // Apply speed.
            transform.Translate(0, 0, speed * Time.deltaTime);
            
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if(Physics.SphereCast(ray, 0.75f, out hit)) {

                GameObject hitObject = hit.transform.gameObject;

                if(hitObject.GetComponent < PlayerCharacter>()) {

                    if(_fireball == null) {

                        _fireball = Instantiate(fireballPrefab) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward);
                        _fireball.transform.rotation = transform.rotation;


                    }

                } else if(hit.distance < obstacleRange) {

                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);

                }

            }

            // If this enemy strays beyond the confines of the map (for some reason), destroy the game object.
            if(Mathf.Abs(transform.position.x) > 25f || Mathf.Abs(transform.position.z) > 25f) {

                Destroy(this.gameObject);

            }

        }
    }

    // Setting liveliness status.
    public void SetAlive(bool alive) {

        _alive = alive;

    }

}