using Assets.Scripts.Enemy;
using UnityEngine;

namespace Assets.Scripts.Assets
{
    [CreateAssetMenu(menuName = "Assets/Enemy Asset", fileName = "Enemy Asset")]
    public class EnemyAsset : ScriptableObject
    {
        public int StartHealth;

        public EnemyView ViewPrefab;
    }
}