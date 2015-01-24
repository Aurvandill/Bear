using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    protected GameObject _impactRange;
    [SerializeField]
    protected float _baseDamage;

    public List<Entity> EntitiesInAttackRange = new List<Entity>();

    public abstract void Attack();

    public void OnEntityCollisionEnter(EntityCollisionEventArgs args)
    {
        if (args.SenderId.Equals(_impactRange.name))
        {
            var entity = args.Entity;
            if (entity != null)
            {
                EntitiesInAttackRange.Add(entity);
            }
        }
    }

    public void OnEntityCollisionExit(EntityCollisionEventArgs args)
    {
        if (args.SenderId.Equals(_impactRange.name))
        {
            var entity = args.Entity;
            if (entity != null)
            {
                EntitiesInAttackRange.Remove(entity);
            }
        }
    }

    public bool IsTargetInRange()
    {
        return EntitiesInAttackRange.Count > 0;
    }
}
