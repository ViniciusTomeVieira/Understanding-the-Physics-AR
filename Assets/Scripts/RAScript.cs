using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RAScript : MonoBehaviour
{

    public Button btnExit;
    public GameObject tela, eventSystem, script;
    private GameObject[] objects;

    private string nameCard;
    

    public GameObject pergunta01,pergunta02,pergunta03,pergunta04,pergunta06,pergunta07,pergunta08,pergunta09,pergunta11;
    // Start is called before the first frame update
    void Start()
    {
        btnExit = btnExit.GetComponent<Button>();
        btnExit.onClick.AddListener(delegate {OnClickButton(btnExit); });
        Scene game = SceneManager.GetSceneByName("Game");
        objects = game.GetRootGameObjects();

        pergunta01.SetActive(false); 
        pergunta02.SetActive(false); 
        pergunta03.SetActive(false); 
        pergunta04.SetActive(false); 
        pergunta06.SetActive(false); 
        pergunta07.SetActive(false); 
        pergunta08.SetActive(false); 
        pergunta09.SetActive(false); 
        pergunta11.SetActive(false); 

        GameObject gameControl = objects[9];
        GameControl gameScript = gameControl.GetComponent<GameControl>();
        nameCard = gameScript.cardName;
        switch(gameScript.cardName){
                case "Pergunta 01" : pergunta01.SetActive(true); break;
                case "Pergunta 02" : pergunta02.SetActive(true); break;
                case "Pergunta 03" : pergunta03.SetActive(true); break;
                case "Pergunta 04" : pergunta04.SetActive(true); break;
                case "Pergunta 06" : pergunta06.SetActive(true); break;
                case "Pergunta 07" : pergunta07.SetActive(true); break;
                case "Pergunta 08" : pergunta08.SetActive(true); break;
                case "Pergunta 09" : pergunta09.SetActive(true); break;
                case "Pergunta 11" : pergunta11.SetActive(true); break;
            }
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKey(KeyCode.Escape)){
            OnClickButton(btnExit);
        }
    }

    void OnClickButton(Button button){
        if(button == btnExit){
            GameObject canvas = objects[12];
            canvas.SetActive(true);

            GameObject players = objects[1];
            SpriteRenderer player1 = players.transform.GetChild(3).GetComponent<SpriteRenderer>();
            SpriteRenderer player2 = players.transform.GetChild(2).GetComponent<SpriteRenderer>();
            SpriteRenderer player3 = players.transform.GetChild(1).GetComponent<SpriteRenderer>();
            SpriteRenderer player4 = players.transform.GetChild(0).GetComponent<SpriteRenderer>();           
            player1.enabled = true;
            player2.enabled = true;
            player3.enabled = true;
            player4.enabled = true;

            GameObject gameControl = objects[9];
            gameControl.GetComponent<GameControl>().AnimateCard();          

            GameObject dice = objects[11];
            dice.GetComponent<SpriteRenderer>().enabled = true;
            
            GameObject background = objects[5];
            background.GetComponent<SpriteRenderer>().enabled = true;
            
            GameObject gambiarra = objects[7];
            gambiarra.GetComponent<SpriteRenderer>().enabled = true;

            pergunta01.SetActive(false); 
            pergunta02.SetActive(false); 
            pergunta03.SetActive(false); 
            pergunta04.SetActive(false); 
            pergunta06.SetActive(false); 
            pergunta07.SetActive(false); 
            pergunta08.SetActive(false); 
            pergunta09.SetActive(false); 
            pergunta11.SetActive(false); 

            Destroy(tela);
            Destroy(eventSystem);
            Destroy(script);
        }
    }
    void OnGUI(){
        GameObject canvas = objects[1]; //Players
        GameObject evt = objects[2]; // Main Camera
        GameObject boardway = objects[3]; // Spin Actions
        GameObject gamecontrol = objects[4]; // GameWindowsManager
        GameObject database = objects[5]; // Background
        GameObject players = objects[6]; //BoardWaypoints
        GameObject dice = objects[7]; // Gambiarra
        GameObject cards = objects[8]; // Database
        GameObject spinactions = objects[9]; // GameControl
        GameObject gamewindowsmanager = objects[10]; // Cards
        GameObject background = objects[11]; // Dice
        GameObject gambiarra = objects[12]; // GameCanvas
        GUIStyle style = new GUIStyle();
        style.fontSize = 180;
        // GUILayout.Label(boardway.name,style);
        // GUILayout.Label(gamecontrol.name,style);
        // GUILayout.Label(database.name,style);
        // GUILayout.Label(players.name,style);
        // GUILayout.Label(dice.name,style);
        // GUILayout.Label(cards.name,style);
        // GUILayout.Label(spinactions.name,style);
        // GUILayout.Label(gamewindowsmanager.name,style);
        // GUILayout.Label(background.name,style);
        // GUILayout.Label(gambiarra.name,style);
    }
}
