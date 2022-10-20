using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGY
{
    public class Monster : MonoBehaviour, IInterface
    {
        public float hp;
        public float HP
        {
            get
            {
                return hp;
            }
            set
            {
                hp = value;
                if (hp <= 0) Destroy(gameObject);
            }
        }

        public void Attack(int num)
        {
            HP -= num;
        }

    }
}

