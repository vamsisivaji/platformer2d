using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rg;
    int cal = 0;
    SpriteRenderer sp;
    public Sprite[] Jump;


    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rg.AddForce(new Vector2(0, 1) * 50);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            sp.sprite = Jump[cal];
            cal++;
        }
    }
    
}
