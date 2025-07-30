using UnityEngine;

public interface ICollisionHandler
{
    void HandleCollisionEnter(Collision collision);
    void HandleTriggerEnter(Collider other);
}
