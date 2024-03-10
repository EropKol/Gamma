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
        ResetVarUpdate();

        CheckControlsUpdate();

        ResetFallSpeed();
    }

    void FixedUpdate()
    {
        _characterController.Move(_moveVector * Speed * Time.fixedDeltaTime);

        _fallVelocity += Gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
            PlayerAnim.SetBool("IsJumping", false);
        }
    }

    void ResetVarUpdate()
    {
        _moveVector = Vector3.zero;
        PlayerAnim.SetFloat("Speed", 0);
        PlayerAnim.SetFloat("HorizontalSpeed", 0);
    }

    void CheckControlsUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MoveForwardUpdate();
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveBackUpdate();
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeftUpdate();
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRightUpdate();
        }
    }

    void MoveForwardUpdate()
    {
        _moveVector += transform.forward;
        PlayerAnim.SetFloat("Speed", 1);
    }
    void MoveBackUpdate()
    {
        _moveVector -= transform.forward;
        PlayerAnim.SetFloat("Speed", -1);
    }
    void MoveLeftUpdate()
    {
        _moveVector -= transform.right;
        PlayerAnim.SetFloat("HorizontalSpeed", -1);
    }
    void MoveRightUpdate()
    {
        _moveVector += transform.right;
        PlayerAnim.SetFloat("HorizontalSpeed", 1);
    }

    void ResetFallSpeed()
    {
        if (_characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _fallVelocity = -JumpForce;
            PlayerAnim.SetBool("IsJumping", true);
        }
    }
}
