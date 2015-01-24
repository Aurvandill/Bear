using UnityEngine;
using System.Collections;

public class MeleeWeapon : Weapon
{
    public override void AttackEntity(Entity target)
    {
        target.ApplyDamage(_baseDamage);
    }
}
