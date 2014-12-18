using UnityEngine;
using System.Collections;

namespace UnityUtilities
{
    public static class MathE
    {
        public static float Map(float value, float min1, float max1, float min2, float max2)
        {
            if (Mathf.Abs(max1 - min1) < Mathf.Epsilon)
            {
                Debug.LogWarning("MathE.Map(): Potential divide by zero. Check the min1: " + min1 + " and max1: " + max1 +
                    "\n returning min2");
                return min2;
            }

            return (value - min1) / (max1 - min1) * (max2 - min2) + min2;
        }

        public static float MapAndClamp(float value, float min1, float max1, float min2, float max2)
        {
            var mappedValue = Map(value, min1, max1, min2, max2);

            if (min2 < max2)
            {
                return Mathf.Clamp(mappedValue, min2, max2);
            }

            return Mathf.Clamp(mappedValue, max2, min2);
        }

        public static float Normalize(float value, float min, float max)
        {
            return Mathf.Clamp01((value - min) / (max - min));
        }

        public static int GetByteFromNormalizedFloat(float normalizedValue)
        {
            return (int)Mathf.Floor(Mathf.Approximately(normalizedValue, 1.0f) ? 255 : normalizedValue * 256.0f);
        }
    }
}