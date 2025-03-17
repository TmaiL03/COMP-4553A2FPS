using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    [Header("Dynamic")]
    public int score = 0;
    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        // Retrieving Text component.
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame.
    void Update()
    {
        // Updating UI score.
        scoreText.text = "Score: " + score.ToString("#,0");
    }
}
