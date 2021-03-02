using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBox : MonoBehaviour
{
    public Animator Anim;
    bool Flag=false;
    public GameObject Coin;
    bool isEmpty = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Anim.SetBool("hit", Flag);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player"&&isEmpty==false)
        {
            Flag = true;
            GameObject coinRef = Instantiate(Coin);
            coinRef.transform.position = transform.position;
            Rigidbody2D rb = coinRef.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(0, 1) * 30);
            isEmpty = true;
        }
    }
    
}
