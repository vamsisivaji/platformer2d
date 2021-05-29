using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLYdown : MonoBehaviour
{
    public Transform player;
    SpriteRenderer sp;
    public PlayerBounds PM;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
            if (sp.flipX == false && PM.NearBoss==true)
            {
                if (player.position.x < transform.position.x && transform.position.y >= 0.5f)
                {
                    transform.Translate(new Vector2(0, -1 * Time.deltaTime));
                }
             }
            if (sp.flipX == true && PM.NearBoss == true)
                {
                    if (player.position.x > transform.position.x && transform.position.y >= 0.5f)
                    {
                        transform.Translate(new Vector2(0, -1 * Time.deltaTime));
                    }
                }
        
        
    }
}
