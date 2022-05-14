using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBall : MonoBehaviour
{
    GameObject iceball;
    private int remainingLife = 3;
    public AudioClip reward;
    public AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        iceball = this.gameObject;
        reward = Resources.Load<AudioClip>("reward");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        iceball.transform.position = new Vector2(iceball.transform.position.x, iceball.transform.position.y - 0.01f);

        if (iceball.transform.position.y <= -5.32f)
        {
            Destroy(iceball);
        }
    }

    void playSound(AudioClip ac)
    {
        audioSrc.clip = ac;
        audioSrc.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            remainingLife -= 2;
            //playSound(reward);
        }
        if (collision.collider.CompareTag("Fireball"))
        {
            remainingLife -= 3;
        }
        if (remainingLife <= 0)
        {
            ScoreManager.addPoints(1);
            playSound(reward);
            iceball.GetComponent<SpriteRenderer>().enabled = false;
            iceball.GetComponent<Collider2D>().enabled = false;
            Invoke("Destruct", 0.1f);
        }
    }

    private void Destruct()
    {
        Destroy(iceball);
    }
}
