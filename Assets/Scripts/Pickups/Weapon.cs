using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public abstract class Weapon : Pickup
{
    [SerializeField]
    protected GameObject _impactRange;
    [SerializeField]
    protected float _baseDamage;
    [SerializeField]
    protected float _cooldown;

    public bool IsReady = true;

    protected List<Creature> EntitiesInAttackRange = new List<Creature>();

    public virtual void Attack()
    {
        RemoveDeadEntites();
    }

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
            var creature = args.Entity as Creature;
            if (creature != null)
            {
                EntitiesInAttackRange.Add(creature);
            }
        }
    }

    public void OnEntityCollisionExit(EntityCollisionEventArgs args)
    {
        if (args.SenderId.Equals(_impactRange.name))
        {
            var creature = args.Entity as Creature;
            if (creature != null)
            {
                EntitiesInAttackRange.Remove(creature);
            }
        }
    }

    public bool IsTargetInRange<T>()
    {
        RemoveDeadEntites();
        return EntitiesInAttackRange.OfType<T>().Count() > 0;
    }

    private void RemoveDeadEntites()
    {
        EntitiesInAttackRange.RemoveAll(e => !e.IsAlive);
    }
}
