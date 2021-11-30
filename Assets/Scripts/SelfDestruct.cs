using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] float destroyTimer;

    void Start()
    {
        Destroy(gameObject, destroyTimer);
    }
}
