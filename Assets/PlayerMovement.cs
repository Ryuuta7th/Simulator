using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float rotationSpeed;

    private Rigidbody2D rb;

    private Vector2 input;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current == null)
            return;
            
        float horizontalInput = 0f;
        float verticalInput = 0f;

        if (Keyboard.current.aKey.isPressed) horizontalInput = -1f;
        if (Keyboard.current.dKey.isPressed) horizontalInput = 1f;
        if (Keyboard.current.wKey.isPressed) verticalInput = 1f;
        if (Keyboard.current.sKey.isPressed) verticalInput = -1f;

        input = new Vector2(horizontalInput, verticalInput). normalized;
    }

    private void FixedUpdate()
    {
    rb.MovePosition(rb.position + input * speed * Time.fixedDeltaTime);

    if (input != Vector2.zero)
    {
        float angle = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg - 135f;
        rb.MoveRotation(Mathf.LerpAngle(rb.rotation, angle, rotationSpeed * Time.fixedDeltaTime));
    }
    
    }
}