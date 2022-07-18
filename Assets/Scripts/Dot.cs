using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    private Vector2 firstTouchPosition;
    private Vector2 finalTouchPosition;
    public float swipeAngle = 0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        firstTouchPosition = Camera.main.WorldToScreenPoint(Input.mousePosition);
        Debug.Log(firstTouchPosition);
    }

    private void OnMouseUp()
    {
        finalTouchPosition = Camera.main.WorldToScreenPoint(Input.mousePosition);
        Debug.Log(finalTouchPosition);
        CalculateAngle();
    }

    void CalculateAngle()
    {
        swipeAngle = Mathf.Atan2(finalTouchPosition.y - firstTouchPosition.y, finalTouchPosition.x - firstTouchPosition.x);
        Debug.Log(swipeAngle);
    }

    //private void DestroyMatchesAt(int column, int row)
    //{
    //    if(allDots[column, row].GetComponent<Dot>().isMatched())
    //    {
    //        Destroy(allDots[column, row]);
    //        allDots[column, row] = null;
    //    }
    //}
}
