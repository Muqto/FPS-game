using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAI : MonoBehaviour
{
    public float impactForce = 40f;
    public ParticleSystem muzzleFlash;
    public ParticleSystem onHitEffect;

    public void shoot(){
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit)){
            if(hit.collider != null){
                ParticleSystem blast = Instantiate(onHitEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Health health = hit.transform.GetComponent<Health>();
                PlayerHealthBar HP = hit.transform.GetComponent<PlayerHealthBar>();
                if (health != null){
                    health.takeDamage();
                    HP.ReducePlayerHPBar();
                }
                blast.Play();
                Destroy(blast.gameObject);
            }   
           
        }
    }
}
