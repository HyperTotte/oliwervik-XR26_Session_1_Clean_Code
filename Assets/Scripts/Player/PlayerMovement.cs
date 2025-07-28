using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    private float rotationSpeed = 0.5f; // For mouse rotation

    private Rigidbody rb;
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


    private void Update()
    {
        
    }

}
