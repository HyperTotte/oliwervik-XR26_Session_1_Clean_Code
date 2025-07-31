using UnityEngine;

public class GroundChecker : MonoBehaviour, ICollisionHandler
{
    public bool IsGrounded { get; private set; }

    public void HandleCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }

    public void HandleTriggerEnter(Collider other)
    {
        //interface requires. no trigger used atm.
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = false;
        }
    }

}
