using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Egg : MonoBehaviour
{
    public Animator animator;
    bool isPlaying;
    public string animatorBool;
    
    public TextMeshPro waterText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlaying){
            AnimatorStateInfo animationState = animator.GetCurrentAnimatorStateInfo(0);
            AnimatorClipInfo[] myAnimatorClip = animator.GetCurrentAnimatorClipInfo(0);
            float myTime = myAnimatorClip[0].clip.length * animationState.normalizedTime;
            int time = (int) myTime;
            if((time + 2) % 5 == 0){
                waterText.text = "Densidade da agua: 1,05 g/mL";
            }else if(time % 5 == 0){
                waterText.text = "Densidade da agua: 1 g/mL";
            }
        }
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began){
            Ray rayTouch = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); 
            RaycastHit hit;
            if(Physics.Raycast(rayTouch, out hit)){
                    if(animator.GetBool(animatorBool) && isPlaying){
                        animator.SetBool(animatorBool,false);
                        isPlaying = false;
                        waterText.text = "Densidade da agua: 1 g/mL";
                    }else if(!isPlaying){
                        animator.SetBool(animatorBool,true);
                        isPlaying = true;
                    }                                       
            }
        }
    }
}
