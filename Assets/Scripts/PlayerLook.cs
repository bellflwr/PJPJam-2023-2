using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity = 100f;
    public float fovTransitionSpeed = 10;

    public float FovMultiplier
    {
        get => _fovMultiplier;
        set
        {
            _fovMultiplier = value;
            _targetFov = _originalFov * _fovMultiplier;
        }
    }

    private float _xRotation = 0f;

    private Camera _cam;
    private float _targetFov;
    private float _originalFov;
    private float _fovMultiplier = 1;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _cam = GetComponent<Camera>();
        _originalFov = _cam.fieldOfView;
        _targetFov = _originalFov;
    }

    // Update is called once per frame
    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up, mouseX);


        _cam.fieldOfView += Mathf.Clamp(_targetFov - _cam.fieldOfView, -fovTransitionSpeed, fovTransitionSpeed);
    }
}