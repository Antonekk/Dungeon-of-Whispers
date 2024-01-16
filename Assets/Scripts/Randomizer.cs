using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Randomizer : MonoBehaviour
{

    public static int RandomEnemies(int enemy_min, int enemy_max)
    {
        System.Random random = new System.Random();
        return random.Next(enemy_min, enemy_max+1);
    }
    public static T GetRandomElement<T>(List<T> list)
    {
        // Check if the list is not empty
        if (list.Count > 0)
        {
            // Use Random class to generate a random index
            System.Random random = new System.Random();
            int randomIndex = random.Next(0, list.Count);

            // Return the random element
            return list[randomIndex];
        }
        else
        {
            // Return the default value for type T if the list is empty
            return default;
        }
    }

    public static List<T> GetRandomPermutation<T>(List<T> list)
    {
        List<T> randomPermutation = new List<T>(list);

        // Use Fisher-Yates shuffle algorithm
        System.Random random = new System.Random();
        int n = randomPermutation.Count;

        for (int i = n - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            Swap(randomPermutation, i, j);
        }

        return randomPermutation;
    }

    static void Swap<T>(List<T> list, int i, int j)
    {
        T temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }

    public static bool RollD100(float value)
    {
        System.Random random = new System.Random();
        float num = random.Next(0, 100);
        return (num <= value);
      
    }

}
