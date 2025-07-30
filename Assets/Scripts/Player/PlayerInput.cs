using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    
    
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        // Handle movement
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // Handle rotation with mouse
        float mouseX = Input.GetAxis("Mouse X"); //* rotationSpeed;
                                                 //yaw += mouseX;
                                                 //transform.rotation = Quaternion.Euler(0f, yaw, 0f);

        playerMovement.Move(h, v);
        playerMovement.Rotate(mouseX);

        if (Input.GetButtonDown("Jump"))
        {
            playerMovement.Jump();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.Instance.RestartGame();
        }

    }
}
