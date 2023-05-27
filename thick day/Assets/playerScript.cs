using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public float horizontal;
    public bool isFacingRight = true;
    public float jumpingPower = 16f;
    public float moveSpeed = 5f;

    public PlayerControls playerInputs;
    Vector2 moveDirection = Vector2.zero;
    private InputAction move;
    private InputAction fire;
    private void Awake()
    {
        playerInputs = new PlayerControls();
    }
    private void OnEnable()
    {
        move = playerInputs.Player.Move;
        move.Enable();

        fire = playerInputs.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
    }
    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();

        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void Fire(InputAction.CallbackContext Context)
    {
        Debug.Log("we fire");
    }
}
