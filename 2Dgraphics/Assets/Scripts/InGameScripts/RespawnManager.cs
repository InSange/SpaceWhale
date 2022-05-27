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
        for(int i = 0; i<items.Length; i++) // items.Length -> 2 hpitem, crystal 프리팹넣어둠.
        {
            for (int q = 0; q < objCnt; q++)    // 총 4개의 아이템풀 추가
            {
                itemPool.Add(CreateObj(items[i]));
            }
        }
    }
    private void Start()
    {
        GameManager.instance.onPlay += PlayGame; //델리게이트 객체인 onPlay에 PlayGame함수 추가.
    }

    void PlayGame()
    {
        StartCoroutine(CreateMob());
    }
    IEnumerator CreateMob()
    {
        while (GameManager.instance.isPlay) //게임매니저 isPlay가 true일시 계속 수행.
        {
            itemPool[DeactiveMob()].SetActive(true);
            yield return new WaitForSeconds(Random.Range(3f, 5f)); // 3~5초 기다림.
        }
    }

    int DeactiveMob()
    {
        List<int> num = new List<int>();
        for(int i = 0; i < itemPool.Count; i++) 
        {
            if (!itemPool[i].activeSelf) // i번째 itemPool의 활성상태가 false일 때 실행.
            {//gameObject가 setActive(false) 상태일 경우
                num.Add(i);
                int py = Random.Range(-4, 4); //오브젝트 랜덤 위치 y값.
                //i번째 itemPool객체의 위치는 아래와 같다.(RespawnManager 스크립트를 지닌 게임오브젝트의 x값, py, 0)
                itemPool[i].transform.position = new Vector3(gameObject.transform.position.x, py, 0);
            }
        }
        int x = 0;
        if (num.Count > 0) //num list의 i번째 값들은 setActive false될때마다 갱신되고 그중 하나를 랜덤하게 보냄.
            x = num[Random.Range(0, num.Count)];
        return x;
    }
    GameObject CreateObj(GameObject obj)
    {
        // 프리팹 인스턴스화.
        GameObject copy = Instantiate(obj);
        copy.SetActive(false);
        return copy;
    }
}
