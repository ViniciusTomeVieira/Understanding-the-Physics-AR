using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {

    private Sprite[] diceSides;
    private SpriteRenderer rend;
    public int whosTurn = 1;
    public bool canPlay = true;
    public Animator animator;
    public AudioSource audioSource;
       private bool gameHasStarted;

	// Use this for initialization
	private void Start () {
            rend = GetComponent<SpriteRenderer>();
            //Carrega todos os sprites do dado
            diceSides = Resources.LoadAll<Sprite>("DiceSides/");
            //Começa com o dado tendo o valor 6 (Sprite 5)
            rend.sprite = diceSides[5];
            animator = animator.GetComponent<Animator>();
            animDice();       
	}

    public void OnMouseDown()
    {
        if (!GameControl.gameOver && canPlay)
            StartCoroutine("RollTheDice");
    }

    public void animDice(){
        if(whosTurn == 1){
            animator.SetBool("playerTurn",true);
        }
    }

    public void stopDice(){
        animator.SetBool("playerTurn",false);
    }

    private IEnumerator RollTheDice()
    {
        stopDice();
        audioSource.Play();
        canPlay = false;
        //variavel randomDiceSide com o valor final depois de rolar o dado
        int randomDiceSide = 0;
        //o dado rola 20 vezes, ficando o ultimo valor sorteado
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        GameControl.diceSideThrown = randomDiceSide + 1; //muda do valor de vetor pra normal ex.: 0 vira 1
        if (whosTurn == 1)
        {
            GameControl.MovePlayer(1);
        } else if (whosTurn == 2)
        {
            GameControl.MovePlayer(2);
        }else if (whosTurn == 3)
        {
            GameControl.MovePlayer(3);
        }else if (whosTurn == 4)
        {
            GameControl.MovePlayer(4);
        }      
    }
}