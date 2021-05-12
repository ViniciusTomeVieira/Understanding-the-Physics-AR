using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWindowsManager : MonoBehaviour
{
    private Button btnExit, btnHelp, btnBackToGame;
    private GameObject dice;
    private Image imgSpin, imgDeckCards;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {     
        btnExit = GameObject.Find("ExitButton").GetComponent<Button>();
        btnHelp = GameObject.Find("HelpButton").GetComponent<Button>();
        btnBackToGame = GameObject.Find("BackToGameButton").GetComponent<Button>();
        dice = GameObject.Find("Dice");
        imgSpin = GameObject.Find("Spin").GetComponent<Image>();
        imgDeckCards = GameObject.Find("DeckCards").GetComponent<Image>();

        animator = animator.GetComponent<Animator>();

        btnExit.onClick.AddListener(delegate {OnClickButton(btnExit); });
        btnHelp.onClick.AddListener(delegate {OnClickButton(btnHelp); });
        btnBackToGame.onClick.AddListener(delegate {OnClickButton(btnBackToGame); });
    }

    // Update is called once per frame
    void OnClickButton(Button button)
    {
        if(button == btnExit){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if(button == btnHelp){
            animator.SetBool("help",true);
            btnBackToGame.enabled = true;
            dice.SetActive(false);
            imgSpin.enabled = false;
            imgDeckCards.enabled = false;
            btnExit.enabled = false;
            btnHelp.enabled = false;
        }
        if(button == btnBackToGame){
            animator.SetBool("help",false);
            btnBackToGame.enabled = false;
            dice.SetActive(true);
            imgSpin.enabled = true;
            imgDeckCards.enabled = true;
            btnExit.enabled = true;
            btnHelp.enabled = true;
        }
    }
}
