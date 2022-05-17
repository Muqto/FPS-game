using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera cam;
    public ParticleSystem muzzleFlash;
    public ParticleSystem onHitEffect;
    public Health health;
    public EnemyHealth enemyHP;

    public void shoot(){
        muzzleFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit)){
            if(hit.collider != null){
                ParticleSystem blast = Instantiate(onHitEffect, hit.point, Quaternion.LookRotation(hit.normal));
                health = hit.transform.GetComponent<Health>();
                enemyHP = hit.transform.GetComponent<EnemyHealth>();
                if (health != null){
                    health.takeDamage();
                    enemyHP.ReduceEnemyHPBar();
                }
                blast.Play();
                Destroy(blast.gameObject, 1f);
                
            }   
           
        }
    }
}
