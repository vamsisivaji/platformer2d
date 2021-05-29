using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadScript : MonoBehaviour
{
    public bool Hit;
    public playerM player;
    public SoundManager S;
    public AudioClip hitSound;
    // Start is called before the first frame update
    void Start()
    {
        Hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(player.jf==1)
            {
                Hit = true;
                S.Play(hitSound);
            }
        }
    }

}
