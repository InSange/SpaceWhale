using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region instance
    public static GameManager instance; // 스태틱 밸류는 모든 클래스의 인스턴스와 공유된다.
    private void Awake()
    {
        if(instance != null) // 인스턴스가 이미 존재한다면 해당 오브젝트는 파괴. 씬 이동이 되었는데 그 씬에도 플레이어가 존재할 수도 있기때문에.
        {
            Destroy(gameObject);
            return;
        }
        instance = this; // 이 클래스 인스턴스가 생성되었을때 전역변수 인스턴스에 플레이어 인스턴스가 담겨있지않다면, 자신을 넣어줌.
    }
    #endregion

    public delegate void OnPlay(); // 델리게이트는 함수들을 등록하는 리스트, 명단 -> 함수 포인터를 가지고 있어서 등록한 함수를 가리키게됨.
    public OnPlay onPlay; // 델리게이트 오브젝트 onPlay생성 -> 리스폰 매니저에서 함수를 추가해줌.
    public float gameSpeed = 1; // 전체 오브젝트의 게임진행속도는 GameManager에서 할당한다.
    public bool isPlay = false;
    public GameObject playBtn;
    AudioSource audioSource;
    public AudioClip CountDown;
    public AudioClip ButtonDown;
    public AudioClip InGameSound;

    //CountDown소스
    public GameObject Num_1;
    public GameObject Num_2;
    public GameObject Num_3;
    public GameObject Num_Go;

    //GameClear 오브젝트

    private void Start()
    {
        Num_1.SetActive(false);
        Num_2.SetActive(false);
        Num_3.SetActive(false);
        Num_Go.SetActive(false);
        this.audioSource = GetComponent<AudioSource>();
    }

    public void PlayBtnClick()
    {
        audioSource.clip = ButtonDown;
        audioSource.Play();
        playBtn.SetActive(false);
        StartCoroutine(Ready());
    }

    IEnumerator Ready()
    {
        int count = 4;
        audioSource.clip = CountDown;
        audioSource.Play();
        while (count!= 0)
        {
            count--;
            if(count == 3)
            {
                Num_3.SetActive(true);
            }
            else if(count == 2)
            {
                Num_3.SetActive(false);
                Num_2.SetActive(true);
            }
            else if(count == 1)
            {
                Num_2.SetActive(false);
                Num_1.SetActive(true);
            }
            else if(count == 0)
            {
                Num_1.SetActive(false);
                Num_Go.SetActive(true);
            }
            Debug.Log(count);
            yield return new WaitForSeconds(1f);
        }
        Num_Go.SetActive(false);
        audioSource.clip = InGameSound;
        audioSource.Play();
        isPlay = true;
        onPlay.Invoke(); // 함수 시작 시간을 지연시키는 기능.
        PlayerMove.instance.rb.simulated = true;
    }
}
