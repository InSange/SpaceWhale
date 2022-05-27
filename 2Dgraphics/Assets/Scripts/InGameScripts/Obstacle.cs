using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //public Player player;
    public int damage = 10;
    //public int speed;
    /*
    public Vector2 StartPosition;

    private void OnEnable()
    {
        transform.position = StartPosition;
    }
    */

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TopGround"))
        {
            this.gameObject.SetActive(false);
            Debug.Log("Ontrigger탑그라운드에서 없어졋다");
        }
        if (collision.gameObject.CompareTag("UnderGround"))
        {
            this.gameObject.SetActive(false);
            Debug.Log("Ontrigger언더그라운드에서 없어졋다");
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            Debug.Log("Ontrigger플레이어랑 충돌했다");
        }
    }

    private void Update()
    {
        if (GameManager.instance.isPlay)
            transform.Translate(-1 * GameManager.instance.gameSpeed * Time.deltaTime, 0, 0);

        if(transform.position.x < -10)
        {
            gameObject.SetActive(false);
        }
    }
}
