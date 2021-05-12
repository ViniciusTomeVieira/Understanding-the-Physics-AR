using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    private static GameObject whoWinsTextShadow, player1MoveText, player2MoveText, player3MoveText, player4MoveText;

    private static GameObject player1, player2, player3, player4;
    private static Dice dice;
    private PlayerImage playerImage;

    public static int diceSideThrown;
    public static int player1StartWaypoint;
    public static int player2StartWaypoint;
    public static int player3StartWaypoint;
    public static int player4StartWaypoint;

    public static bool gameOver;

    public string cardName;

    public AudioSource audioSource;

    public Card card;

    private static bool playerWalkBackwards;

    // Use this for initialization
    void Start () {
            player1StartWaypoint = 0;
            player2StartWaypoint = 0;
            player3StartWaypoint = 0;
            player4StartWaypoint = 0;
            gameOver = false;
            diceSideThrown = 0;
            playerWalkBackwards = false;

            whoWinsTextShadow = GameObject.Find("WhoWinsText");
            player1MoveText = GameObject.Find("Player1MoveText");
            player2MoveText = GameObject.Find("Player2MoveText");
            player3MoveText = GameObject.Find("Player3MoveText");
            player4MoveText = GameObject.Find("Player4MoveText");

            player1 = GameObject.Find("Player1");
            player2 = GameObject.Find("Player2");
            player3 = GameObject.Find("Player3");
            player4 = GameObject.Find("Player4");

            dice = GameObject.Find("Dice").GetComponent<Dice>();

            player1.GetComponent<FollowThePath>().moveAllowed = false;
            player2.GetComponent<FollowThePath>().moveAllowed = false;
            player3.GetComponent<FollowThePath>().moveAllowed = false;
            player4.GetComponent<FollowThePath>().moveAllowed = false;

            whoWinsTextShadow.gameObject.SetActive(false);
            player1MoveText.gameObject.SetActive(true);
            player2MoveText.gameObject.SetActive(false);
            player3MoveText.gameObject.SetActive(false);
            player4MoveText.gameObject.SetActive(false);

            playerImage = GameObject.Find("ActualPlayerImage").GetComponent<PlayerImage>();     
    }

    // Update is called once per frame
    void Update()
    {
        VerifyTurn();
        if(playerWalkBackwards){
            if (player1.GetComponent<FollowThePath>().waypointIndex < 
                player1StartWaypoint - diceSideThrown)
            {
                player1.GetComponent<FollowThePath>().moveAllowed = false;
                player1StartWaypoint = player1.GetComponent<FollowThePath>().waypointIndex + 1;
                Invoke("VerifyWaypointIndex",0.4f); 
            }

            if (player2.GetComponent<FollowThePath>().waypointIndex <
                player2StartWaypoint - diceSideThrown)
            {
                player2.GetComponent<FollowThePath>().moveAllowed = false;
                player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex + 1;
                Invoke("VerifyWaypointIndex",0.4f); 
            }

            if (player3.GetComponent<FollowThePath>().waypointIndex <
                player3StartWaypoint - diceSideThrown)
            {
                player3.GetComponent<FollowThePath>().moveAllowed = false;
                player3StartWaypoint = player3.GetComponent<FollowThePath>().waypointIndex + 1;
                Invoke("VerifyWaypointIndex",0.4f); 
            }

            if (player4.GetComponent<FollowThePath>().waypointIndex <
                player4StartWaypoint - diceSideThrown)
            {
                player4.GetComponent<FollowThePath>().moveAllowed = false;
                player4StartWaypoint = player4.GetComponent<FollowThePath>().waypointIndex + 1;
                Invoke("VerifyWaypointIndex",0.4f); 
            }
        }else{
            if (player1.GetComponent<FollowThePath>().waypointIndex > 
                player1StartWaypoint + diceSideThrown)
            {
                player1.GetComponent<FollowThePath>().moveAllowed = false;
                player1StartWaypoint = player1.GetComponent<FollowThePath>().waypointIndex - 1;
                Invoke("VerifyWaypointIndex",0.4f); 
            }

            if (player2.GetComponent<FollowThePath>().waypointIndex >
                player2StartWaypoint + diceSideThrown)
            {
                player2.GetComponent<FollowThePath>().moveAllowed = false;
                player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex - 1;
                Invoke("VerifyWaypointIndex",0.4f); 
            }

            if (player3.GetComponent<FollowThePath>().waypointIndex >
                player3StartWaypoint + diceSideThrown)
            {
                player3.GetComponent<FollowThePath>().moveAllowed = false;
                player3StartWaypoint = player3.GetComponent<FollowThePath>().waypointIndex - 1;
                Invoke("VerifyWaypointIndex",0.4f); 
            }

            if (player4.GetComponent<FollowThePath>().waypointIndex >
                player4StartWaypoint + diceSideThrown)
            {
                player4.GetComponent<FollowThePath>().moveAllowed = false;
                player4StartWaypoint = player4.GetComponent<FollowThePath>().waypointIndex - 1;
                Invoke("VerifyWaypointIndex",0.4f); 
            }
        }    

        if (player1.GetComponent<FollowThePath>().waypointIndex == 
            player1.GetComponent<FollowThePath>().waypoints.Length)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            PlayWinMusic();
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(false);
            player3MoveText.gameObject.SetActive(false);
            player4MoveText.gameObject.SetActive(false);
            whoWinsTextShadow.GetComponent<Text>().text = "Você venceu!!!";
            gameOver = true;
        }

        if (player2.GetComponent<FollowThePath>().waypointIndex ==
            player2.GetComponent<FollowThePath>().waypoints.Length)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            PlayWinMusic();
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(false);
            player3MoveText.gameObject.SetActive(false);
            player4MoveText.gameObject.SetActive(false);
            whoWinsTextShadow.GetComponent<Text>().text = "Oponente 2 Venceu!";
            whoWinsTextShadow.GetComponent<Text>().color = Color.green;
            gameOver = true;
        }
        
        if (player3.GetComponent<FollowThePath>().waypointIndex ==
            player3.GetComponent<FollowThePath>().waypoints.Length)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            PlayWinMusic();
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(false);
            player3MoveText.gameObject.SetActive(false);
            player4MoveText.gameObject.SetActive(false);
            whoWinsTextShadow.GetComponent<Text>().text = "Oponente 3 Venceu!";
            whoWinsTextShadow.GetComponent<Text>().color = Color.yellow;
            gameOver = true;
        }
        if (player4.GetComponent<FollowThePath>().waypointIndex ==
            player4.GetComponent<FollowThePath>().waypoints.Length)
        {
            whoWinsTextShadow.gameObject.SetActive(true);
            PlayWinMusic();
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(false);
            player3MoveText.gameObject.SetActive(false);
            player4MoveText.gameObject.SetActive(false);
            whoWinsTextShadow.GetComponent<Text>().text = "Oponente 4 Venceu!";
            whoWinsTextShadow.GetComponent<Text>().color = Color.red;
            gameOver = true;
        }
    }

    void PlayWinMusic(){
        if(!gameOver){
           audioSource.Play(); 
        }        
    }

    public static void MovePlayer(int playerToMove)
    {
        switch (playerToMove) { 
            case 1:
                if(playerWalkBackwards){
                    player1.GetComponent<FollowThePath>().waypointIndex = player1StartWaypoint;                                     
                }else{
                    player1.GetComponent<FollowThePath>().waypointIndex = player1StartWaypoint;                                  
                }
                player1.GetComponent<FollowThePath>().moveAllowed = true;
                break;
            case 2:
                if(playerWalkBackwards){
                    player2.GetComponent<FollowThePath>().waypointIndex = player2StartWaypoint;                                     
                }else{
                    player2.GetComponent<FollowThePath>().waypointIndex = player2StartWaypoint;                                  
                }
                player2.GetComponent<FollowThePath>().moveAllowed = true;
                break;       
            case 3:
                if(playerWalkBackwards){
                    player3.GetComponent<FollowThePath>().waypointIndex = player3StartWaypoint;                                     
                }else{
                    player3.GetComponent<FollowThePath>().waypointIndex = player3StartWaypoint;                                  
                }
                player3.GetComponent<FollowThePath>().moveAllowed = true;
                break;
            case 4:
                if(playerWalkBackwards){
                    player4.GetComponent<FollowThePath>().waypointIndex = player4StartWaypoint;                                     
                }else{
                    player4.GetComponent<FollowThePath>().waypointIndex = player4StartWaypoint;                                  
                }
                player4.GetComponent<FollowThePath>().moveAllowed = true;
                break;
        }   
}
    public static void VerifyTurn(){
        if(dice.whosTurn > 1){
            dice.GetComponent<Dice>().OnMouseDown();
        }  
    }
    public void NextPlayer(){
        if(dice.whosTurn <4){
            dice.whosTurn++;
        }else{
            dice.whosTurn = 1;
        }
        dice.canPlay = true;
        playerImage.NextPlayer();
        YourTurn(dice.whosTurn);
    }

    public void VerifyWaypointIndex(){
        int player = dice.whosTurn;
        int indexWaypoint;
        Waypoint waypoint;
        switch(player){
            case 1:
                if(playerWalkBackwards){
                    indexWaypoint = player1.GetComponent<FollowThePath>().waypointIndex + 1;
                    setPlayerWalkBackwards(false);
                }else{
                    indexWaypoint = player1.GetComponent<FollowThePath>().waypointIndex - 1;
                }
                waypoint = player1.GetComponent<FollowThePath>().waypoints[indexWaypoint].GetComponent<Waypoint>();
                waypoint.VerifyState();
                break;
            case 2:
                if(playerWalkBackwards){
                    indexWaypoint = player2.GetComponent<FollowThePath>().waypointIndex + 1;
                    setPlayerWalkBackwards(false);
                }else{
                    indexWaypoint = player2.GetComponent<FollowThePath>().waypointIndex - 1;
                }
                waypoint = player2.GetComponent<FollowThePath>().waypoints[indexWaypoint].GetComponent<Waypoint>();
                waypoint.VerifyState();
                break;
            case 3:
                if(playerWalkBackwards){
                    indexWaypoint = player3.GetComponent<FollowThePath>().waypointIndex + 1;
                    setPlayerWalkBackwards(false);
                }else{
                    indexWaypoint = player3.GetComponent<FollowThePath>().waypointIndex - 1;
                }
                waypoint = player3.GetComponent<FollowThePath>().waypoints[indexWaypoint].GetComponent<Waypoint>();
                waypoint.VerifyState();
                break;
            case 4:
                if(playerWalkBackwards){
                    indexWaypoint = player4.GetComponent<FollowThePath>().waypointIndex + 1;
                    setPlayerWalkBackwards(false);
                }else{
                    indexWaypoint = player4.GetComponent<FollowThePath>().waypointIndex - 1;
                }
                waypoint = player4.GetComponent<FollowThePath>().waypoints[indexWaypoint].GetComponent<Waypoint>();
                waypoint.VerifyState();
                break;
        }
    }
    public void YourTurn(int player){
        switch(player){
            case 1: 
                player1MoveText.gameObject.SetActive(true);
                player4MoveText.gameObject.SetActive(false);
                break;
            case 2: 
                player2MoveText.gameObject.SetActive(true);
                player1MoveText.gameObject.SetActive(false);
                break;
            case 3: 
                player3MoveText.gameObject.SetActive(true);
                player2MoveText.gameObject.SetActive(false);
                break;
            case 4: 
                player4MoveText.gameObject.SetActive(true);
                player3MoveText.gameObject.SetActive(false);
                break;
        }
    }

    public void AnimateCard(){
        card.AnimateCard();
    }

    //Getters and Setters
    public static bool GetPlayerWalkBackwards(){
        return playerWalkBackwards;
    }

    public static void setPlayerWalkBackwards(bool walk){
        playerWalkBackwards = walk;
    }
}