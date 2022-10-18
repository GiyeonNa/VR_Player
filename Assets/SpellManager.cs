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
            //������
            //���ؼ��� �����°� ���ƺ���
            //����Ʈ ������ �غ� ������
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
                //��� �� ������ �����ϤѤ���?
                isReady = false;
                spellReadyParticle.Stop();
                Instantiate(fireball, spellPoint.position, spellPoint.rotation);
            }
        }




    }

    

}
