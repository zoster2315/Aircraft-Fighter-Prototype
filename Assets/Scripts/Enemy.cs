using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject crashFX;
    [SerializeField] Transform parent;
    [SerializeField] int score;
    [SerializeField] int healthPoints;
    [SerializeField] ParticleSystem hitParticle;

    ScoreBoard scoreBoard;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        gameObject.AddComponent<Rigidbody>().useGravity = false;
        parent = GameObject.FindWithTag("SpawnerRuntime").transform;
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (healthPoints < 1)
            KillEnemy();
    }

    void ProcessHit()
    {
        ParticleSystem vfx = Instantiate(hitParticle, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        healthPoints--;
    }

    private void KillEnemy()
    {
        scoreBoard.IncreaseScore(score);
        //Debug.Log($"{gameObject.name} hited by {other.gameObject.name}");
        GameObject vfx = Instantiate(crashFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }
}
