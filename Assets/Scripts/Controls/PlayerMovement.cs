using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Dash")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    [SerializeField] private float ControlReduce;

    [Header("Other")]
    [SerializeField] private float playerSpeed;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private ControlSettings controlSettings;
    [SerializeField] private InputCenter inputCenter;

    private Vector2 aimFlat;
    private Camera mainCamera;
    private Vector3 move;
    private Plane aimGroundPlane;
    private Vector3 lastMoveDirection;


    private void OnEnable()
    {
        inputCenter.OnMove += HandleMove;
        inputCenter.OnAim += HandleAim;
        inputCenter.OnDash += HandleDash;
        aimGroundPlane = new Plane(Vector3.up, Vector3.zero);
    }

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        Move();
        Aim();
    }

    private void OnDisable()
    {
        inputCenter.OnMove -= HandleMove;
        inputCenter.OnAim -= HandleAim;
        inputCenter.OnDash -= HandleDash;
    }


    private void HandleAim(Vector2 aimArg)
    {
        aimFlat = aimArg;
    }

    private void HandleMove(Vector2 moveArg)
    {
        if (move != Vector3.zero && moveArg == Vector2.zero)
        {
            lastMoveDirection = move;
        }
        move = Quaternion.Euler(0, 45, 0) * new Vector3(moveArg.x, 0, moveArg.y); // fix orientation by rotating movment by vector 45 degrees

    }

    private void HandleDash()
    {
        StartCoroutine(DashCoroutine());
    }

    private void Move()
    {
        characterController.Move(move * Time.deltaTime * playerSpeed);
        this.transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    }

    private void Aim()
    {
        if (controlSettings.isGamepad)
        {
            Vector3 aim = Quaternion.Euler(0, 45, 0) * new Vector3(aimFlat.x, 0, aimFlat.y);

            Vector3 lookDirection;

            if (aim != Vector3.zero)        lookDirection = aim;
            else if (move != Vector3.zero)  lookDirection = move;
            else                            lookDirection = transform.forward;

            transform.rotation = Quaternion.LookRotation(lookDirection);
        }
        else
        {
            Ray ray = mainCamera.ScreenPointToRay(aimFlat);
            if (aimGroundPlane.Raycast(ray, out float rayDistance))
            {
                Vector3 pointToLookAt = ray.GetPoint(rayDistance);
                Vector3 lookDirection = new Vector3(pointToLookAt.x, transform.position.y, pointToLookAt.z);
                transform.LookAt(lookDirection);
            }
        }
    }

    private IEnumerator DashCoroutine()
    {
        float startTime = Time.time;
        Vector3 dashDirection;
        if (move != Vector3.zero) dashDirection = move;
        else dashDirection = lastMoveDirection;

        while(Time.time < startTime + dashDuration)
        {
            characterController.Move(dashDirection * dashSpeed * Time.deltaTime / (Time.time - startTime));
            yield return null;
        }
    }
}