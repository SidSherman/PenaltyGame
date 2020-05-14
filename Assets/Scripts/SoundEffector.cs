using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffector : MonoBehaviour
{

    public AudioSource AudioSourses;
    public AudioClip CoinSound;
    public AudioClip WinSound;
    public AudioClip LoseSound;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayCoinSound(){
        AudioSourses.PlayOneShot(CoinSound);
        
    }

    public void PlayWinSound(){
        AudioSourses.PlayOneShot(WinSound);
        
    }

    public void PlayLoseSound(){
        AudioSourses.PlayOneShot(LoseSound);
        
    }
}
