using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MeleeWeapon : Weapon
{
    [SerializeField]
    protected float _knockBackImpact;


    public override void Attack()
    {
        base.Attack();

        foreach (var entity in EntitiesInAttackRange)
        {
            var weaponHolder = transform.parent.gameObject.GetComponent<Creature>();

            if (entity.GetType() != weaponHolder.GetType())
            {
                entity.ApplyDamage(_baseDamage);
                entity.KnockBack(Vector2.right * transform.parent.localScale.x * _knockBackImpact);
            }
        }
    }
}
