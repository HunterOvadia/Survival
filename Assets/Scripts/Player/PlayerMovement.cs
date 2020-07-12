using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 180f;
    [SerializeField] private float _gravity = -9.81f;

    private CharacterController _controller;
    private Vector3 _moveDirection = Vector3.zero;
    private Vector3 _rotation;
    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * _rotationSpeed * Time.deltaTime, 0f);

        _moveDirection = new Vector3(0f, 0f, Input.GetAxisRaw("Vertical") * _movementSpeed * Time.deltaTime);
        _moveDirection = transform.TransformDirection(_moveDirection);
        _moveDirection.y += (_gravity * Time.deltaTime);

        _controller.Move(_moveDirection);
        transform.Rotate(_rotation);
    }
}
