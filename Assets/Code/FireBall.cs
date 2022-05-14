using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject fb;
    void Start()
    {
        fb = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (fb.transform.localScale.x > 0)
        {
            fb.transform.position = new Vector2(fb.transform.position.x + 0.03f, fb.transform.position.y);
        }
        else
        {
            fb.transform.position = new Vector2(fb.transform.position.x - 0.03f, fb.transform.position.y);
        }

        if (fb.transform.position.x <= -9.35f || fb.transform.position.x >= 9.35f)
        {
            Destroy(fb);
        }
    }
}
