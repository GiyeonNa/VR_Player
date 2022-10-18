using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        //Lock all axes movement and rotation
        //rb.constraints = RigidbodyConstraints.FreezeAll;
        //speed = 0;

        //ContactPoint contact = collision.contacts[0];
        //Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        //Vector3 pos = contact.point + contact.normal * hitOffset;

        //if (hit != null)
        //{
        //    var hitInstance = Instantiate(hit, pos, rot);
        //    if (UseFirePointRotation) { hitInstance.transform.rotation = gameObject.transform.rotation * Quaternion.Euler(0, 180f, 0); }
        //    else if (rotationOffset != Vector3.zero) { hitInstance.transform.rotation = Quaternion.Euler(rotationOffset); }
        //    else { hitInstance.transform.LookAt(contact.point + contact.normal); }

        //    var hitPs = hitInstance.GetComponent<ParticleSystem>();
        //    if (hitPs != null)
        //    {
        //        Destroy(hitInstance, hitPs.main.duration);
        //    }
        //    else
        //    {
        //        var hitPsParts = hitInstance.transform.GetChild(0).GetComponent<ParticleSystem>();
        //        Destroy(hitInstance, hitPsParts.main.duration);
        //    }
        //}
        //foreach (var detachedPrefab in Detached)
        //{
        //    if (detachedPrefab != null)
        //    {
        //        detachedPrefab.transform.parent = null;
        //    }
        //}
        Debug.Log("Give DMG 10");
        if (collision.gameObject.GetComponent<Monster>()) collision.gameObject.GetComponent<Monster>().hp -= 10;
        //Destroy(gameObject);
    }
}
