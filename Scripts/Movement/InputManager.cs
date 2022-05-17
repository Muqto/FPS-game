using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    private PlayerMotor motor;
    private PlayerLook look;
    private PlayerSprint sprint;
    // Start is called before the first frame update
    private PlayerCrouch crouch;
    [SerializeField][Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;
    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;
    [SerializeField][Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;
    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;
    private Weapon weapon;
    private Shoot pewpew;
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        sprint = GetComponent<PlayerSprint>();
        crouch = GetComponent<PlayerCrouch>();
        weapon = GetComponent<Weapon>();
        pewpew = GetComponent<Shoot>();
        onFoot.Jump.performed += ctx => motor.Jump();
        onFoot.SprintStart.performed += ctx => sprint.Sprintpressed();
        onFoot.SprintFinish.performed += ctx => sprint.Sprintnotpressed();
        onFoot.Crouch.performed += ctx => crouch.crouch();
        onFoot.Equip.performed += ctx => weapon.equip(0);
        onFoot.Shoot.performed += ctx => pewpew.shoot();



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 targetDir = onFoot.Movement.ReadValue<Vector2>();
        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);
        motor.ProcessMove(currentDir, targetDir);
        

    }
    void LateUpdate(){
        Vector2 targetMouseDelta = onFoot.Look.ReadValue<Vector2>();
        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);
        look.ProcessLook(currentMouseDelta);
    }
    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
