using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoment : MonoBehaviour
{
    public float min;
    public float max;
    public SpriteRenderer sp;
    bool a=true;
    public HeadScript Head;
    public Animator anim;
    Rigidbody2D rg;
    public SoundManager S;
    public AudioClip Sound;
    float time1 = 0;
    // Start is called before the first frame update
    void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time1 >= 3)
        {
            S.Play(Sound);
            time1 = 0;
        }
        time1 = time1 + Time.deltaTime;
        if (Head.Hit==true)
        {
           
            rg.gravityScale = 1;
            anim.SetBool("Dead", true);
            Invoke("dead", 2);
        }
        else
        {
            if (transform.position.x <= max && a == false)
            {

                transform.Translate(new Vector2(1 * Time.deltaTime, 0));
                if (transform.position.x >= max)
                {
                    sp.flipX = false;
                    a = true;
                }
            }
            if (transform.position.x >= min && a == true)
            {

                transform.Translate(new Vector2(-1 * Time.deltaTime, 0));
                if (transform.position.x <= min)
                {
                    sp.flipX = true;
                    a = false;
                }

            }
        }
        
    }
    void dead()
    {
        gameObject.SetActive(false);
    }
}
