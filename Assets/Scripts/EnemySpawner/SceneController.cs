using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int _maxEnemies = 10;
    public List<GameObject> _enemies = new List<GameObject> {};
    private GameObject _enemy;

    public GameObject youWinScreen;

    // Start is called before the first frame update
    void Start()
    {
        // Iterately spawn enemy GameObjects.
        for(int i = 0; i < _maxEnemies; i++) {

            // Instantiate an enemy at a random position with a random rotation.
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.transform.position = new Vector3(Random.Range(-23f, 23f), 2f, Random.Range(-23f, 23f));
            float angle = Random.Range(0, 360);
            _enemy.transform.Rotate(0, angle, 0);

            // Append the enemy instance to the list.
            _enemies.Add(_enemy);

        }

    }

    // Update is called once per frame
    void Update()
    {

        // If there are 0 enemies remaining, display the "You Win" screen.
        if(_enemies.Count == 0) {

            DisplayYouWinScreen();
            
            // Releasing cursor after win screen flashes up.
            Cursor.visible = true;
		    Cursor.lockState = CursorLockMode.None;
            
        }

    }

    // Displays the "You Win" screen.
    void DisplayYouWinScreen() {

        youWinScreen.SetActive(true);
        Time.timeScale = 0;

    }
}
