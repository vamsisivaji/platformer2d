using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public float min;
    public float max;
    public SpriteRenderer sp;
    bool a = true;
    public HeadScript Head;
    public Animator anim;
    int count = 0;
    float CurrentHP;
    float hurtper;
    public Slider HealthBar;
    float time = 0;
    Rigidbody2D rg;
    public PlayerBounds PM;
    public Transform Player;
    public SoundManager S;
    public AudioClip Sound;
    public AudioClip Finalevel;
    float time1 = 0;
    // Start is called before the first frame update
    void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        CurrentHP = HealthBar.value;
        hurtper = CurrentHP / 4;
    }

    // Update is called once per frame
    void Update()
    {
        if(time1>=3)
        {
            S.Play(Sound);
            time1 = 0;
        }
        time1 = time1 + Time.deltaTime;
        if (Head.Hit == true)
        {
            Head.Hit = false;
            count++;
            CurrentHP = CurrentHP - hurtper;
            HealthBar.value = CurrentHP;
            time = 0;
            while (time <= 3)
            {
                gameObject.GetComponent<Collider2D>().enabled = false;
                time = time + Time.deltaTime;
            }
            if (count>=4)
            {
                rg.gravityScale = 1;
                anim.SetBool("Dead", true);
                Invoke("dead", 2);
            }
        }
        else
        {
            if (PM.NearBoss == true)
            {
                S.PlayMusic(Finalevel);
                if (Player.position.x > transform.position.x)
                {
                    rg.AddForce(new Vector2(1, 0) * 60 * Time.deltaTime);
                    sp.flipX = true;
                }
                else
                {
                    rg.AddForce(new Vector2(-1, 0) * 60 * Time.deltaTime);
                    sp.flipX = false;
                }
            }
            else
            {
                NormalMove();
            }
        }

    }
    void dead()
    {
        gameObject.SetActive(false);
        nextScene();
    }
    void nextScene()
    {
        SceneManager.LoadScene(3);
    }
    void NormalMove()
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
