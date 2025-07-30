using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    private float rotationSpeed = 0.5f; // For mouse rotation

    private bool isJumping = false;
    private bool isGrounded;
    private float yaw = 0f; // For mouse rotation
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Player needs a Rigidbody component!");
        }
        // Freeze rotation to prevent physics flipping the player
        rb.freezeRotation = true;
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to screen center  
    }

    private void FixedUpdate()
    {
        
    }

    public void Move(float h, float v)
    {
        Vector3 direction = transform.forward * v + transform.right * h;
        Vector3 velocity = direction.normalized * moveSpeed;

        Vector3 newPos = rb.position + velocity * Time.fixedDeltaTime;
        rb.MovePosition(newPos);
    }

    public void Rotate(float mouseX)
    {
        yaw += mouseX;
        transform.rotation = Quaternion.Euler(0f, yaw, 0f);
    }
    public void Jump()
    {
        if (!isGrounded) return;

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
        isJumping = true; // Simple animation state
        Debug.Log("Player jumped!");
    }

    /*   this is from player script. old code movement & input coupled...
        Vector3 direction = transform.forward * v + transform.right * h;
        Vector3 velocity = direction.normalized * moveSpeed;

        Vector3 newPos = rb.position + velocity * Time.fixedDeltaTime;
        rb.MovePosition(newPos);
    */
    
}