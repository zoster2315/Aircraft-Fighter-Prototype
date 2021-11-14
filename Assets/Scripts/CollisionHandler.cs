using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem crashParticle;

    private void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }

    private void StartCrashSequence()
    {
        if (gameObject.CompareTag("Player"))
        {
            var controller = gameObject.GetComponent<PlayerController>();
            if (controller != null)
                controller.enabled = false;
            var animator = gameObject.GetComponentInParent<Animator>();
            if (animator != null)
                animator.enabled = false;
            if (crashParticle != null)
                crashParticle.Play();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            Invoke("ReloadScene", loadDelay);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
