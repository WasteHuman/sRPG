using Assets.Scripts.Enemy;
using UnityEngine;

namespace Assets.Scripts.Turret.Weapon.Projectile
{
    public abstract class ProjectileAssetBase : ScriptableObject
    {
        public abstract ProjectileBase CreateProjectile(Vector3 origin, Vector3 originForward, EnemyData enemyData);
    }
}
