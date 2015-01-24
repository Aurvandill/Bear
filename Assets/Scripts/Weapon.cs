using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    protected GameObject _impactRange;
    [SerializeField]
    protected float _baseDamage;
    [SerializeField]
    protected float _cooldown;

    private float _currentWaitTime;

    protected List<Creature> EntitiesInAttackRange = new List<Creature>();

    public abstract void Attack();

    public bool IsReady()
    {
        _currentWaitTime += Time.deltaTime;

        if (_currentWaitTime > _cooldown)
        {
            _currentWaitTime = 0;
            return true;
        }

        return false;
    }

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
