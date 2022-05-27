using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarTest : MonoBehaviour
{
    //public Player Player;
    Vector3 PlayerPosition = new Vector3(0,-0.7f,0); // ü�¹ٸ� �÷��̾� ������Ʈ �ؿ� ǥ���ϱ����Ͽ� playerPosition����
    public Camera Cam;

    public Image Img; // hpBar �̹���
    void Update()
    {
        if (Player.p_instance.p_HP > 0 && GameManager.instance.isPlay) //�÷��̾��� ü���� 0����ũ�� ���� �÷��̰� Ȱ��ȭ �Ǿ������� ����.
        {
            Player.p_instance.p_HP -= 3*Time.deltaTime; // ������ ����ɼ���(�ð��� �带����) �÷��̾� ü���� ��������
            Img.fillAmount = Player.p_instance.p_HP / Player.p_instance.HP; // hp���� fillAmount�� ������ ��Ÿ��. �������� ����ü��(p_HP)/�ִ�ü��(HP : 100) 
        }
        // ü�¹ٴ� ������ǥ���� ȭ����ǥ�� �ٲ�鼭 �÷��̾��� ��ġ �Ʒ����ٰ� �ΰԸ������. Update���� �־ �ٲ�� ��ġ���� �Ź� ��������.
        transform.position = Cam.WorldToScreenPoint(Player.p_instance.transform.position + PlayerPosition);

    }
}