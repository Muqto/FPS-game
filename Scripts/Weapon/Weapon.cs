using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Gun[] loadout;
    public Transform weaponParent;
    public GameObject currentWeapon;
    public void equip(int index){
        if (currentWeapon!= null){
            Destroy(currentWeapon);
        }
        GameObject gun = Instantiate(loadout[index].prefab, weaponParent.position, weaponParent.rotation, weaponParent) as GameObject;
        gun.transform.localPosition = Vector3.zero;
        gun.transform.localEulerAngles = Vector3.zero;
        currentWeapon = gun;
    }
}
