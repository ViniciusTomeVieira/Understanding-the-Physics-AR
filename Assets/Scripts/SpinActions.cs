using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinActions : MonoBehaviour
{
    private static GameControl game;
    private static SpiningManager spin;
    private static Dice dice;
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("GameControl").GetComponent<GameControl>();
        dice = GameObject.Find("Dice").GetComponent<Dice>();
        spin = GameObject.Find("Spin").GetComponent<SpiningManager>();

    }

    // 0 = Rode a roleta novamente, 1 = Volte 2, 2 = Volte 4
    // 3 = Avance 2, 4 = Avance 4, 5 = Jogue o dado novamente
    // 6 = Passe a vez, 7 = Passe a vez
    public static void VerifyNumber(int number){
        switch(number){
            case 0: spin.setIsCoroutine(true); break;
            case 1: GameControl.diceSideThrown = 2;
                    GameControl.setPlayerWalkBackwards(true);
                    GameControl.MovePlayer(dice.whosTurn); break;
            case 2: GameControl.diceSideThrown = 4;
                    GameControl.setPlayerWalkBackwards(true);
                    GameControl.MovePlayer(dice.whosTurn); break;
            case 3: GameControl.diceSideThrown = 2;
                    GameControl.MovePlayer(dice.whosTurn);  break;
            case 4: GameControl.diceSideThrown = 4;
                    GameControl.MovePlayer(dice.whosTurn); break;
            case 5: dice.canPlay = true;
                    dice.animator.SetBool("playerTurn",true);
                    if(dice.whosTurn > 1){
                        dice.Invoke("OnMouseDown",2);
                    }break;
            case 6: game.Invoke("NextPlayer",2); break;
            case 7: game.Invoke("NextPlayer",2); break;
        }
    }
}