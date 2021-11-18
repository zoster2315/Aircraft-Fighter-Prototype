using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject crashParticle;

    private void OnParticleCollision(GameObject other)
    {
        //Debug.Log($"{gameObject.name} hited by {other.gameObject.name}");
        Instantiate(crashParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
