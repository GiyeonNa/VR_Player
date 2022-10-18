using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gestures
{
    public class SpellManager : MonoBehaviour
    {
        private bool isReady;
        [SerializeField] Transform spellPoint;
        [SerializeField] ParticleSystem spellReadyParticle;
        public GameObject fireball;
        [SerializeField] string spellName;

        private void Update()
        {
            CastSpell(spellName);
        }

        public void CastSpell(GestureMetaData data)
        {
            switch (data.name)
            {
                case "Square":
                    FireBallReady();
                    spellName = data.name;
                    break;

                case "Triangle":
                    break;
                case "Circle":
                    break;
                case "Heart":
                    break;
                case "S":
                    break;
                case "Plus":
                    break;
                default:
                    break;
            }

        }

        public void FireBallReady()
        {
            //장전식
            //조준선이 나오는게 좋아보임
            //이펙트 나오면 준비를 보여줌
            isReady = true;
            spellReadyParticle.Play();
            //if(Input.GetKeyUp(KeyCode.Escape))
        }

        public void CastSpell(string spellname)
        {
            if (!isReady) return;

            if (Input.GetKeyDown(KeyCode.Space))
            {

                Debug.Log(spellname);
                //어떻게 각 마법을 구분하ㅡㄴ가?
                isReady = false;
                spellReadyParticle.Stop();
                Instantiate(fireball, spellPoint.position, spellPoint.rotation);
            }
        }




    }

    

}
