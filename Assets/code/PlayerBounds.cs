using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    public GameObject EnemyHealthPanel;
    public bool NearBoss = false;
    public GameObject Bounds;
    public SoundManager S;
    public AudioClip Encounter;
    public AudioClip Finalevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground 4")
        {
            EnemyHealthPanel.SetActive(true);
            NearBoss = true;
            Bounds.SetActive(true);
            //S.Play(Encounter);
            S.PlayMusic(Finalevel);
        }
    }
}
