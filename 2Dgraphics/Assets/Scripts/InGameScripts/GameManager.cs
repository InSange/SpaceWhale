using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region instance
    public static GameManager instance; // ����ƽ ����� ��� Ŭ������ �ν��Ͻ��� �����ȴ�.
    private void Awake()
    {
        if(instance != null) // �ν��Ͻ��� �̹� �����Ѵٸ� �ش� ������Ʈ�� �ı�. �� �̵��� �Ǿ��µ� �� ������ �÷��̾ ������ ���� �ֱ⶧����.
        {
            Destroy(gameObject);
            return;
        }
        instance = this; // �� Ŭ���� �ν��Ͻ��� �����Ǿ����� �������� �ν��Ͻ��� �÷��̾� �ν��Ͻ��� ��������ʴٸ�, �ڽ��� �־���.
    }
    #endregion

    public delegate void OnPlay(); // ��������Ʈ�� �Լ����� ����ϴ� ����Ʈ, ��� -> �Լ� �����͸� ������ �־ ����� �Լ��� ����Ű�Ե�.
    public OnPlay onPlay; // ��������Ʈ ������Ʈ onPlay���� -> ������ �Ŵ������� �Լ��� �߰�����.
    public float gameSpeed = 1; // ��ü ������Ʈ�� ��������ӵ��� GameManager���� �Ҵ��Ѵ�.
    public bool isPlay = false;
    public GameObject playBtn;
    AudioSource audioSource;
    public AudioClip CountDown;
    public AudioClip ButtonDown;
    public AudioClip InGameSound;

    //CountDown�ҽ�
    public GameObject Num_1;
    public GameObject Num_2;
    public GameObject Num_3;
    public GameObject Num_Go;

    //GameClear ������Ʈ

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
        onPlay.Invoke(); // �Լ� ���� �ð��� ������Ű�� ���.
        PlayerMove.instance.rb.simulated = true;
    }
}
