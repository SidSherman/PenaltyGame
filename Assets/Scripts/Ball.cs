using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
public Slider slider;
public InstantiateCoin instantiateCoin;
public Main main;
public float speed;
bool hit, isgoal = false, canCollect = false, isSuccessed = false;
public Transform target, StartPos;
Rigidbody2D rigidBody;
    void Start()
    {
       rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
            Shoot();
        }

    void Shoot(){

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0.035f, 0.035f, 1f), 0.07f);

        if (transform.position == target.position)
        {
            canCollect = true;
            isgoal = true;
            hit = false;
            StartCoroutine(WatingForCollect());
            result ();
        }
    }

    void result ()
    {
        rigidBody.isKinematic = false;
        rigidBody.gravityScale = 1;

        StartCoroutine(Wating());


    }

    public void setHit(bool hit){

        if (isgoal == false){
            this.hit = hit;
            target.position = slider.getTarget();
        }
    }

    public bool getHit(){
        return hit;
    }


    IEnumerator Wating()
    {
        yield return new WaitForSeconds(2f);
        rigidBody.isKinematic = true;
        transform.position = StartPos.position;
        transform.localScale = new Vector3(0.05f, 0.05f, 1);
        isgoal = false;
        instantiateCoin.setCanInstantiate(true);
        slider.setStage(false);
        main.setAttempts();
        if (isSuccessed == false){
            main.setLoseAttempts();
        }
        isSuccessed = false;

    }


    IEnumerator WatingForCollect()
    {
        yield return new WaitForSeconds(0.1f);
        canCollect = false;

    }

     private void OnTriggerStay2D(Collider2D other) {

        if(canCollect == true && other.gameObject.tag == "coin"){
            instantiateCoin.destroyCoin();
            instantiateCoin.setCanInstantiate(true);
            main.setCoins();
            isSuccessed = true;
        }
    }

    public bool getSuccessed()
    {
        return isSuccessed;
    }




}
