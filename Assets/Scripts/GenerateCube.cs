using System;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCube : MonoBehaviour
{

    public Piece piecePrefab;

    public Piece[,,] pieces;

    public int cubeSize;

    public float rotationTime;

    Vector2 firstMousePos;
    Vector2 secondMousePos;


    private void CreateCube()
    {
        pieces = new Piece[cubeSize, cubeSize, cubeSize];
        for (int z = 0; z < cubeSize; z++)
        {
            for (int y = 0; y < cubeSize; y++)
            {
                for (int x = 0; x < cubeSize; x++)
                {
                    Piece piece = Instantiate(piecePrefab, transform);
                    pieces[x, y, z] = piece;
                    piece.transform.localPosition
                    = new Vector3(x - cubeSize * 0.5f + 0.5f, y - cubeSize * 0.5f + 0.5f, z - cubeSize * 0.5f + 0.5f);
                    piece.Initialize(x, y, z);
                }
            }
        }
    }




    public void InitializeXIndexes(bool isPositive, List<Piece> turnPieces = null)
    {
        int newY = 0;
        int newZ = 0;
        var newPieces = new Piece[cubeSize, cubeSize, cubeSize];
        Array.Copy(pieces, newPieces, pieces.Length);
        for (int z = 0; z < cubeSize; z++)
        {
            for (int y = 0; y < cubeSize; y++)
            {
                for (int x = 0; x < cubeSize; x++)
                {
                    if (turnPieces == null || turnPieces.Exists(piece => piece.CompareIndexes(x, y, z)))
                    {
                        if (isPositive)
                        {
                            newY = cubeSize - z - 1;
                            newZ = y;
                        }
                        else
                        {
                            newY = z;
                            newZ = cubeSize - y - 1;
                        }                   
                        Piece piece = pieces[x, y, z];
                        newPieces[x, newY, newZ] = piece;
                        piece.Initialize(x, newY, newZ);
                        Debug.Log(x + ", " + newY + ", " + newZ + " / " + piece.x + ", " + piece.y + ", " + piece.z);
                    }
                }
            }
        }
        pieces = newPieces;
    }
    public void InitializeYIndexes(bool isPositive, List<Piece> turnPieces = null)
    {
        int newX = 0;
        int newZ = 0;
        var newPieces = new Piece[cubeSize, cubeSize, cubeSize];
        Array.Copy(pieces, newPieces, pieces.Length);
        for (int z = 0; z < cubeSize; z++)
        {
            for (int y = 0; y < cubeSize; y++)
            {
                for (int x = 0; x < cubeSize; x++)
                {
                    if (turnPieces == null || turnPieces.Exists(piece => piece.CompareIndexes(x, y, z)))
                    {
                        if (isPositive)
                        {
                            newX = cubeSize - z - 1;
                            newZ = x;
                        }
                        else
                        {
                            newX = z;
                            newZ = cubeSize - x - 1;
                        }

                        Piece piece = pieces[x, y, z];
                        newPieces[newX, y, newZ] = piece;
                        piece.Initialize(newX, y, newZ);
                        Debug.Log(newX + ", " + y + ", " + newZ + " / " + piece.x + ", " + piece.y + ", " + piece.z);
                    }
                }
            }
        }
        pieces = newPieces;
    }


    public void InitializeZIndexes(bool isPositive, List<Piece> turnPieces = null)
    {
        int newX = 0;
        int newY = 0;
        var newPieces = new Piece[cubeSize, cubeSize, cubeSize];
        Array.Copy(pieces, newPieces, pieces.Length);
        for (int z = 0; z < cubeSize; z++)
        {
            for (int y = 0; y < cubeSize; y++)
            {
                for (int x = 0; x < cubeSize; x++)
                {
                    if (turnPieces == null || turnPieces.Exists(piece => piece.CompareIndexes(x, y, z)))
                    {
                        if (isPositive)
                        {
                            newY = cubeSize - x - 1;
                            newX = y;
                        }
                        else
                        {
                            newY = x;
                            newX = cubeSize - y - 1;
                        }

                        Piece piece = pieces[x, y, z];
                        newPieces[newX, newY, z] = piece;
                        piece.Initialize(newX, newY, z);
                        Debug.Log(newX + ", " + newY + ", " + z + " / " + piece.x + ", " + piece.y + ", " + piece.z);
                    }
                }
            }
        }
        pieces = newPieces;
    }

    void Start()
    {
        CreateCube();
    }

    void Update()
    {
        
    }

}

