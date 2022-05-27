using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    public float speed = 1.0f;
    public float startPosition = -12.0f;
    public float endPosition = 12.0f; 

    void Update()
    {
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);

        if(transform.position.x <= endPosition)
        {
            ScrollEnd();
        }
        Debug.Log("startPos : " + startPosition + "endPs : " + endPosition);
    }

    void ScrollEnd()
    {
        transform.Translate(-1*(endPosition - startPosition), 0, 0);
    }
}
