using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    GameObject bullet;
    public ObjectPooler BulletPool;
    SpriteRenderer sp;
    public float Speed;
    bool collected = false;
    // Start is called before the first frame update
    void Start()
    {
        BulletPool = ObjectPooler.Instance;
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(collected==true)
        {
            shoot();
        }
    }
    void shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (sp.flipX == true)
            {
                Speed = 10 * -1;
            }
            else if (sp.flipX == false)
            {
                Speed = 10 * 1;
            }
            bullet = BulletPool.SpawnFromPool("Bullet", transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "collectable")
        {
            collected = true;
            collision.gameObject.SetActive(false);
        }
    }
}
