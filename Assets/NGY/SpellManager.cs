using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gestures
{
    public class SpellManager : MonoBehaviour
    {
        private bool isReady;
        [SerializeField] Transform spellPoint;
        public ParticleSystem[] spellReadyParticles;
        private ParticleSystem curParticle;
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
        [SerializeField] private LayerMask layerMask;

        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip[] spellReadySounds;
        [SerializeField] private AudioClip[] spellFireSounds;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {

            if (isPreview) PreviewPosUpdate();
            if (isReady)
            {
                if (OVRInput.GetDown(fireActiveButton, controllerType)) CastSpell(spellName);
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
            curParticle = spellReadyParticles[0];
            isReady = true;
            audioSource.clip = spellReadySounds[0];
            audioSource.Play();
            curParticle.Play();
            //if(Input.GetKeyUp(KeyCode.Escape))
        }

        public void IceReady()
        {
            curParticle = spellReadyParticles[1];
            isReady = true;
            audioSource.clip = spellReadySounds[1];
            audioSource.Play();
            curParticle.Play();
            iceammo = 10;
            //if(Input.GetKeyUp(KeyCode.Escape))
        }

        public void LightingReady()
        {
            curParticle = spellReadyParticles[2];
            isReady = true;
            isPreview = true;
            curParticle.Play();
            //미리보기를 만듬과 동시에 위치가 변해야함
            preViewObject = Instantiate(preView, spellPoint.position + spellPoint.forward, Quaternion.identity);
        }

        public void CastSpell(string spellname)
        {
            if (!isReady) return;

            if (spellName == "Square")
            {
                isReady = false;
                curParticle.Stop();
                audioSource.Pause();
                Instantiate(fireball, spellPoint.position + spellPoint.forward, spellPoint.rotation);
            }

            if (spellName == "Triangle")
            {
                Instantiate(ice, spellPoint.position + spellPoint.forward, spellPoint.rotation);
                iceammo -= 1;
                if (iceammo == 0)
                {
                    isReady = false;
                    curParticle.Stop();
                    audioSource.Pause();
                }
            }

            //번개 테스트
            if (spellName == "Circle")
            {
                Instantiate(lighting, hit.point, preViewObject.transform.rotation);
                Destroy(preViewObject);
                isReady = false;
                curParticle.Stop();
                isPreview = false;
            }
        }

        private void PreviewPosUpdate()
        {

            if (Physics.Raycast(spellPoint.position, spellPoint.forward, out hit, range, layerMask))
            {
                if (hit.transform != null)
                {
                    Vector3 location = hit.point;
                    preViewObject.transform.position = location;
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(spellPoint.position, spellPoint.forward);
        }


    }



}
