using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPitem : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TopGround"))
        {
            this.gameObject.SetActive(false);
            Debug.Log("Ontrigger탑그라운드에서 없어졋다");
        }
        else if (collision.gameObject.CompareTag("UnderGround"))
        {
            this.gameObject.SetActive(false);
            Debug.Log("Ontrigger언더그라운드에서 없어졋다");
        }
        else if (collision.gameObject.CompareTag("middleObject"))
        {
            this.gameObject.SetActive(false);
            Debug.Log("middleObject미들오브젝트에서 없어졋다");
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            Player.p_instance.p_HP += 50;
            if(Player.p_instance.p_HP > 100)
            {
                Player.p_instance.p_HP = 100;
            }
            Debug.Log("Ontrigger플레이어랑 충돌했다");
        }
    }

    private void Update()
    {
        if (transform.position.x < -10)
        {
            gameObject.SetActive(false);
        }
    }
}
