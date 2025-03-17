using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{

    private GameObject sceneController;
    private SceneController script;

    // Start is called before the first frame update
    void Start()
    {
        sceneController = GameObject.Find("EnemySpawner");
        script = sceneController.GetComponent<SceneController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Specifying the response to being hit.
    public void ReactToHit() {

        StartCoroutine(Die());

    }

    // Handling death.
    private IEnumerator Die() {

        // Removes this enemy from the _enemies list in SceneController.cs
        script._enemies.Remove(this.gameObject);

        yield return new WaitForSeconds(0.0f);

        Destroy(this.gameObject);

    }

}
