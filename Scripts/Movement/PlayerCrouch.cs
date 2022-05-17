using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    public float crouchHeight = 1.5f;
    private int counter = 1;
    public bool isCrouch;
    public float standingHeight = 2f;
    private PlayerMotor playerMotor;
    public void Start(){
        playerMotor = GetComponent<PlayerMotor>();
    }
    public void crouch(){
        if (counter == 0){
            playerMotor.controller.height = standingHeight;

            counter = 1;
            isCrouch = false;
        }
        else{
            playerMotor.controller.height = crouchHeight;
            counter--;
            isCrouch = true;
            
        }
    }
}
