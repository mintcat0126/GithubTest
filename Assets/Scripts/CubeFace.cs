using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFace : MonoBehaviour
{
    [SerializeField] private bool onX;
    [SerializeField] private bool onY;
    [SerializeField] private bool onZ;
    
    
    private void Update()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = Camera.main.farClipPlane;
        transform.localPosition = new Vector3(Input.mousePosition.x / 500, 0.5f, 0);
    }
}
