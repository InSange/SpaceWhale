using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarTest : MonoBehaviour
{
    //public Player Player;
    Vector3 PlayerPosition = new Vector3(0,-0.7f,0); // 체력바를 플레이어 오브젝트 밑에 표시하기위하여 playerPosition설정
    public Camera Cam;

    public Image Img; // hpBar 이미지
    void Update()
    {
        if (Player.p_instance.p_HP > 0 && GameManager.instance.isPlay) //플레이어의 체력이 0보다크고 게임 플레이가 활성화 되어있을때 실행.
        {
            Player.p_instance.p_HP -= 3*Time.deltaTime; // 게임이 진행될수록(시간이 흐를수록) 플레이어 체력이 점점깎임
            Img.fillAmount = Player.p_instance.p_HP / Player.p_instance.HP; // hp바의 fillAmount로 비율을 나타냄. 비율값은 현재체력(p_HP)/최대체력(HP : 100) 
        }
        // 체력바는 월드좌표에서 화면좌표로 바뀌면서 플레이어의 위치 아래에다가 두게만들었다. Update문에 넣어서 바뀌는 위치값을 매번 조정해줌.
        transform.position = Cam.WorldToScreenPoint(Player.p_instance.transform.position + PlayerPosition);

    }
}