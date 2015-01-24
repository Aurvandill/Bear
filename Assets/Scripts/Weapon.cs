using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    protected float _baseDamage;

    public abstract void AttackEntity(Entity target);
}
