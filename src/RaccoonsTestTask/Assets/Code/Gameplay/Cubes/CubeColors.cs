using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Cubes
{
    public static class CubeColors
    {
        private static readonly Dictionary<int, Color> _colorByCubeValue = new()
        {
            { 2, new Color(0.85f, 0.92f, 0.98f) },
            { 4, new Color(0.50f, 0.78f, 0.96f) },
            { 8, new Color(0.96f, 0.80f, 0.60f) },
            { 16, new Color(0.98f, 0.68f, 0.42f) },
            { 32, new Color(0.98f, 0.48f, 0.37f) },
            { 64, new Color(0.94f, 0.30f, 0.23f) },
            { 128, new Color(0.93f, 0.81f, 0.45f) },
            { 256, new Color(0.93f, 0.78f, 0.31f) },
            { 512, new Color(0.93f, 0.76f, 0.15f) },
            { 1024, new Color(0.93f, 0.69f, 0.07f) },
            { 2048, new Color(0.90f, 0.60f, 0.00f) },
            { 4096, new Color(0.45f, 0.36f, 0.74f) },
            { 8192, new Color(0.33f, 0.60f, 0.78f) },
            { 16384, new Color(0.24f, 0.67f, 0.47f) },
            { 32768, new Color(0.85f, 0.28f, 0.36f) },
            { 65536, new Color(0.53f, 0.24f, 0.75f) },
            { 131072, new Color(0.28f, 0.56f, 0.76f) },
        };

        public static bool TryGet(int value, out Color color) =>
            _colorByCubeValue.TryGetValue(value, out color);
    }
}