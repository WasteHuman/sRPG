using UnityEngine;

namespace Assets.Scripts.Turret
{
    [CreateAssetMenu(menuName = "Assets/Turret Asset", fileName = "Turret Asset")]
    public class TurretAsset : ScriptableObject
    {
        public TurretView ViewPrefab;
    }
}