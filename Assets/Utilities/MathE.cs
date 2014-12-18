using UnityEngine;
using System.Collections;

namespace UnityUtilities
{
    public static class MathE
    {
        public static float Map(float value, float min1, float max1, float min2, float max2)
        {
            if (max1 - min1 == 0)
            {
                return 0;
            }

            return (value - min1) / (max1 - min1) * (max2 - min2) + min2;
        }

        public static float MapAndClamp(float value, float min1, float max1, float min2, float max2)
        {
            var mappedValue = Map(value, min1, max1, min2, max2);

            return Mathf.Clamp(mappedValue, min2, max2);
        }

        public static int GetByteFromNormalizedFloat(float normalizedValue)
        {
            return (int)Mathf.Floor(Mathf.Approximately(normalizedValue, 1.0f) ? 255 : normalizedValue * 256.0f);
        }
    }
}