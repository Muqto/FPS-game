using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{   
    public Slider slider;
    public Health healthC;
    public GameObject enemy;
    public GameObject player;
    void FixedUpdate(){
       slider.transform.LookAt(new Vector3(player.transform.position.x, player.transform.position.y,player.transform.position.z));

    }
    public void ReduceEnemyHPBar(){
        healthC = enemy.transform.GetComponent<Health>();
        slider.value = (float) healthC.health/healthC.maxHealth;
    }


}
