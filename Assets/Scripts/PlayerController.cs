using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 _input;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _turnSpeed = 900f;
    [SerializeField] private float _jumpHeight = 5f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    void Update() {
        GatherInput();
        Look();
        Jump();
    }

    void FixedUpdate() {
        Move();
    }

    void GatherInput(){
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    void Look() {
        if (_input != Vector3.zero)
        {
            var relative = (transform.position + _input.ToIso()) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
        }
    }

    void Move() {
        _rb.MovePosition(transform.position + (transform.forward) * _input.magnitude * _speed * Time.deltaTime);
    }

    void Jump() {
     if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _rb.velocity = new Vector3(_rb.velocity.x, _jumpHeight, _rb.velocity.z);
        }

            bool IsGrounded()
        {
            return Physics.CheckSphere(groundCheck.position, .1f, ground);
        }
    }

}
