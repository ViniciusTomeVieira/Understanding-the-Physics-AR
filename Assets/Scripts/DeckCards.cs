using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DeckCards : MonoBehaviour, IPointerDownHandler
{
    // Start is called before the first frame update
    private int cardAmount;
    public Image imgDeck;
    public Card card;

    private Dice dice;
    private bool isEnabled;
    private DialogueJSON dialogues;

    public AudioSource audioSource;

    public Animator animator;
    void Start()
    {
        dialogues = GameObject.Find("Database").GetComponent<DialogueJSON>();
        imgDeck = imgDeck.GetComponent<Image>();
        card = card.GetComponent<Card>();
        animator = animator.GetComponent<Animator>();
        dice = GameObject.Find("Dice").GetComponent<Dice>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if(dice.whosTurn == 1){
            deckClick();
        }       
    }

    public void setIsEnabled(){
        isEnabled = !isEnabled;
        if(isEnabled){
            if(dice.whosTurn > 1){
                animator.SetBool("blinking",true);
                dialogues.GetNPCDialogue(7);
                Invoke("deckClick",2);
            }else{
                animator.SetBool("blinking",true);
                dialogues.GetPlayerDialogue(1);
            }
        }
    }

    public void deckClick(){
        if(isEnabled){
            card.EnableOrDisable();
            audioSource.Play();
            animator.SetBool("blinking",false);
            setIsEnabled();
        }
        if(dice.whosTurn > 1){
            audioSource.Play();
            card.Invoke("OnClickButtonIA",5);
        }
    }
}
