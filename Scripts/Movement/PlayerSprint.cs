using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
public bool isSprintPressed;
 public void Sprintpressed(){
     isSprintPressed = true;
 }
  public void Sprintnotpressed(){
     isSprintPressed = false;
 }
}
