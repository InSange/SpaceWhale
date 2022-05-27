using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    float ScoreD = 0;
    float time = 0;
    int m;
    int s;
    float ms;

    //점수판이다. time을 0으로 설정해두고 게임이 활성화 될때 시간을 deltaTime으로 추가한다. 추가한 time에서 몫과 나머지로 분,초를 나누고 밀리세컨드까지 구한다.
    void Update()
    {
        if (GameManager.instance.isPlay)
        {
            time += Time.deltaTime;
            m = (int)time / 60;
            s = (int)time % 60;
            ms = (time % 1) * 100;
            ScoreD += 10 * GameManager.instance.gameSpeed * Time.deltaTime; // 점수는 거리값이고 시간이 흐를수록 게임스피드에 따라 점수가 올라간다.
            this.gameObject.GetComponent<Text>().text = "Score : " + ScoreD.ToString("F1") + "m \nTime : " + m.ToString() + ":" + s.ToString() + ":" + ((int)ms).ToString();
        }
    }
}
