using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Impulse : MonoBehaviour
{
    public Animator springAnimator, basketballAnimator;

    public TextMeshPro secondsText;
    string objectName;
    bool isPlaying;
    float timer;
    void Start()
    {
        timer = 0.0f;
        if(secondsText == null){
            secondsText = new TextMeshPro();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlaying){
            timer += Time.deltaTime;
            float seconds = timer % 60;
            secondsText.text = "Segundos: " + seconds;
            if(seconds >= 0.50){
                isPlaying = false;
            }
        }
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began){
            Ray rayTouch = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); 
            RaycastHit hit;
            if(Physics.Raycast(rayTouch, out hit)){
                objectName = hit.transform.name;
                if(springAnimator.GetBool("Impulse") && !isPlaying){
                    springAnimator.SetBool("Impulse",false);
                    basketballAnimator.SetBool("Impulse",false);
                }else if(!isPlaying){
                    springAnimator.SetBool("Impulse",true);
                    basketballAnimator.SetBool("Impulse",true);
                    timer = 0.0f;
                    secondsText.text = "Segundos: 0";
                    isPlaying = true;
                }                                        
            }
        }
    }
}
