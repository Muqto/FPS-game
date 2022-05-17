using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
     
    public Slider playerSlider;
    public Health healthC;
    public GameObject player;
        public void ReducePlayerHPBar(){
            healthC = player.transform.GetComponent<Health>();
            playerSlider.value = (float) healthC.health/healthC.maxHealth;
    }
}
