using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public List<GameObject> itemPool = new List<GameObject>();

    public GameObject[] items;
    public int objCnt;

    private void Awake()
    {
        for(int i = 0; i<items.Length; i++) // items.Length -> 2 hpitem, crystal �����ճ־��.
        {
            for (int q = 0; q < objCnt; q++)    // �� 4���� ������Ǯ �߰�
            {
                itemPool.Add(CreateObj(items[i]));
            }
        }
    }
    private void Start()
    {
        GameManager.instance.onPlay += PlayGame; //��������Ʈ ��ü�� onPlay�� PlayGame�Լ� �߰�.
    }

    void PlayGame()
    {
        StartCoroutine(CreateMob());
    }
    IEnumerator CreateMob()
    {
        while (GameManager.instance.isPlay) //���ӸŴ��� isPlay�� true�Ͻ� ��� ����.
        {
            itemPool[DeactiveMob()].SetActive(true);
            yield return new WaitForSeconds(Random.Range(3f, 5f)); // 3~5�� ��ٸ�.
        }
    }

    int DeactiveMob()
    {
        List<int> num = new List<int>();
        for(int i = 0; i < itemPool.Count; i++) 
        {
            if (!itemPool[i].activeSelf) // i��° itemPool�� Ȱ�����°� false�� �� ����.
            {//gameObject�� setActive(false) ������ ���
                num.Add(i);
                int py = Random.Range(-4, 4); //������Ʈ ���� ��ġ y��.
                //i��° itemPool��ü�� ��ġ�� �Ʒ��� ����.(RespawnManager ��ũ��Ʈ�� ���� ���ӿ�����Ʈ�� x��, py, 0)
                itemPool[i].transform.position = new Vector3(gameObject.transform.position.x, py, 0);
            }
        }
        int x = 0;
        if (num.Count > 0) //num list�� i��° ������ setActive false�ɶ����� ���ŵǰ� ���� �ϳ��� �����ϰ� ����.
            x = num[Random.Range(0, num.Count)];
        return x;
    }
    GameObject CreateObj(GameObject obj)
    {
        // ������ �ν��Ͻ�ȭ.
        GameObject copy = Instantiate(obj);
        copy.SetActive(false);
        return copy;
    }
}
