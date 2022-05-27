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

    //�������̴�. time�� 0���� �����صΰ� ������ Ȱ��ȭ �ɶ� �ð��� deltaTime���� �߰��Ѵ�. �߰��� time���� ��� �������� ��,�ʸ� ������ �и���������� ���Ѵ�.
    void Update()
    {
        if (GameManager.instance.isPlay)
        {
            time += Time.deltaTime;
            m = (int)time / 60;
            s = (int)time % 60;
            ms = (time % 1) * 100;
            ScoreD += 10 * GameManager.instance.gameSpeed * Time.deltaTime; // ������ �Ÿ����̰� �ð��� �带���� ���ӽ��ǵ忡 ���� ������ �ö󰣴�.
            this.gameObject.GetComponent<Text>().text = "Score : " + ScoreD.ToString("F1") + "m \nTime : " + m.ToString() + ":" + s.ToString() + ":" + ((int)ms).ToString();
        }
    }
}
