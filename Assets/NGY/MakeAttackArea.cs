using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGY
{
    public class MakeAttackArea : MonoBehaviour
    {
        [SerializeField] private ParticleSystem particle;

        private void Awake()
        {
            particle = GetComponent<ParticleSystem>();
        }

        private void OnParticleCollision(GameObject other)
        {
            if (other.GetComponent<Monster>()) other.GetComponent<Monster>().Attack(20);
                
        }


    }
}

