using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        //Debug.Log($"{gameObject.name} hited by {other.gameObject.name}");
        Destroy(gameObject);
    }
}
