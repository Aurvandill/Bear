using UnityEngine;
using System.Collections;

public class EntityCollisionEventArgs
{
    public string SenderId { get; set; }
    public Creature Entity { get; set; }

    public EntityCollisionEventArgs(string id, Creature entity)
    {
        SenderId = id;
        Entity = entity;
    }
}
