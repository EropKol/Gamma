using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Gravity = 9.8f;
    public float JumpForce;
    public float Speed;
    public Animator PlayerAnim;

    private Vector3 _moveVector;
    private float _fallVelocity = 0;
    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _moveVector = Vector3.zero;
        PlayerAnim.SetFloat("Speed", 0);
        PlayerAnim.SetFloat("HorizontalSpeed", 0);

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            PlayerAnim.SetFloat("Speed", 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            PlayerAnim.SetFloat("Speed", -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            PlayerAnim.SetFloat("HorizontalSpeed", -1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            PlayerAnim.SetFloat("HorizontalSpeed", 1);
        }

        if (_characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _fallVelocity = -JumpForce;
            PlayerAnim.SetBool("IsJumping", true);
        }
    }

    void FixedUpdate()
    {
        _characterController.Move(_moveVector * Speed * Time.fixedDeltaTime);

        _fallVelocity += Gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        if(_characterController.isGrounded)
        {
            _fallVelocity = 0;
            PlayerAnim.SetBool("IsJumping", false);
        }
    }

}
