using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoment : MonoBehaviour
{
    public float min;
    public float max;
    public SpriteRenderer sp;
    bool a=true;
    // Start is called before the first frame update
    void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x<=max&&a==false)
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
