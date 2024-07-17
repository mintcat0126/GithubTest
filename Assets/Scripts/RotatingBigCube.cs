using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class RotatingBigCube : MonoBehaviour
{

    Vector2 firstPressPos;
    Vector2 secondPressPos;

    public GenerateCube generateCube;

    public GameObject target;

    float speed = 200f;

    public ClickIndex clickIndex;

    void Start()
    {

    }


    void Update()
    {
        Swipe();

        if (transform.rotation != target.transform.rotation)
        {
            var step = speed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, step);
        }

    }


    void Swipe()
    {
        if (Input.GetMouseButtonDown(1))
        {
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(1))
        {
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            var currentswipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            currentswipe.Normalize();


            if (LeftSwipe(currentswipe))
            {
                target.transform.Rotate(0, 90, 0, Space.World);
                generateCube.InitializeYIndexes(true);
            }
            else if (RightSwipe(currentswipe))
            {
                target.transform.Rotate(0, -90, 0, Space.World);
                generateCube.InitializeYIndexes(false);
            }
            else if (UpLeftSwipe(currentswipe))
            {
                target.transform.Rotate(0, 0, 90, Space.World);
                generateCube.InitializeZIndexes(true);
            }
            else if (UpRightSwipe(currentswipe))
            {
                target.transform.Rotate(90, 0, 0, Space.World);
                generateCube.InitializeXIndexes(true);
            }
            else if (DownLeftSwipe(currentswipe))
            {
                target.transform.Rotate(-90, 0, 0, Space.World);
                generateCube.InitializeXIndexes(false);
            }
            else if (DownRightSwipe(currentswipe))
            {
                target.transform.Rotate(0, 0, -90, Space.World);
                     generateCube.InitializeZIndexes(false);
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

    bool UpLeftSwipe(Vector2 swipe)
    {
        return swipe.y > 0 && swipe.x < 0f;
    }

    bool UpRightSwipe(Vector2 swipe)
    {
        return swipe.y > 0 && swipe.x > 0f;
    }

    bool DownLeftSwipe(Vector2 swipe)
    {
        return swipe.y < 0 && swipe.x < 0f;
    }

    bool DownRightSwipe(Vector2 swipe)
    {
        return swipe.y < 0 && swipe.x > 0f;
    }

}
