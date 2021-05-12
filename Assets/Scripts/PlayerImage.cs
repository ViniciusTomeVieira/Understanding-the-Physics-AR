using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerImage : MonoBehaviour
{
    private Sprite[] player1Images,player2Images,player3Images,player4Images,playerBorders;
    private static Dice dice;
    private Image playerImage, playerBorder;
    private TextMeshProUGUI dialogueText;
    private DialogueJSON dialogues;
    // Start is called before the first frame update
    void Start()
    {
            playerImage = GameObject.Find("ActualPlayerImage").GetComponent<Image>();
            playerBorder = playerImage.transform.GetChild(0).GetComponent<Image>();

            dialogueText = playerImage.transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>();

            player1Images = Resources.LoadAll<Sprite>("Characters/black_hair_guy");
            player2Images = Resources.LoadAll<Sprite>("Characters/redhead_guy");
            player3Images = Resources.LoadAll<Sprite>("Characters/woman_blonde");
            player4Images = Resources.LoadAll<Sprite>("Characters/woman_brunette");

            playerBorders = Resources.LoadAll<Sprite>("Borders/");

            dice = GameObject.Find("Dice").GetComponent<Dice>();

            dialogues = GameObject.Find("Database").GetComponent<DialogueJSON>();

            playerImage.sprite = player1Images[1];        
    }
    public void NextPlayer(){
        changePlayerImage();
        switch(dice.whosTurn){
            case 1: 
                playerImage.sprite = player1Images[2]; 
                dialogues.GetPlayerDialogue(0);
                playerBorder.sprite = playerBorders[0];
                dice.animDice();
                dialogueText.color = new Color32(51,51,255,255); break;
            case 2: 
                playerImage.sprite = player2Images[2]; 
                dialogues.GetNPCDialogue(6);
                playerBorder.sprite = playerBorders[1]; 
                dialogueText.color = new Color32(0,255,0,255); break;
            case 3: 
                playerImage.sprite = player3Images[2]; 
                dialogues.GetNPCDialogue(6);
                playerBorder.sprite = playerBorders[2]; 
                dialogueText.color = new Color32(255,128,0,255); break;
            case 4: 
                playerImage.sprite = player4Images[0];
                dialogues.GetNPCDialogue(6); 
                playerBorder.sprite = playerBorders[3];
                dialogueText.color = new Color32(255,0,255,255); break;
        }
    }
    //Parameter: state, 1 = rolando dado, 2 = pergunta, 3 = sorte/revés, 4 = em pergunta, 5 = após responder a carta
    public void ChangeDialog(string dialogue){
        dialogueText.text = dialogue;
    }

    public void changePlayerImage(){
        switch(dice.whosTurn){
            case 1: playerImage.sprite = player1Images[Random.Range(0,3)]; break;
            case 2: playerImage.sprite = player2Images[Random.Range(0,12)]; break;
            case 3: playerImage.sprite = player3Images[Random.Range(0,12)]; break;
            case 4: playerImage.sprite = player4Images[Random.Range(0,5)]; break;
        }
    }
}