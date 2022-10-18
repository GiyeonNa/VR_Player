using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeAttackArea : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name + "@@@@@@@@@@@@@@@@@@@@@");
    }

    
}
