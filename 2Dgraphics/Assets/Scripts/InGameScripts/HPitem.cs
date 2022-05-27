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
            Debug.Log("Ontriggerž�׶��忡�� �����");
        }
        else if (collision.gameObject.CompareTag("UnderGround"))
        {
            this.gameObject.SetActive(false);
            Debug.Log("Ontrigger����׶��忡�� �����");
        }
        else if (collision.gameObject.CompareTag("middleObject"))
        {
            this.gameObject.SetActive(false);
            Debug.Log("middleObject�̵������Ʈ���� �����");
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            Player.p_instance.p_HP += 50;
            if(Player.p_instance.p_HP > 100)
            {
                Player.p_instance.p_HP = 100;
            }
            Debug.Log("Ontrigger�÷��̾�� �浹�ߴ�");
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
