using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public GameObject settingScreen, mainScreen;
    public Image musicBut, effectsBut, vibrationBut;
    public AudioSource soundEffector, musicEffector;
    
    public Sprite effectsOn, effectsOff, musicOn, musicOff, vibrationOn, vibrationOff;
    // Start is called before the first frame update
    void Start()
    {
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
        soundEffector.volume = PlayerPrefs.GetInt("Effects");

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

        musicEffector.volume = PlayerPrefs.GetInt("Music");

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

        


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activeSetting(){
        mainScreen.SetActive(false);
        settingScreen.SetActive(true);
    }
    public void closeSetting(){
        mainScreen.SetActive(true);
        settingScreen.SetActive(false);
    }
    public void Open_Scene(int index ){
        
        SceneManager.LoadScene(index);

    }

    public void EffectsChanged(){
        Debug.Log(PlayerPrefs.GetInt("Effects"));
        
        if (PlayerPrefs.GetInt("Effects") == 0){
            PlayerPrefs.SetInt("Effects", 1);
            effectsBut.sprite = effectsOn;
        }

        else if (PlayerPrefs.GetInt("Effects") == 1){
            PlayerPrefs.SetInt("Effects", 0);
            effectsBut.sprite = effectsOff;
        }
         soundEffector.volume = PlayerPrefs.GetInt("Effects");
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
         musicEffector.volume = PlayerPrefs.GetInt("Music");
    }
    public void vibrationChanged(){
        Debug.Log(PlayerPrefs.GetInt("Vibration"));
         if (PlayerPrefs.GetInt("Vibration") == 0){
            PlayerPrefs.SetInt("Vibration", 1);
            vibrationBut.sprite = vibrationOn;
        }
         else if (PlayerPrefs.GetInt("Vibration") == 1){
            PlayerPrefs.SetInt("Vibration", 0);
            vibrationBut.sprite = vibrationOff;
        }
    }


    public void exit(){
         Application.Quit();
    }

     public void DelKeys(){
        PlayerPrefs.DeleteAll();
    }


}
