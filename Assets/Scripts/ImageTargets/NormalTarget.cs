using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTarget : MonoBehaviour
{
    public Animator animator;
    bool isPlaying;
    public string animatorBool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began){
            Ray rayTouch = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); 
            RaycastHit hit;
            if(Physics.Raycast(rayTouch, out hit)){
                    if(animator.GetBool(animatorBool) && isPlaying){
                        animator.SetBool(animatorBool,false);
                        isPlaying = false;
                    }else if(!isPlaying){
                        animator.SetBool(animatorBool,true);
                        isPlaying = true;
                    }                                       
            }
        }
    }
}
