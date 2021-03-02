using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="ground")
        {
            GetComponent<Collider2D>().isTrigger = false;
        }
        if (collision.gameObject.tag == "Player")
        {
            CoinCollected();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CoinCollected();
        }
    }
    void CoinCollected()
    {
        Destroy(gameObject);
    }
}
