using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayToRespawn = 1f;

    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;
    int currentLevelIndex;
    bool isTransitioning = false;


    public void Start()
    {
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning == true) { return; }

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("friendly");
                // do staff
                break;

            case "Finish":
                Debug.Log("finish");
                StartFinishSequence();
                break;

            case "Fuel":
                Debug.Log("fuel");
                // do staff
                break;

            default:
                Debug.Log("blow up!!");
                StartCrashSequence();
                break;
        }
    }


    private void StartFinishSequence()
    {
        GetComponent<Movement>().enabled = false;
        successParticles.Play();
        Invoke("LoadNextLevel", delayToRespawn);
    }

    void StartCrashSequence()
    {
        GetComponent<Movement>().enabled = false;
        crashParticles.Play();
        Invoke("Respawn", delayToRespawn);
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene((currentLevelIndex + 1) % SceneManager.sceneCountInBuildSettings);
    }

    private void Respawn()
    {
        SceneManager.LoadScene(currentLevelIndex);
    }
}
