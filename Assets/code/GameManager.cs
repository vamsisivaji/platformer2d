using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public SoundManager s;
    public AudioClip BGM;
    // Start is called before the first frame update
    void Start()
    {
        s.PlayMusic(BGM);
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }
}
