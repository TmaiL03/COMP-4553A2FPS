using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{

    [Header("External References")]
    public Score scoreVal;
    public GameObject sparkEffect;

    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        // Retrieving camera.
        _camera = GetComponent<Camera>();   

        // Reference to Score GameObject.
        GameObject scoreGO = GameObject.Find("Score");
        scoreVal = scoreGO.GetComponent<Score>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // If mouse clicked, fire a RayCast.
        if(Input.GetMouseButtonDown(0)) {

            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            
            if(Physics.Raycast(ray, out hit)) {

                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();

                // If a hit is registered.
                if(target != null) {

                    // Incrementing score value and notifying target of contact.
                    scoreVal.score += 100;
                    Debug.Log("Target hit!" + " Score: " + scoreVal.score);
                    target.ReactToHit();

                } else {

                    StartCoroutine(SparksIndicator(hit.point, hit.normal));

                }

            }

        }
    }

    private IEnumerator SparksIndicator(Vector3 pos, Vector3 normal) {

        GameObject sparks = Instantiate(sparkEffect, pos, Quaternion.LookRotation(normal));

        yield return new WaitForSeconds(0.5f);

        Destroy(sparks);

    }
}
