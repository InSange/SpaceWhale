using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    #region instance;
    public static PlayerMove instance; // 스태틱 밸류는 모든 클래스의 인스턴스와 공유된다.
    private void Awake()
    {
        if (instance != null) // 인스턴스가 이미 존재한다면 해당 오브젝트는 파괴. 씬 이동이 되었는데 그 씬에도 플레이어가 존재할 수도 있기때문에.
        {
            Destroy(gameObject);
            return;
        }
        instance = this; // 이 클래스 인스턴스가 생성되었을때 전역변수 인스턴스에 플레이어 인스턴스가 담겨있지않다면, 자신을 넣어줌.
    }
    #endregion

    public int jumpforce;
    public Rigidbody2D rb;
    public Map map;
    public bool backBool = false;
    public int groundChecknum = 0;
    public bool isGodTime = false;
    GameObject D;
    SpriteRenderer spriteRenderer;
    AudioSource audioSource;
    public AudioClip SkillAudio;
    public AudioClip Hit;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        D = GameObject.FindWithTag("DistanceIcon");
    }
    void Update()
    {
        if(backBool)
        {
            StartCoroutine(back());
        }
        else
        {
            Move();
        }
        DistanceCheck();
        if (Player.p_instance.p_HP <= 0)
        {
            GameOver();
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow) && GameManager.instance.isPlay)
        {
            rb.AddForce(Vector2.up * jumpforce);
        }
        if (Input.GetKey(KeyCode.Space) && GameManager.instance.isPlay)
        {
            GameManager.instance.gameSpeed = 10;
        }
        if (Input.GetKeyUp(KeyCode.Space) && GameManager.instance.isPlay)
        {
            GameManager.instance.gameSpeed = 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) && GameManager.instance.isPlay)
        {
            audioSource.clip = SkillAudio;
            audioSource.Play();
            Player.p_instance.Skill();
        }
        if (Input.GetKeyDown(KeyCode.H) && GameManager.instance.isPlay)
        {
            Player.p_instance.p_HP = 100;
        }
    }

    IEnumerator back()
    {
        GameManager.instance.gameSpeed = -1f;
        if (groundChecknum == 1)
        {
            rb.AddForce(Vector2.up * 23f);
        }
        else if(groundChecknum == 2)
        {
            rb.AddForce(Vector2.up * 20f);
        }
        else if(groundChecknum == 3)
        {
            rb.AddForce(Vector2.up * 21f);
        }
        yield return new WaitForSeconds(1.5f);
        GameManager.instance.gameSpeed = 1f;
        backBool = false;
    }

    public IEnumerator GodTime()
    {
        int countTime = 0;
        while(countTime < 10)
        {
            if(countTime%2 == 0)
            {
                spriteRenderer.color = new Color32(255, 255, 255, 90);
            }
            else
            {
                spriteRenderer.color = new Color32(255, 255, 255, 180);
            }

            yield return new WaitForSeconds(0.2f);
            countTime++;
        }
        spriteRenderer.color = new Color32(255, 255, 255, 255);

        isGodTime = false;
        yield return null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TopGround") && !isGodTime)
        {
            if (Player.p_instance.sheild == 0)
            {
                audioSource.clip = Hit;
                audioSource.Play();
                if (Player.p_instance.p_HP > 0)
                {
                    Player.p_instance.p_HP -= 20;
                }
                if(Player.p_instance.p_HP < 0)
                {
                    Player.p_instance.p_HP = 0;
                }
                Debug.Log("Top충돌감지!");
                backBool = true;
                groundChecknum = 2;
                isGodTime = true;
                StartCoroutine(GodTime());
            }
            else
            {
                Player.p_instance.sheild -= 1;
                Player.p_instance.sheild_bubble.SetActive(false);
                backBool = true;
                groundChecknum = 2;
                isGodTime = true;
                StartCoroutine(GodTime());
                Debug.Log("방어!");
            }
        }
        else if (collision.gameObject.CompareTag("UnderGround") && !isGodTime)
        {
            if (Player.p_instance.sheild == 0)
            {
                audioSource.clip = Hit;
                audioSource.Play();
                if (Player.p_instance.p_HP > 0)
                {
                    Player.p_instance.p_HP -= 20;
                }
                if (Player.p_instance.p_HP < 0)
                {
                    Player.p_instance.p_HP = 0;
                }
                Debug.Log("Under충돌감지!");
                backBool = true;
                groundChecknum = 1;
                isGodTime = true;
                StartCoroutine(GodTime());
            }
            else
            {
                Player.p_instance.sheild -= 1;
                Player.p_instance.sheild_bubble.SetActive(false);
                backBool = true;
                groundChecknum = 1;
                isGodTime = true;
                StartCoroutine(GodTime());
                Debug.Log("방어!");
            }
        }
        else if (collision.gameObject.CompareTag("middleObject") && !isGodTime)
        {
            if (Player.p_instance.sheild == 0)
            {
                audioSource.clip = Hit;
                audioSource.Play();
                if (Player.p_instance.p_HP > 0)
                {
                    Player.p_instance.p_HP -= 20;
                }
                if (Player.p_instance.p_HP < 0)
                {
                    Player.p_instance.p_HP = 0;
                }
                Debug.Log("middle충돌감지!");
                backBool = true;
                groundChecknum = 3;
                isGodTime = true;
                StartCoroutine(GodTime());
            }
            else
            {
                Player.p_instance.sheild -= 1;
                Player.p_instance.sheild_bubble.SetActive(false);
                backBool = true;
                groundChecknum = 3;
                isGodTime = true;
                StartCoroutine(GodTime());
                Debug.Log("방어!");
            }
        }
        else if(collision.gameObject.CompareTag("Treasure_pile"))
        {
            Debug.Log("보물 획득!!");
            rb.simulated = false;
            GameManager.instance.isPlay = false;
            Invoke("Clear", 1.5f);
        }

    }
    void Clear()
    {
        SceneManager.LoadScene("GameClear");
    }

    void DistanceCheck()
    {
        D.GetComponent<Distance>().DistanceCALL();
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}