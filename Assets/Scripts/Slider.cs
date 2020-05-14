using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    public Transform[] vertcalPoints, horizontalPoints;
    public float speed = 10;
    public GameObject horizontalSlider;
    public GameObject verticalSlider;
    public Ball ball;
    public InstantiateCoin instantiateCoin;
    bool canMove = true;
    int stage = 1;
    int i = 1, j = 1;



    // Start is called before the first frame update
    void Start()

    {
        instantiateCoin.instantiateCoin();
        instantiateCoin.setCanInstantiate(false);
        horizontalSlider.transform.position = new Vector3(horizontalPoints[0].position.x, horizontalPoints[0].position.y, horizontalSlider.transform.position.z);
        verticalSlider.transform.position = new Vector3(vertcalPoints[0].position.x, vertcalPoints[0].position.y, verticalSlider.transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (stage == 1 ){
            horizontalSlider.transform.position = Vector3.MoveTowards(horizontalSlider.transform.position, horizontalPoints[j].position, speed * Time.deltaTime);      
             if(horizontalSlider.transform.position == horizontalPoints[j].position)
                {
                    if(j < horizontalPoints.Length - 1)
                        j++;
                    else 
                        j = 0;
                }
        }

        
        if (stage == 2){
            
            verticalSlider.transform.position = Vector3.MoveTowards(verticalSlider.transform.position, vertcalPoints[i].position, speed * Time.deltaTime);
            
    
            if(verticalSlider.transform.position == vertcalPoints[i].position)
                {
                    if(i < vertcalPoints.Length - 1)
                        i++;
                    else 
                        i = 0; 
                }
        }

        if(stage == 3 ){
            if (ball.getHit() == false){
                ball.setHit(true);            }
        }
    }

    public void setStage(bool isClick){
        if (stage == 3 && !isClick){
            stage = 1;
            if (ball.getSuccessed() == false)
                instantiateCoin.destroyCoin();

            instantiateCoin.instantiateCoin();
            instantiateCoin.setCanInstantiate(false);

            horizontalSlider.transform.position = new Vector3(horizontalPoints[0].position.x, horizontalPoints[0].position.y, horizontalSlider.transform.position.z);
            verticalSlider.transform.position = new Vector3(vertcalPoints[0].position.x, vertcalPoints[0].position.y, verticalSlider.transform.position.z);
    
        }
        if (stage != 3 && isClick)
            stage++;

    }
    public void setStageInt(int stage){
        this.stage = stage;
        
    }
    public Vector3 getTarget(){

        return new Vector3(horizontalSlider.transform.position.x, verticalSlider.transform.position.y, -1);
    }

    public void setCanMove(bool canMove){
    
        this.canMove = canMove;

    }
    public void addSpeed()
    {
        speed = speed + 2;
    } 


}

