using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;
    private PlayerLook _camController;

    public float speed = 20f;
    public float runMultiplier = 1.5f;
    public float gravity = -10f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 _velocity;
    private bool _isGrounded;

    private float _currentSpeed;


    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _camController = GetComponentInChildren<PlayerLook>();
        _currentSpeed = speed;
    }


    void Update()
    {
        CheckGrounding();

        HandleModifiers();

        CalculateHorizontalVel();

        HandleJump();

        // Gravity
        _velocity.y += gravity * Time.deltaTime;

        _controller.Move(_velocity * Time.deltaTime);
    }

    void CheckGrounding()
    {
        _isGrounded = Physics.CheckSphere(
            groundCheck.position + Vector3.up * (_controller.radius - groundDistance),
            _controller.radius,
            groundMask
        );

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
    }

    void HandleModifiers()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _currentSpeed *= runMultiplier;
            _camController.FovMultiplier = runMultiplier;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _currentSpeed /= runMultiplier;
            _camController.FovMultiplier = 1;
        }
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    void CalculateHorizontalVel()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        var velH = transform.right * x + transform.forward * z;
        if (velH.magnitude > 1)
        {
            velH.Normalize();
        }

        velH *= _currentSpeed;

        _velocity.x = velH.x;
        _velocity.z = velH.z;
    }
}