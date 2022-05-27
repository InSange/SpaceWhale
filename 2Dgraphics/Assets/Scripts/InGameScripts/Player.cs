using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region instance;
    public static Player p_instance; // ����ƽ ����� ��� Ŭ������ �ν��Ͻ��� �����ȴ�.
    private void Awake()
    {
        if (p_instance != null) // Player �ν��Ͻ��� �̹� �����Ѵٸ� �ش� ������Ʈ�� �ı�. �� �̵��� �Ǿ��µ� �� ������ �÷��̾ ������ ���� �ֱ⶧����.
        {
            Destroy(gameObject);
            return;
        }
        p_instance = this; // �� Ŭ���� �ν��Ͻ��� �����Ǿ����� �������� �ν��Ͻ��� �÷��̾� �ν��Ͻ��� ��������ʴٸ�, �ڽ��� �־���.
    }
    #endregion

    public float HP;   // �÷��̾� �ִ� ü��
    public float p_HP; // �÷��̾� ���� ü��
    public int sheild; // ��ȣ��
    public int crystal; // ����
    public GameObject sheild_bubble; //���尡 Ȱ��ȭ�Ǿ����� ������ �����̹���

    // Start is called before the first frame update
    void Start()
    {
        p_HP = HP;
        sheild_bubble = transform.Find("bubble").gameObject;
        if(sheild == 0)
        {
            sheild_bubble.SetActive(false);
        }
    }

    public void Skill()
    {
        if(crystal > 0 && sheild == 0)
        {
            Debug.Log("�������!!");
            crystal -= 1;
            sheild += 1;
            sheild_bubble.SetActive(true);
        }
    }
}