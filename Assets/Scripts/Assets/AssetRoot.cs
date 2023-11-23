﻿using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Assets
{
    [CreateAssetMenu(menuName = "Assets/Asset Root", fileName = "Asset Root")]
    public class AssetRoot : ScriptableObject
    {
        public List<LevelAsset> Levels;
    }
}