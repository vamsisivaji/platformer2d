using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    float time=0;
    GameObject bullet;
    public ObjectPooler BulletPool;
    SpriteRenderer sp;
    public float Speed;
    public PlayerBounds PM;
    public SoundManager S;
    public AudioClip Shoot;
    // Start is called before the first frame update
    void Start()
    {
        BulletPool = ObjectPooler.Instance;
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(time>=4&&PM.NearBoss==true)
        {
            if (sp.flipX == false)
            {
                Speed = 10 * -1;
            }
            else if (sp.flipX == true)
            {
                Speed = 10 * 1;
            }
            bullet = BulletPool.SpawnFromPool("Bullet", transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, 0);
            time = 0;
            S.Play(Shoot);
        }
        time = time + Time.deltaTime;
    }
}
