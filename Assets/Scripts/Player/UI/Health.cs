using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    [Header("Dynamic")]
    public int health = 10;
    private Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        // Retrieving Text component.
        healthText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        // Updating UI health.
        healthText.text = "Health: " + health.ToString("#,0");

    }
}
