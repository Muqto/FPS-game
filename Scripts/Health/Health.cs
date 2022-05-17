using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
public int maxHealth;
public int health;
public GameObject player;
void Start(){
    health = maxHealth;
}
public void takeDamage(){
    health -= 20;
    if (health <= 0){
        Destroy(player);
    }
}
}
