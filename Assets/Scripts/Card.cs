using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI cardTitle, cardQuestion, btnTextOption1, btnTextOption2, btnTextOption3, btnTextOption4;
    public Button btnOption1,btnOption2,btnOption3,btnOption4, btnRA;
    public Image imgCard;
    private bool hasAR;
    public Animator animator;
    private static GameControl game;
    private static Dice dice;
    private PlayerImage playerImage;
    private DialogueJSON dialogues;
    private CardsJSON cardsJSON;

    private string answer = "";
    private Button btnAnswer;

    private bool isEnabled;
    private bool answerCorrect;
    public AudioSource audioSourceCorrect,audioSourceWrong;
    public GameObject canvas;
    public SpriteRenderer player1, player2, player3, player4, background, gambiarra, diceSprite;
    void Start()
    {
            isEnabled = false;
            cardTitle = cardTitle.GetComponent<TextMeshProUGUI>();

            dialogues = GameObject.Find("Database").GetComponent<DialogueJSON>();
            cardsJSON = GameObject.Find("Cards").GetComponent<CardsJSON>();

            game = GameObject.Find("GameControl").GetComponent<GameControl>();

            dice = GameObject.Find("Dice").GetComponent<Dice>();
            playerImage = GameObject.Find("ActualPlayerImage").GetComponent<PlayerImage>();

            btnTextOption1.GetComponent<TextMeshProUGUI>();
            btnTextOption2.GetComponent<TextMeshProUGUI>();
            btnTextOption3.GetComponent<TextMeshProUGUI>();
            btnTextOption4.GetComponent<TextMeshProUGUI>();

            btnOption1 = btnOption1.GetComponent<Button>();
            btnOption2 = btnOption2.GetComponent<Button>();
            btnOption3 = btnOption3.GetComponent<Button>();
            btnOption4 = btnOption4.GetComponent<Button>();
            btnRA = btnRA.GetComponent<Button>();
            btnAnswer = btnOption1;
            
            btnOption1.enabled = false;
            btnOption2.enabled = false;
            btnOption3.enabled = false;
            btnOption4.enabled = false;
            btnRA.enabled = false;
            btnRA.image.enabled = false;
            btnRA.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;

            btnOption1.onClick.AddListener(delegate {OnClickButton(btnOption1); });
            btnOption2.onClick.AddListener(delegate {OnClickButton(btnOption2); });
            btnOption3.onClick.AddListener(delegate {OnClickButton(btnOption3); });
            btnOption4.onClick.AddListener(delegate {OnClickButton(btnOption4); });
            btnRA.onClick.AddListener(delegate {OnClickButton(btnRA); });

            imgCard = imgCard.GetComponent<Image>();

            animator = GetComponent<Animator>();    
    }


    void OnClickButton(Button button){
        if(!button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Equals(answer)){
            if(button != btnRA){
                button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().faceColor = Color.red;
                btnAnswer.transform.GetChild(0).GetComponent<TextMeshProUGUI>().faceColor = Color.green;
                cardTitle.text = "Errrou!!!";
                cardAnswered(false);
            }      
        }else{
            if(button != btnRA){
                button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().faceColor = Color.green;
                cardTitle.text = "Acertou!!!";
                cardAnswered(true);
            }
        }

        if(button == btnRA){
            canvas.SetActive(false);
            player1.enabled = false;
            player2.enabled = false;
            player3.enabled = false;
            player4.enabled = false;           
            background.enabled = false;           
            gambiarra.enabled = false;           
            diceSprite.enabled = false;           
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1,LoadSceneMode.Additive);
        }
	}

    //Método quando a IA escolhe uma alternativa da carta pergunta
    public void OnClickButtonIA(){
        int optionIA = Random.Range(1,4);
        Button buttonIA;
        TextMeshProUGUI whatever = new TextMeshProUGUI();
        switch(optionIA){
            case 1: buttonIA = btnOption1; break;
            case 2: buttonIA = btnOption2; break;
            case 3: buttonIA = btnOption3; break;
            case 4: buttonIA = btnOption4; break;
            default: buttonIA = btnOption4; break;
        }
        OnClickButton(buttonIA);
    }

    private void NPCDialogue(){
        dialogues.GetNPCDialogue(9);
    }
    private void PlayerDialogue(){
        dialogues.GetPlayerDialogue(3);
    }
    public void EnableOrDisable(){
        if(isEnabled){
            animator.SetBool("question",false);
            if(hasAR){
                btnRA.enabled = false;
                btnRA.image.enabled = false;
                btnRA.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
            }
            if(answerCorrect){
                GameControl.diceSideThrown = 2;
                GameControl.MovePlayer(dice.whosTurn);
            }else{
                GameControl.diceSideThrown = 1;
                GameControl.setPlayerWalkBackwards(true);
                GameControl.MovePlayer(dice.whosTurn);
                //game.Invoke("NextPlayer",1);
            }
            isEnabled = false;
        }else{
            cardsJSON.GetQuestion();
            animator.SetBool("question",true);
            if(dice.whosTurn == 1){
                btnOption1.enabled = true;
                btnOption2.enabled = true;
                btnOption3.enabled = true;
                btnOption4.enabled = true;
                Invoke("PlayerDialogue",2.5f);
            }else{
                Invoke("NPCDialogue",2.5f);
            }       
            isEnabled = true;
        }
        
        //Reseta as letras dos botões pra BRANCO
        btnOption1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().faceColor = new Color(0.94f, 0.94f, 0.94f, 1.0f);
        btnOption2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().faceColor = new Color(0.94f, 0.94f, 0.94f, 1.0f);
        btnOption3.transform.GetChild(0).GetComponent<TextMeshProUGUI>().faceColor = new Color(0.94f, 0.94f, 0.94f, 1.0f);
        btnOption4.transform.GetChild(0).GetComponent<TextMeshProUGUI>().faceColor = new Color(0.94f, 0.94f, 0.94f, 1.0f);
    }
    private void cardAnswered(bool correct){
        answerCorrect = correct;
        btnOption1.enabled = false;
        btnOption2.enabled = false;
        btnOption3.enabled = false;
        btnOption4.enabled = false;
        if(correct){
            audioSourceCorrect.Play();
            playerImage.changePlayerImage();
            if(dice.whosTurn > 1){
                dialogues.GetNPCDialogue(10);
            }else{
                dialogues.GetPlayerDialogue(4);
            }           
            Invoke("EnableOrDisable", 3);
        }else{
            audioSourceWrong.Play();
            playerImage.changePlayerImage();
            playerImage.changePlayerImage();
            if(dice.whosTurn > 1){
                dialogues.GetNPCDialogue(11);
            }else{
                dialogues.GetPlayerDialogue(5);
            }   
            Invoke("EnableOrDisable", 3);
        }
    }

    public void AnimateCard(){
        animator.SetBool("question",true);
    }

    public void UpdateCard(string title,string description,string option1,string option2,string option3,string option4,string correctAnswer, bool AR){
        cardTitle.text = title;
        game.cardName = title;
        cardQuestion.text = description;
        btnTextOption1.text = option1;
        btnTextOption2.text = option2;
        btnTextOption3.text = option3;
        btnTextOption4.text = option4;
        answer = correctAnswer;
        hasAR = AR;

        if(option1.Equals(correctAnswer)){
            btnAnswer = btnOption1;
        }
        if(option2.Equals(correctAnswer)){
            btnAnswer = btnOption2;
        }
        if(option3.Equals(correctAnswer)){
            btnAnswer = btnOption3;
        }
        if(option4.Equals(correctAnswer)){
            btnAnswer = btnOption4;
        }

        if(hasAR && dice.whosTurn == 1){
            btnRA.enabled = true;
            btnRA.image.enabled = true;
            btnRA.transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        }
    }
}
