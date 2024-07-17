using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public int x, y, z;
    public void Initialize(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public bool CompareIndexes(int x, int y, int z)
    {
        return this.x == x && this.y == y && this.z == z;
    }
}
