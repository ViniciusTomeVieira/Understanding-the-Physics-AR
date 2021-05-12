using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class DialogueJSON : MonoBehaviour
{
    private JsonData itemdata;
    [SerializeField] private string json;
    private  PlayerImage playerImage;


    private void Start()
    {      
        playerImage = GameObject.Find("ActualPlayerImage").GetComponent<PlayerImage>();
        TextAsset file = Resources.Load("Dialogue") as TextAsset;
        json = file.ToString();
        itemdata = JsonMapper.ToObject(json); 
        //Debug.Log(itemdata["dialogues"][0]["beforeTakeCardPlayer"][0]);
    }

    // 0 = rollingDicePlayer, 1 = beforeTakeCardPlayer, 2 = luckOrUnluckPlayer
    // 3 = inQuestionPlayer, 4 = afterAnswerPlayerCorrect, 5 = afterAnswerPlayerWrong
    public void GetPlayerDialogue(int state){
        switch(state){
            case 0: playerImage.ChangeDialog(itemdata["dialogues"][0]["rollingDicePlayer"][Random.Range(0,itemdata["dialogues"][0]["rollingDicePlayer"].Count)].ToString()); break;
            case 1: playerImage.ChangeDialog(itemdata["dialogues"][0]["beforeTakeCardPlayer"][Random.Range(0,itemdata["dialogues"][0]["beforeTakeCardPlayer"].Count)].ToString()); break;
            case 2: playerImage.ChangeDialog(itemdata["dialogues"][0]["luckOrUnluckPlayer"][Random.Range(0,itemdata["dialogues"][0]["luckOrUnluckPlayer"].Count)].ToString()); break;
            case 3: playerImage.ChangeDialog(itemdata["dialogues"][0]["inQuestionPlayer"][Random.Range(0,itemdata["dialogues"][0]["inQuestionPlayer"].Count)].ToString()); break;
            case 4: playerImage.ChangeDialog(itemdata["dialogues"][0]["afterAnswerPlayerCorrect"][Random.Range(0,itemdata["dialogues"][0]["afterAnswerPlayerCorrect"].Count)].ToString()); break;
            case 5: playerImage.ChangeDialog(itemdata["dialogues"][0]["afterAnswerPlayerWrong"][Random.Range(0,itemdata["dialogues"][0]["afterAnswerPlayerWrong"].Count)].ToString()); break;
        }
    }

    // 6 = rollingDiceNPC, 7 = beforeTakeCardNPC, 8 = luckOrUnluckNPC
    // 9 = inQuestionNPC, 10 = afterAnswerNPCCorrect, 11 = afterAnswerNPCWrong
    public void GetNPCDialogue(int state){
        switch(state){
            case 6: playerImage.ChangeDialog(itemdata["dialogues"][0]["rollingDiceNPC"][Random.Range(0,itemdata["dialogues"][0]["rollingDiceNPC"].Count)].ToString()); break;
            case 7: playerImage.ChangeDialog(itemdata["dialogues"][0]["beforeTakeCardNPC"][Random.Range(0,itemdata["dialogues"][0]["beforeTakeCardNPC"].Count)].ToString()); break;
            case 8: playerImage.ChangeDialog(itemdata["dialogues"][0]["luckOrUnluckNPC"][Random.Range(0,itemdata["dialogues"][0]["luckOrUnluckNPC"].Count)].ToString()); break;
            case 9: playerImage.ChangeDialog(itemdata["dialogues"][0]["inQuestionNPC"][Random.Range(0,itemdata["dialogues"][0]["inQuestionNPC"].Count)].ToString()); break;
            case 10: playerImage.ChangeDialog(itemdata["dialogues"][0]["afterAnswerNPCCorrect"][Random.Range(0,itemdata["dialogues"][0]["afterAnswerNPCCorrect"].Count)].ToString()); break;
            case 11: playerImage.ChangeDialog(itemdata["dialogues"][0]["afterAnswerNPCWrong"][Random.Range(0,itemdata["dialogues"][0]["afterAnswerNPCWrong"].Count)].ToString()); break;
        }
    }
}
