using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject crashParticle;
    [SerializeField] Transform parent;
    [SerializeField] int score;
    [SerializeField] int healthPoints;
    [SerializeField] ParticleSystem hitParticle;

    ScoreBoard scoreBoard;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
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
        scoreBoard.IncreaseScore(score);
        healthPoints--;
    }

    private void KillEnemy()
    {
        //Debug.Log($"{gameObject.name} hited by {other.gameObject.name}");
        GameObject vfx = Instantiate(crashParticle, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }
}
