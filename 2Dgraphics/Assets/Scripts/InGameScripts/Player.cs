using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region instance;
    public static Player p_instance; // 스태틱 밸류는 모든 클래스의 인스턴스와 공유된다.
    private void Awake()
    {
        if (p_instance != null) // Player 인스턴스가 이미 존재한다면 해당 오브젝트는 파괴. 씬 이동이 되었는데 그 씬에도 플레이어가 존재할 수도 있기때문에.
        {
            Destroy(gameObject);
            return;
        }
        p_instance = this; // 이 클래스 인스턴스가 생성되었을때 전역변수 인스턴스에 플레이어 인스턴스가 담겨있지않다면, 자신을 넣어줌.
    }
    #endregion

    public float HP;   // 플레이어 최대 체력
    public float p_HP; // 플레이어 현재 체력
    public int sheild; // 보호막
    public int crystal; // 수정
    public GameObject sheild_bubble; //쉴드가 활성화되었을때 보여줄 쉴드이미지

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
            Debug.Log("쉴드생성!!");
            crystal -= 1;
            sheild += 1;
            sheild_bubble.SetActive(true);
        }
    }
}