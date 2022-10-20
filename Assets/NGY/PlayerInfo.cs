using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGY
{
    public class PlayerInfo : MonoBehaviour
    {
        public static int hp;
        public static int atk;
        public static int gold;

        private void Awake()
        {
            hp = 100;
            atk = 10;
            gold = 10;
        }

        private void OnTriggerEnter(Collider other)
        {
            hp -= 10;
            

        }
    }
}

