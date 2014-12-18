using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace UnityUtilities
{
    public static class RandomE
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            var n = list.Count;

            while (n > 1)
            {
                n--;
                int k = Random.Range(0, n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static T RandomElement<T>(this IList<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }

        public static T RandomElement<T>(this T[] array)
        {
            return array[Random.Range(0, array.Length)];
        }

        public static T Choose<T>(params T[] items)
        {
            return items.RandomElement();
        }

        public static bool SplitChance()
        {
            return Random.Range(0, 2) == 0;
        }

        public static bool Chance(int probabilityFactor, int probabilitySpace)
        {
            return Random.Range(0, probabilitySpace) < probabilityFactor;
        }

        public static int InclusiveRange(int min, int max)
        {
            return Random.Range(min, max + 1);
        }
    }
}