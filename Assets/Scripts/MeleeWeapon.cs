using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeleeWeapon : Weapon
{
    [SerializeField]
    protected float _knockBackImpact;


    public override void Attack()
    {
        if (CanAttack())
        {
            //animation
            foreach (var entity in EntitiesInAttackRange)
            {
                entity.ApplyDamage(_baseDamage);
                entity.KnockBack(Vector2.right * transform.parent.localScale.x * _knockBackImpact);
            }
        }
    }
}
