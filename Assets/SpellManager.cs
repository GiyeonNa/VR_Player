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
        public GameObject preViewObject;
        public bool isPreview; 
        public GameObject fireball;
        public GameObject ice;
        public GameObject lighting;
        [SerializeField] string spellName;
        public float range = 10f;
        private RaycastHit hit;

        private void Update()
        {
            CastSpell(spellName);
            if(isPreview) PreviewPosUpdate();
        }

        public void CastSpell(GestureMetaData data)
        {
            switch (data.name)
            {
                case "Square":
                    LightingReady();
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

        public void LightingReady()
        {
            isReady = true;
            isPreview = true;
            spellReadyParticle.Play();
            //�̸����⸦ ����� ���ÿ� ��ġ�� ���ؾ���
            preViewObject = Instantiate(preViewObject, spellPoint.position + spellPoint.forward, Quaternion.identity);
        }

        public void CastSpell(string spellname)
        {
            if (!isReady) return;
            //���� �׽�Ʈ
            if(spellName == "Square")
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Instantiate(lighting, hit.point, preViewObject.transform.rotation);
                    Destroy(preViewObject);
                    isReady = false;
                    spellReadyParticle.Stop();
                    isPreview = false;
                }
            }
            //if(spellName == "Square")
            //{
            //    if (Input.GetKeyDown(KeyCode.Space))
            //    {
            //        Instantiate(fireball, spellPoint.position + new Vector3(0, 0, 1), spellPoint.rotation);
            //    }
            //}
            //if (Input.GetKeyDown(KeyCode.Space))
            //{

            //    Debug.Log(spellname);
            //    //��� �� ������ �����ϤѤ���?
            //    isReady = false;
            //    spellReadyParticle.Stop();
            //    Instantiate(fireball, spellPoint.position + new Vector3(0,0,2), spellPoint.rotation);
            //}
        }

        private void PreviewPosUpdate()
        {
            
            if (Physics.Raycast(spellPoint.position, spellPoint.forward, out hit, range))
            {
                if (hit.transform != null)
                {
                    Vector3 location = hit.point;
                    preViewObject.transform.position = location;
                }
            }
        }


    }

    

}
