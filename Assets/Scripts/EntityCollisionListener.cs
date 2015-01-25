using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class EntityCollisionListener : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        var entity = other.gameObject.GetComponent<Entity>();
        if (entity != null)
        {
            SendMessageUpwards("OnEntityCollisionEnter", new EntityCollisionEventArgs(gameObject.name, entity), SendMessageOptions.DontRequireReceiver);
        }
        else
        {
            Debug.LogWarning("No Entity component attached.");
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        var entity = other.gameObject.GetComponent<Entity>();
        if (entity != null)
        {
            SendMessageUpwards("OnEntityCollisionExit", new EntityCollisionEventArgs(gameObject.name, entity), SendMessageOptions.DontRequireReceiver);
        }
        else
        {
            Debug.LogWarning("No Entity component attached.");
        }
    }
}
