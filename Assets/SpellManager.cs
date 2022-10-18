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
        public GameObject preView;
        public GameObject preViewObject;
        public bool isPreview; 
        public GameObject fireball;
        public GameObject ice;
        public GameObject lighting;
        [SerializeField] string spellName;
        public float range = 10f;
        private RaycastHit hit;
        public OVRInput.Controller controllerType;
        public OVRInput.Button fireActiveButton;

        float iceammo;
        private void Update()
        {
            
            if(isPreview) PreviewPosUpdate();
            if (isReady)
            {
                if(OVRInput.GetDown(fireActiveButton, controllerType)) CastSpell(spellName);
            }
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
                    IceReady();
                    spellName = data.name;
                    break;

                case "Circle":
                    LightingReady();
                    spellName = data.name;
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

        public void IceReady()
        {
            isReady = true;
            spellReadyParticle.Play();
            iceammo = 10;
            //if(Input.GetKeyUp(KeyCode.Escape))
        }

        public void LightingReady()
        {
            isReady = true;
            isPreview = true;
            spellReadyParticle.Play();
            //미리보기를 만듬과 동시에 위치가 변해야함
            preViewObject = Instantiate(preView, spellPoint.position + spellPoint.forward, Quaternion.identity);
        }

        public void CastSpell(string spellname)
        {
            if (!isReady) return;

            if (spellName == "Square")
            {
                isReady = false;
                spellReadyParticle.Stop();
                Instantiate(fireball, spellPoint.position + new Vector3(0, 0, 1), spellPoint.rotation);
            }

            if (spellName == "Triangle")
            {
                Instantiate(ice, spellPoint.position + new Vector3(0, 0, 1), spellPoint.rotation);
                iceammo -= 1;
                if(iceammo == 0)
                {
                    isReady = false;
                    spellReadyParticle.Stop();
                }         
            }

            //번개 테스트
            if (spellName == "Circle")
            {
                //if (Input.GetKeyDown(KeyCode.Space))
                //{
                //    Instantiate(lighting, hit.point, preViewObject.transform.rotation);
                //    Destroy(preViewObject);
                //    isReady = false;
                //    spellReadyParticle.Stop();
                //    isPreview = false;
                //}
                Instantiate(lighting, hit.point, preViewObject.transform.rotation);
                Destroy(preViewObject);
                isReady = false;
                spellReadyParticle.Stop();
                isPreview = false;
            }
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
