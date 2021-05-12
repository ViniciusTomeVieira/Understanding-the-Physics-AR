using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    //Estados possíveis de uma casa : 0 = vazio, 1 = pergunta, 2 = sorte/revés
    public int state;
    private static GameControl game;
    private static SpiningManager spin;

    private static DeckCards deck;

    private static Dice dice;
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("GameControl").GetComponent<GameControl>();
        spin = GameObject.Find("Spin").GetComponent<SpiningManager>();
        dice = GameObject.Find("Dice").GetComponent<Dice>();
        deck = GameObject.Find("DeckCards").GetComponent<DeckCards>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VerifyState(){
        switch(state){
            case 0: 
                game.NextPlayer();
                break;
            case 1:
                deck.setIsEnabled();
                break;
            case 2: 
                spin.setIsCoroutine(true);
                break;
        }
    }
}
