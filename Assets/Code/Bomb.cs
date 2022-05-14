using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    GameObject bomb;
    private int remainingLife = 3;
    public AudioClip reward;
    public AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        bomb = this.gameObject;
        reward = Resources.Load<AudioClip>("reward");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bomb.transform.position = new Vector2(bomb.transform.position.x, bomb.transform.position.y - 0.01f);

        if (bomb.transform.position.y <= -5.32f)
        {
            Destroy(bomb);
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
            remainingLife -= 1;
        }
        if (collision.collider.CompareTag("Fireball"))
        {
            remainingLife -= 3;
        }
        if (remainingLife <= 0)
        {
            ScoreManager.addPoints(2);
            playSound(reward);
            bomb.GetComponent<SpriteRenderer>().enabled = false;
            bomb.GetComponent<Collider2D>().enabled = false;
            Invoke("Destruct", 0.1f);
        }
    }

    private void Destruct()
    {
        Destroy(bomb);
    }
}
