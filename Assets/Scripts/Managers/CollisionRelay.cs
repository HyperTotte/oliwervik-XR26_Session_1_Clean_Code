using UnityEngine;
using System.Collections.Generic;

public class CollisionRelay : MonoBehaviour
{
    private List<ICollisionHandler> handlers = new List<ICollisionHandler>();

    private void Awake()
    {
        GetComponents(handlers);
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (var handler in handlers)
        {
            handler.HandleCollisionEnter(collision);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (var handler in handlers)
        {
            handler.HandleTriggerEnter(other);
        }
    }

   
}
