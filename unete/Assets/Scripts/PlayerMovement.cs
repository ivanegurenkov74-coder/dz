using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private float gravity = 9.8f;

    private CharacterController cc;
    private Player input;
    private float VerticalVelocity;
    private bool airJump;
    private ice glide;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        input = new Player();
        glide = GetComponent<ice>();
    }
    private void OnDestroy()
    {
        input.Dispose();
    }
    private void OnEnable()
    {
        input.PlayerMove.Enable();
        input.PlayerMove.Jump.performed += OnJump;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (! cc.isGrounded && !airJump)
        {
            return;
        }
        airJump = cc.isGrounded;
        VerticalVelocity = Mathf.Sqrt(2f * gravity * jumpHeight);
    }

    private void OnDisable()
    {
        input.PlayerMove.Disable();
        input.PlayerMove.Jump.performed -= OnJump;
    }
    private void Update()
    {
        if (cc.isGrounded && VerticalVelocity < 0f)
        {
            VerticalVelocity = -2f;
        }

        Vector2 moveInput = input.PlayerMove.Move.ReadValue<Vector2>();
        Vector3 horizontalMove = transform.right * moveInput.x + transform.forward * moveInput.y;
        horizontalMove = Vector3.ClampMagnitude(horizontalMove, 1f) * speed;
        if (glide!= null)
        {
            horizontalMove= glide.Adjust(horizontalMove);
        }
        VerticalVelocity -= gravity * Time.deltaTime;
        Vector3 finalVelocity = horizontalMove + Vector3.up * VerticalVelocity;

        cc.Move(finalVelocity * Time.deltaTime);
    }
}
