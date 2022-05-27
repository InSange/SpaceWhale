using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    //public float speed;
    //public GameObject obstacle;
    void Update()
    {
        //obstacle.transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
        if (GameManager.instance.isPlay)
        {
            transform.Translate(-1 * GameManager.instance.gameSpeed * Time.deltaTime, 0, 0);
        }
    }
}
