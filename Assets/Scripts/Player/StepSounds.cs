using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSounds : MonoBehaviour
{

    public AudioClip[] stepSounds;
    public AudioSource audioSource;
    public float stepInterval = 0.5f;

    private CharacterController characterController;
    private float stepTimer;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        stepTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // If player is moving.
        if(characterController.isGrounded && characterController.velocity.magnitude > 0f) {

            stepTimer += Time.deltaTime;

            if(stepTimer >= stepInterval) {

                PlayStepSound();
                stepTimer = 0f;

            }

        } else {

            stepTimer = 0f;

        }
    }

    void PlayStepSound() {

        int clipLoc = Random.Range(0, stepSounds.Length);
        audioSource.PlayOneShot(stepSounds[clipLoc]);

    }

}
