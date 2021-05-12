using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public Animator canvasAnimator;
    public Button btnPlay,btnRules,btnGyroscope,btnExit,btnBackToMenu,btnBackToMenu2;

    private TextMeshProUGUI hasGyroscopeText;
    // Start is called before the first frame update
    void Start()
    {
        btnPlay = btnPlay.GetComponent<Button>();
        btnRules = btnRules.GetComponent<Button>();
        btnGyroscope = btnGyroscope.GetComponent<Button>();
        btnExit = btnExit.GetComponent<Button>();
        btnBackToMenu = btnBackToMenu.GetComponent<Button>();
        btnBackToMenu2 = btnBackToMenu2.GetComponent<Button>();

        hasGyroscopeText = GameObject.Find("HasGyroscopeText").GetComponent<TextMeshProUGUI>();

        btnPlay.enabled = true;
        btnRules.enabled = true;
        btnGyroscope.enabled = true;
        btnExit.enabled = true;
        btnBackToMenu.enabled = false;
        btnBackToMenu2.enabled = false;

        btnPlay.onClick.AddListener(delegate {OnClickButton(btnPlay); });
        btnRules.onClick.AddListener(delegate {OnClickButton(btnRules); });
        btnGyroscope.onClick.AddListener(delegate {OnClickButton(btnGyroscope); });
        btnExit.onClick.AddListener(delegate {OnClickButton(btnExit); });
        btnBackToMenu.onClick.AddListener(delegate {OnClickButton(btnBackToMenu); });
        btnBackToMenu2.onClick.AddListener(delegate {OnClickButton(btnBackToMenu2); });

        canvasAnimator = canvasAnimator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void OnClickButton(Button button){
        if(button == btnPlay){
            //"Game", LoadSceneMode.Single
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if(button == btnRules){
            if(!canvasAnimator.GetBool("rules")){
                canvasAnimator.SetBool("rules",true);
                btnPlay.enabled = false;
                btnRules.enabled = false;
                btnGyroscope.enabled = false;
                btnExit.enabled = false;
                btnBackToMenu.enabled = true;
            }    
        }
        if(button == btnGyroscope){
            canvasAnimator.SetBool("gyroscope",true);
            btnPlay.enabled = false;
            btnRules.enabled = false;
            btnGyroscope.enabled = false;
            btnExit.enabled = false;
            btnBackToMenu2.enabled = true;
            if(SystemInfo.supportsGyroscope){
                hasGyroscopeText.text = "Seu celular possui suporte a realidade aumentada!";
            }else{
                hasGyroscopeText.text = "Seu celular não possui suporte a realidade aumentada :(";              
            }
        }
        if(button == btnBackToMenu){
            if(canvasAnimator.GetBool("rules")){
                canvasAnimator.SetBool("rules",false);
                btnPlay.enabled = true;
                btnRules.enabled = true;
                btnGyroscope.enabled = true;
                btnExit.enabled = true;
                btnBackToMenu.enabled = false;
            }
        }
        if(button == btnBackToMenu2){
            if(canvasAnimator.GetBool("gyroscope")){
                canvasAnimator.SetBool("gyroscope",false);
                btnPlay.enabled = true;
                btnRules.enabled = true;
                btnGyroscope.enabled = true;
                btnExit.enabled = true;
                btnBackToMenu2.enabled = false;
            }
        }
        if(button == btnExit){
            Application.Quit();
        }
    }
}
