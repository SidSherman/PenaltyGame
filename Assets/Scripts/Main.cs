using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{

    private int coinCount = 0, attemptsCount = 0, loseCount = 0, i;

    public GameObject PauseScreen, LoseScreen;
    public Text coins, maxCoins, attempts, lifes, finalScore;
    public Button Menu;
    public AudioSource MusicSource, EffectsSource;
    public Image musicBut, effectsBut, vibrationBut;
    public Sprite effectsOn, effectsOff, musicOn, musicOff, vibrationOn, vibrationOff;
    public Slider slider;
    public SoundEffector soundEffector;


    
    void Start()
    {

        i = 1;
        
        Menu.enabled = true;
        coinCount = 0;
        attemptsCount = 0;
        loseCount = 0;
        if(PlayerPrefs.HasKey("MaxCoins")) // проверяем ключ
        {
            maxCoins.text = PlayerPrefs.GetInt("MaxCoins").ToString();
        }
        else{
            maxCoins.text = "0";
            PlayerPrefs.SetInt("MaxCoins", 0);
        }

        if (PlayerPrefs.HasKey("Effects")) {
            if (PlayerPrefs.GetInt("Effects") == 1){

                effectsBut.sprite = effectsOn;
            }
            else {
                effectsBut.sprite = effectsOff;
            }
        }
        else 
        PlayerPrefs.SetInt("Effects", 1);

        if (PlayerPrefs.HasKey("Music")) {
            if (PlayerPrefs.GetInt("Music") == 1){
                musicBut.sprite = musicOn;
            }
            else {
                musicBut.sprite = musicOff;
            }
        }
        else 
        PlayerPrefs.SetInt("Music", 1);
            if (PlayerPrefs.HasKey("Vibration")) {
            if (PlayerPrefs.GetInt("Vibration") == 1){
                vibrationBut.sprite = vibrationOn;
            }
            else {
                vibrationBut.sprite = vibrationOff;
            }
        }
        else 
        PlayerPrefs.SetInt("Vibration", 1);

        MusicSource.volume = PlayerPrefs.GetInt("Music");
        EffectsSource.volume = PlayerPrefs.GetInt("Effects");
    }

    // Update is called once per frame
    void Update()
    {
        
        coins.text = coinCount.ToString();
        attempts.text = attemptsCount.ToString();
        
        lifes.text = $"{loseCount}/5";

    }


    public void Restart(){
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Pause(false);
    }
    public void Lose(){
        Debug.Log("Lose");
        Save_Prefs();
        Time.timeScale = 0f;
        finalScore.text = coinCount.ToString();
        Menu.enabled = false;
        LoseScreen.SetActive(true);
        if(i == 1)
            soundEffector.PlayLoseSound();
        i = 0;
    }


    public void Pause(bool ispause){
        if (ispause){
            Debug.Log("Pause");
            Time.timeScale = 0f;
            PauseScreen.SetActive(true); 
        }
        else{
            Time.timeScale = 1f;
            PauseScreen.SetActive(false); 
        }
    }

    public void setCoins(){
        coinCount++;
        soundEffector.PlayCoinSound();
    }

    public void setAttempts(){
        attemptsCount++;
        if(attemptsCount % 5 == 0)
            slider.addSpeed();
    }
    public void setLoseAttempts(){
        loseCount++;
        if(loseCount == 5)
        {
            Lose();
        }
    }

    public int getAttemptsCount(){
        return attemptsCount;
    }
    private void Save_Prefs(){

       if(PlayerPrefs.HasKey("MaxCoins")) // проверяем ключ
        {
            if (PlayerPrefs.GetInt("MaxCoins") < coinCount)
                PlayerPrefs.SetInt("MaxCoins", coinCount);

        }
    }

    public void Open_Scene(int index ){
        Save_Prefs();
        SceneManager.LoadScene(index);

    }

    public void EffectsChanged(){
       
        if (PlayerPrefs.GetInt("Effects") == 0){
            PlayerPrefs.SetInt("Effects", 1);
            effectsBut.sprite = effectsOn;
        }

        else if (PlayerPrefs.GetInt("Effects") == 1){
            PlayerPrefs.SetInt("Effects", 0);
            effectsBut.sprite = effectsOff;
        }
        EffectsSource.volume = PlayerPrefs.GetInt("Effects");

    }

     public void MusicChanged(){
        
         if (PlayerPrefs.GetInt("Music") == 0){
            PlayerPrefs.SetInt("Music", 1);
            musicBut.sprite = musicOn;
        }
         else if (PlayerPrefs.GetInt("Music") == 1){
            PlayerPrefs.SetInt("Music", 0);
            musicBut.sprite = musicOff;
        }
        MusicSource.volume = PlayerPrefs.GetInt("Music");
    }
    public void vibrationChanged(){
        
         if (PlayerPrefs.GetInt("Vibration") == 0){
            PlayerPrefs.SetInt("Vibration", 1);
            vibrationBut.sprite = vibrationOn;
        }
         else if (PlayerPrefs.GetInt("Vibration") == 1){
            PlayerPrefs.SetInt("Vibration", 0);
            vibrationBut.sprite = vibrationOff;
        }
    }

 
        


}
