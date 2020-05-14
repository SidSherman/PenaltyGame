using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour

{

private int timeToDissapear = 3;
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

IEnumerator InviseCoin(float time, float waitTime)
     {
        yield return new WaitForSeconds(waitTime);
        for(int i = 0; i < time; i++){
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