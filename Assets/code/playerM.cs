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
    public float flag;
    int jf=0;
    GameObject dog;
    bool killed=false;
    int coin_Count = 0;
    int score_Count = 0;
    public Text coins;
    public Text score;
    public GameObject GameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        dog = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetKey(KeyCode.LeftArrow)&&jf==0&&killed==false)
            {
                flag = Dog_speed();
                anim.SetFloat("Speed", flag);
                //rb.velocity = new Vector2(-1 * 100 * Time.deltaTime, 0);
                rb.AddForce(new Vector2(-1, 0) * Dog_speed());
                //transform.Translate(new Vector2(-1 * Time.deltaTime, 0));
                sp.flipX = true;

            }
            else if (Input.GetKey(KeyCode.RightArrow)&&jf==0 && killed == false)
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
            jf = 1;
            anim.SetInteger("flag", jf);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            jf = 0;
            anim.SetInteger("flag", jf);
            
        }
        if(collision.gameObject.tag=="box")
        {
            jf = 2;
            anim.SetInteger("flag", jf);
        }
        if(collision.gameObject.tag=="Coin")
        {
            coin_Count++;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.gameObject.transform.position);
        if (collision.gameObject.tag == "Coin")
        {
            coin_Count++;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            if (jf != 1)
            {
                anim.SetInteger("flag", 3);
                killed = true;
                Invoke("playerKilled", 2);
            }
            else if(jf==1)
            {
                print("enemy Killed");
                Destroy(collision.gameObject);
                score_Count++;
            }
        }
        if (collision.gameObject.tag == "Castle")
        {
            gameObject.SetActive(false);
            Invoke("nextScene", 2);
        }
    }
    void playerKilled()
    {
        Destroy(gameObject);
        GameOverPanel.SetActive(true);
    }
    void nextScene()
    {
        SceneManager.LoadScene(1);
    }
}