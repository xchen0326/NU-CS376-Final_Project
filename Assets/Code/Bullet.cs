using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        bullet = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (bullet.transform.localScale.x > 0)
        {
            bullet.transform.position = new Vector2(bullet.transform.position.x + 0.05f, bullet.transform.position.y);
        }
        else
        {
            bullet.transform.position = new Vector2(bullet.transform.position.x - 0.05f, bullet.transform.position.y);
        }

        if (bullet.transform.position.x <= -9.35f || bullet.transform.position.x >= 9.35f)
        {
            Destroy(bullet);
        }
    }
}
