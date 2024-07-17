using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ClickIndex : MonoBehaviour
{
    public float raycastMaxDistance = 100f;
    public LayerMask layerMask;
    int indexX;
    int indexY;
    int indexZ;
    public GenerateCube generateCube;
    Vector2 firstMousePos;
    Vector2 secondMousePos;
    

    public IEnumerator RotateX(int indexX, bool isPositive)
    {
        List<Piece> turnPieces = new List<Piece>();
        
        var newParent = new GameObject();
        newParent.transform.position = Vector3.zero;
        for (int z = 0; z < generateCube.cubeSize; z++)
        {
            for (int y = 0; y < generateCube.cubeSize; y++)
            {
                var a = generateCube.pieces[indexX, y, z].transform;
                a.SetParent(newParent.transform);
                turnPieces.Add(generateCube.pieces[indexX, y, z]);
            }
        }
        Quaternion quaternion = Quaternion.Euler(isPositive ? 90 : -90, 0f, 0f);



        for (var i = 0f; i < generateCube.rotationTime; i += Time.deltaTime)
        {
            newParent.transform.rotation = Quaternion.Lerp(newParent.transform.rotation, quaternion, Time.deltaTime * 15);
            yield return null;
        }
        newParent.transform.rotation = quaternion;
        ReSetParent();
        Destroy(newParent.gameObject);
        generateCube.InitializeXIndexes(isPositive, turnPieces);
    }
    public IEnumerator RotateY(int indexY, bool isPositive)
    {
        List<Piece> turnPieces = new List<Piece>();
        
        var newParent = new GameObject();
        newParent.transform.position = Vector3.zero;
        for (int z = 0; z < generateCube.cubeSize; z++)
        {
            for (int x = 0; x < generateCube.cubeSize; x++)
            {
                generateCube.pieces[x, indexY, z].transform.SetParent(newParent.transform);
                turnPieces.Add(generateCube.pieces[x, indexY, z]);
            }
        }
        Quaternion quaternion = Quaternion.Euler(0f, isPositive ? 90 : -90, 0f);

        for (var i = 0f; i < generateCube.rotationTime; i += Time.deltaTime)
        {
            newParent.transform.rotation = Quaternion.Lerp(newParent.transform.rotation, quaternion, Time.deltaTime * 15);
            yield return null;
        }
        newParent.transform.rotation = quaternion;
        ReSetParent();
        Destroy(newParent.gameObject);
        generateCube.InitializeYIndexes(isPositive, turnPieces);
    }
    public IEnumerator RotateZ(int indexZ, bool isPositive)
    {
        List<Piece> turnPieces = new List<Piece>();
        
        var newParent = new GameObject();
        newParent.transform.position = Vector3.zero;
        for (int x = 0; x < generateCube.cubeSize; x++)
        {
            for (int y = 0; y < generateCube.cubeSize; y++)
            {
                generateCube.pieces[x, y, indexZ].transform.SetParent(newParent.transform);
                turnPieces.Add(generateCube.pieces[x, y, indexZ]);
            }
        }
        Quaternion quaternion = Quaternion.Euler(0f, 0f, isPositive ? 90 : -90);

        for (var i = 0f; i < generateCube.rotationTime; i += Time.deltaTime)
        {
            newParent.transform.rotation = Quaternion.Lerp(newParent.transform.rotation, quaternion, Time.deltaTime * 15);
            yield return null;
        }
        newParent.transform.rotation = quaternion;
        ReSetParent();
        Destroy(newParent.gameObject);
        generateCube.InitializeZIndexes(isPositive, turnPieces);
    }
    public void ReSetParent() { 
        GameObject cubeParent = GameObject.Find("Cube");
        cubeParent.transform.position = Vector3.zero;

        for (int z = 0; z < generateCube.cubeSize; z++)
        {
            for (int y = 0; y < generateCube.cubeSize; y++)
            {
                for (int x = 0; x < generateCube.cubeSize; x++)
                    generateCube.pieces[x, y, z].transform.SetParent(cubeParent.transform);
            }
        }
    }
    public void PieceDetec()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, raycastMaxDistance))
        {
            Piece piece = hit.collider.GetComponent<Piece>();

            indexX = piece.x;
            indexY = piece.y;
            indexZ = piece.z;
            Debug.DrawRay(ray.origin, ray.direction * raycastMaxDistance, Color.red, 2f);

        }
    }
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            StartCoroutine(RotateX(0, true));
        if (Input.GetKeyDown(KeyCode.Q))
            StartCoroutine(RotateX(0, false));
        if (Input.GetKeyDown(KeyCode.Alpha2))
            StartCoroutine(RotateX(1, true));
        if (Input.GetKeyDown(KeyCode.W))
            StartCoroutine(RotateX(1, false));
        if (Input.GetKeyDown(KeyCode.Alpha3))
            StartCoroutine(RotateX(2, true));
        if (Input.GetKeyDown(KeyCode.E))
            StartCoroutine(RotateX(2, false));
        if (Input.GetKeyDown(KeyCode.Alpha4))
            StartCoroutine(RotateY(0, true));
        if (Input.GetKeyDown(KeyCode.R))
            StartCoroutine(RotateY(0, false));
        if (Input.GetKeyDown(KeyCode.Alpha5))
            StartCoroutine(RotateY(1, true));
        if (Input.GetKeyDown(KeyCode.T))
            StartCoroutine(RotateY(1, false));
        if (Input.GetKeyDown(KeyCode.Alpha6))
            StartCoroutine(RotateY(2, true));
        if (Input.GetKeyDown(KeyCode.Y))
            StartCoroutine(RotateY(2, false));
        if (Input.GetKeyDown(KeyCode.Alpha7))
            StartCoroutine(RotateZ(0, true));
        if (Input.GetKeyDown(KeyCode.U))
            StartCoroutine(RotateZ(0, false));
        if (Input.GetKeyDown(KeyCode.Alpha8))
            StartCoroutine(RotateZ(1, true));
        if (Input.GetKeyDown(KeyCode.I))
            StartCoroutine(RotateZ(1, false));
        if (Input.GetKeyDown(KeyCode.Alpha9))
            StartCoroutine(RotateZ(2, true));
        if (Input.GetKeyDown(KeyCode.O))
            StartCoroutine(RotateZ(2, false));
    }
    void FaceSwipe()
    {

        if (Input.GetMouseButtonDown(0))
        {
            firstMousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            PieceDetec();
            secondMousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            var currentswipe = new Vector2(secondMousePos.x - firstMousePos.x, secondMousePos.y - firstMousePos.y);
            currentswipe.Normalize();

            int angle = -90;

            if (currentswipe.x < 0)

                angle = 90;

            if (LeftSwipe(currentswipe))
            {
                StartCoroutine(RotateY(indexY, false));
            }
            else if (RightSwipe(currentswipe))
            {
                StartCoroutine(RotateY(indexY, true));
            }
        }
    }

    bool LeftSwipe(Vector2 swipe)
    {
        return swipe.x < 0 && swipe.y > -0.5f && swipe.y < 0.5f;
    }

    bool RightSwipe(Vector2 swipe)
    {
        return swipe.x > 0 && swipe.y > -0.5f && swipe.y < 0.5f;
    }
}
