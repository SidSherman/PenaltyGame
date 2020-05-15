using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour

{

private float timeToDissapear = 10;
public float waitTime = 1f;
//public Main main;
//public InstantiateCoin instantiate; 
private SpriteRenderer objRenderer;



void Start()
{
    objRenderer = gameObject.GetComponent<SpriteRenderer>();
    StartCoroutine(InviseCoin(timeToDissapear, waitTime));

}

void Update(){

    
}


public void setTime(float time){
    timeToDissapear = time;
}
IEnumerator InviseCoin(float time, float waitTime)
     {
        yield return new WaitForSeconds(time);
        for(int i = 0; i < 3; i++){
                objRenderer.color = new Color(objRenderer.color.r, objRenderer.color.g, objRenderer.color.b, 0f);
                yield return new WaitForSeconds(waitTime);
                objRenderer.color = new Color(objRenderer.color.r, objRenderer.color.g, objRenderer.color.b, 1f);
                yield return new WaitForSeconds(waitTime);
        }
        
        InstantiateCoin instantiate = gameObject.GetComponentInParent<InstantiateCoin>(); 
        instantiate.setCanInstantiate(true);
        instantiate.GetComponentInParent<InstantiateCoin>().instantiateCoin();
        instantiate.GetComponentInParent<InstantiateCoin>().addAttempts();
        instantiate.setStage();
        instantiate.destroyCoin();
        
     }

}