using UnityEngine;
using System.Collections;

public class EntityCollisionEventArgs
{
    public string SenderId { get; set; }
    public Entity Entity { get; set; }

    public EntityCollisionEventArgs(string id, Entity entity)
    {
        SenderId = id;
        Entity = entity;
    }
}
