using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMovement movement;

    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        // Handle rotation with mouse
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        yaw += mouseX;
        transform.rotation = Quaternion.Euler(0f, yaw, 0f);

        // Jumping Logic (Monolithic, handles animation state and physics)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            isJumping = true; // Simple animation state
            Debug.Log("Player jumped!");
        }
    }
}
