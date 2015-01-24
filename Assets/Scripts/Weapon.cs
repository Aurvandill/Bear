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

    public bool IsReady = true;

    private float _currentWaitTime;

    protected List<Creature> EntitiesInAttackRange = new List<Creature>();

    public abstract void Attack();

    public bool RequestIsReady()
    {
        if (IsReady)
        {
            StartCoroutine(WaitForAttack());

            return true;
        }

        return false;
    }

    public IEnumerator WaitForAttack()
    {
        IsReady = false;
        yield return new WaitForSeconds(_cooldown);
        IsReady = true;
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
