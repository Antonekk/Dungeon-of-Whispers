using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static List<Transform> GetChildrenList(Transform parent)
    {
        // Get the number of children
        int childCount = parent.childCount;

        // Create a list to store the children
        var childrenList = new List<Transform>();

        // Loop through each child and add it to the list
        for (int i = 0; i < childCount; i++)
        {
            Transform child = parent.GetChild(i);
            childrenList.Add(child);
        }

        return childrenList;
    }

    public static Tuple<int, int> CoordinatesOf<T>(T[,] matrix, T value)
    {
        int w = matrix.GetLength(0); // width
        int h = matrix.GetLength(1); // height

        for (int x = 0; x < w; ++x)
        {
            for (int y = 0; y < h; ++y)
            {
                if (value.Equals(matrix[x, y]))
                    return Tuple.Create(x, y);
            }
        }

        return Tuple.Create(-1, -1);
    }
}
