using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    public Rigidbody2D player;
    public float speed;
    public Transform jumpPoint;
    public float checkRadius;
    public float moveInput;
    public bool isGround;
    public float jumpForce;
    public bool isJumping;
    public float jumpTimeCounter;
    public LayerMask whatIsGround;
    public float jumpTime;
    public bool fireCondition = false;
    public GameObject firePrefab;
    public float rageTime;
    public GameObject bulletPrefab;
    public GameObject bombPrefab;
    public GameObject iceballPrefab;
    public AudioClip shoot;
    public AudioSource audioSrc;
    public float time = 0;
    private float timeInterval = 2f;
    private static Text resultT;
    public float curTime;
    public float newcurTime;

    void Start()
    {
        speed = 5f;
        player = this.gameObject.GetComponent<Rigidbody2D>();
        shoot = Resources.Load<AudioClip>("shoot");
        audioSrc = GetComponent<AudioSource>();
        audioSrc.volume = 0.2f;
        newcurTime = 0;
        //ScoreManager.UpdateText();
    }
    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        player.velocity = new Vector2(moveInput * speed, player.velocity.y);
    }

    void playSound(AudioClip ac)
    {
        audioSrc.clip = ac;
        audioSrc.Play();
    }

    void Update()
    {
        if (newcurTime <= 20)
        {
            curTime = newcurTime;
        }
        newcurTime += Time.deltaTime;
        ScoreManager.UpdateText();
        if ((moveInput < 0f && player.transform.localScale.x > 0) || (moveInput > 0f && player.transform.localScale.x < 0))
        {
            player.transform.localScale = new Vector3(player.transform.localScale.x * -1, 1, 1);
        }

        isGround = Physics2D.OverlapCircle(jumpPoint.position, checkRadius, whatIsGround);
        if (isGround && Input.GetKeyDown(KeyCode.W))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            player.velocity = Vector2.up * jumpForce;
        }

        if (isJumping && Input.GetKey(KeyCode.W))
        {
            if (jumpTimeCounter > 0)
            {
                player.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else isJumping = false;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
        }

        if (GameObject.Find("OnFire").GetComponent<SpriteRenderer>().enabled == true && Input.GetKeyDown(KeyCode.J))
        {
            if (OnFireHint.getCalm() <= 0f)
            {
                fireCondition = true;
            }
        }

        if (fireCondition)
        {
            foreach (var g in GameObject.FindGameObjectsWithTag("FireEye"))
            {
                g.GetComponent<SpriteRenderer>().enabled = true;
            }
            foreach (var g in GameObject.FindGameObjectsWithTag("NormalEye"))
            {
                g.GetComponent<SpriteRenderer>().enabled = false;
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (player.transform.localScale.x > 0)
                {
                    var f = Instantiate(firePrefab, new Vector2(player.transform.position.x + 1, player.transform.position.y), Quaternion.identity);
                }
                else
                {
                    var f = Instantiate(firePrefab, new Vector2(player.transform.position.x - 1, player.transform.position.y), Quaternion.identity);
                    f.transform.localScale *= -1;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (player.transform.localScale.x > 0)
                {
                    var b = Instantiate(bulletPrefab, new Vector2(player.transform.position.x + 1, player.transform.position.y), Quaternion.identity);
                }
                else
                {
                    var b = Instantiate(bulletPrefab, new Vector2(player.transform.position.x - 1, player.transform.position.y), Quaternion.identity);
                    b.transform.localScale *= -1;
                }
                playSound(shoot);
            }
        }
        if (fireCondition) {
            rageTime -= Time.deltaTime;
        }
        if (rageTime <= 0)
        {
            if (fireCondition)
            {
                GameObject.Find("OnFire").GetComponent<SpriteRenderer>().enabled = false;
            }
            fireCondition = false;

            foreach (var g in GameObject.FindGameObjectsWithTag("NormalEye"))
            {
                g.GetComponent<SpriteRenderer>().enabled = true;
            }
            foreach (var g in GameObject.FindGameObjectsWithTag("FireEye"))
            {
                g.GetComponent<SpriteRenderer>().enabled = false;
            }
            rageTime = 10;
            OnFireHint.resetCalm();
        }
        if (!fireCondition)
        {
            OnFireHint.deductCalm(Time.deltaTime);
        }

        float posX = 0f;
        if (Time.time >= time)
        {
            int selectObject = Random.Range(0, 2);
            int selectSpace = Random.Range(0, 4);
            if (selectSpace == 0)
            {
                posX = Random.Range(-8.67f, -6.99f);
            }
            if (selectSpace == 1)
            {
                posX = Random.Range(-6.99f, -4.39f);
            }
            if (selectSpace == 2)
            {
                posX = Random.Range(4.17f, 6.15f);
            }
            if (selectSpace == 3)
            {
                posX = Random.Range(6.15f, 8.8f);
            }
            if (selectObject == 0)
            {
                var b = Instantiate(bombPrefab, new Vector2(posX, 5.1f), Quaternion.identity);
            }
            else
            {
                var i = Instantiate(iceballPrefab, new Vector2(posX, 5.1f), Quaternion.identity);
            }
            int selectObject2 = Random.Range(0, 2);
            int selectSpace2 = Random.Range(0, 4);
            if (selectSpace2 == 0)
            {
                posX = Random.Range(-8.67f, -6.99f);
            }
            if (selectSpace2 == 1)
            {
                posX = Random.Range(-6.99f, -4.39f);
            }
            if (selectSpace2 == 2)
            {
                posX = Random.Range(4.17f, 6.15f);
            }
            if (selectSpace2 == 3)
            {
                posX = Random.Range(6.15f, 8.8f);
            }
            while (true)
            {
                if (selectSpace2 == selectSpace)
                {
                    selectSpace2 = Random.Range(0, 4);
                }
                else break;
            }
            if (selectObject2 == 0)
            {
                var b = Instantiate(iceballPrefab, new Vector2(posX, 5.1f), Quaternion.identity);
            }
            else
            {
                var i = Instantiate(iceballPrefab, new Vector2(posX, 5.1f), Quaternion.identity);
            }
            time = Time.time + timeInterval;
        }
        //Debug.Log(fireCondition);
        //Debug.Log(ScoreManager.getPoints());
        if (Input.GetKeyDown(KeyCode.I))
        {
            SaveData.SavePlayer(this);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            PlayData data = SaveData.LoadPlayer();
            player.transform.position = new Vector2(data.playerX, data.playerY);
            fireCondition = data.fireCondition;
            isGround = data.isGround;
            jumpTimeCounter = data.jumpTimeCounter;
            rageTime = data.rageTime;
            newcurTime =  data.curTime;
            //Debug.Log(curTime);
            //Debug.Log(newcurTime);
        }

        if (newcurTime >= 20f)
        {
            newcurTime = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
