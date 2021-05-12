using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class CardsJSON : MonoBehaviour
{
    private JsonData itemdata;

    public Card card;
    [SerializeField] private string json;
    // Start is called before the first frame update
    void Start()
    {
        TextAsset file = Resources.Load("Cards") as TextAsset;
        json = file.ToString();
        itemdata = JsonMapper.ToObject(json);
        card = card.GetComponent<Card>();
        Debug.Log(itemdata["cards"][1][0][1]["question"]);
    }

    // Randomiza um topic e uma pergunta, depois preenche a carta com os valores
    public void GetQuestion(){
        int topic = Random.Range(0,itemdata["cards"].Count);
        int question = Random.Range(0,itemdata["cards"][topic][0].Count);
 
        card.UpdateCard(
            itemdata["cards"][topic][0][question]["question"].ToString(),
            itemdata["cards"][topic][0][question]["description"].ToString(),
            itemdata["cards"][topic][0][question]["option1"].ToString(),
            itemdata["cards"][topic][0][question]["option2"].ToString(),
            itemdata["cards"][topic][0][question]["option3"].ToString(),
            itemdata["cards"][topic][0][question]["option4"].ToString(),
            itemdata["cards"][topic][0][question]["answer"].ToString(),
            (bool)itemdata["cards"][topic][0][question]["AR"]
        );
    }
}
