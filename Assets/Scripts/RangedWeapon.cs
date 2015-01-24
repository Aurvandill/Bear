using UnityEngine;
using System.Collections;

public class RangedWeapon : Weapon
{
    [SerializeField]
    private GameObject _projectilePrefab;

    public override void AttackEntity(Entity target)
    {
        //add offset to position?
        var projectile = Instantiate(_projectilePrefab, transform.position, new Quaternion());
    }
}
