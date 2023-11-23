using UnityEngine;

namespace Assets.Scripts.Assets
{
    [CreateAssetMenu(menuName = "Assets/Spawn Waves Asset", fileName = "Spawn Waves Asset")]
    public class SpawnWaveAsset : ScriptableObject
    {
        public EnemyAsset EnemyAsset;
        public int Count;
        public float TimeBetweenSpawns;
    }
}