using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerM : MonoBehaviour
{
    public SpriteRenderer sp;
    Rigidbody2D rb;
    public Animator anim;
    float speed;
    float flag;
    public int jf=0;
    GameObject dog;
    bool killed=false;
    int coin_Count = 0;
    int score_Count = 0;
    public Text coins;
    public Text score;
    public GameObject GameOverPanel;
    public Slider HealthBar;
    float health;
    public AudioClip Coin;
    public AudioClip Hurt;
    public AudioClip DeathMusic;
    public AudioClip Box;
    public AudioClip Grounded;
    public AudioClip Jump;
    public SoundManager S;
    public int n;
    Transform Respawn;
    // Start is called before the first frame update
    void Start()
    {
        health = HealthBar.value;
        rb = GetComponent<Rigidbody2D>();
        dog = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Hurt", false);
        if (Input.GetKey(KeyCode.A)&&jf==0&&killed==false)
            {
                flag = Dog_speed();
                anim.SetFloat("Speed", flag);
                //rb.velocity = new Vector2(-1 * 100 * Time.deltaTime, 0);
                rb.AddForce(new Vector2(-1, 0) * Dog_speed());
                //transform.Translate(new Vector2(-1 * Time.deltaTime, 0));
                sp.flipX = true;
            }
            else if (Input.GetKey(KeyCode.D)&&jf==0 && killed == false)
            {
                flag = Dog_speed();
                anim.SetFloat("Speed", flag);
                //rb.velocity = new Vector2(1 * 100 * Time.deltaTime, 0);
                rb.AddForce(new Vector2(1, 0) * Dog_speed());
                //transform.Translate(new Vector2(1 * Time.deltaTime, 0));
                sp.flipX = false;
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }

        if (Input.GetKeyDown(KeyCode.Space)&&jf==0 && killed == false)
        {
            rb.AddForce(new Vector2(0, 1) * 50);
        }
        if(killed==true)
        {
            Invoke("playerKilled", 2);
        }
        coins.text = coin_Count.ToString();
        score.text = score_Count.ToString();
        

    }
    float Dog_speed()
    {
        return  100* Time.deltaTime;

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="ground")
        {
            S.Play(Jump);
            jf = 1;
            anim.SetInteger("flag", jf);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="OutOfBound")
        {
            gameObject.transform.position = Respawn.position;
        }
        if (collision.gameObject.tag == "ground")
        {
            S.Play(Grounded);
            jf = 0;
            anim.SetInteger("flag", jf);
            
        }
       
        if(collision.gameObject.tag=="box")
        {
            S.Play(Box);
            jf = 2;
            anim.SetInteger("flag", jf);
        }
        if(collision.gameObject.tag=="Coin")
        {
            S.Play(Coin);
            coin_Count++;
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.gameObject.transform.position);
        if(collision.gameObject.tag=="CheckPoint")
        {
            Respawn = collision.gameObject.transform;
        }
        if (collision.gameObject.tag == "Coin")
        {
            S.Play(Coin);
            coin_Count++;
            
        }
        if (collision.gameObject.tag == "Enemy")
        {
            if (jf != 1)
            {
                health -= 0.25f;
                playerHurt();
                Death();
                
            }
        }
        if(collision.gameObject.tag=="Bullet")
        {
            health -= 0.1f;
            playerHurt();
            Death();
        }
        if (collision.gameObject.tag == "Castle")
        {
            gameObject.SetActive(false);
            Invoke("nextScene", 2);
        }
        if(collision.gameObject.tag=="Head")
        {
            score_Count++;
        }
    }
    void playerKilled()
    {
        gameObject.SetActive(false);
        GameOverPanel.SetActive(true);
    }
    void playerHurt()
    {
        float time = 0;
        S.Play(Hurt);
        HealthBar.value = health;
        while(time<=3)
        {
            anim.SetBool("Hurt", true);
            time = time + Time.deltaTime;
        }
        
    }
    void nextScene()
    {
        SceneManager.LoadScene(2);
    }
    void Death()
    {
        if (HealthBar.value <= 0)
        {
            anim.SetInteger("flag", 3);
            killed = true;
            S.Play(DeathMusic);
        }
    }
}