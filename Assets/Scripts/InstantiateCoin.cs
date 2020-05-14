using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCoin : MonoBehaviour
{

    public GameObject Coin;
    public Transform topBorder, bottomBorder, leftBorder, rightBorder;
    public Main main;
    public Slider slider;
    bool canInstantiate = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void instantiateCoin(){
        Vector3 position = new Vector3(Random.Range(leftBorder.position.x, rightBorder.position.x), Random.Range(topBorder.position.y, bottomBorder.position.y),-0.5f );
        Instantiate(Coin, position, Quaternion.identity, transform);
        Coin CoinObj = gameObject.GetComponentInChildren<Coin>();
        CoinObj.transform.localScale = new Vector3(CoinObj.transform.localScale.x - (0.01f * main.getAttemptsCount()), CoinObj.transform.localScale.y - (0.01f * main.getAttemptsCount()), CoinObj.transform.localScale.z);
        CoinObj.GetComponent<CircleCollider2D>().radius = CoinObj.GetComponent<CircleCollider2D>().radius - (0.01f * main.getAttemptsCount());
    }

    public bool getCanInstantiate()
    {
        return canInstantiate;
    }

    public void setCanInstantiate(bool canInstantiate)
    {
        this.canInstantiate = canInstantiate;
    }

    public void addAttempts()
    {
        main.setAttempts();
        main.setLoseAttempts();
    }
    public void setStage()
    {
        slider.setStageInt(1);
    }

    public void destroyCoin()
    {
    
        Coin CoinObj = gameObject.GetComponentInChildren<Coin>();
        Destroy(CoinObj.gameObject);

    }



}
