﻿using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Assets
{
    [CreateAssetMenu(menuName = "Assets/Level Asset", fileName = "Level Asset")]
    public class LevelAsset : ScriptableObject
    {
        public SceneAsset SceneAsset;
        public SpawnWaveAsset SpawnWaveAsset;
    }
}