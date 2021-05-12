using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class SpiningManager : MonoBehaviour, IPointerClickHandler {

	int randVal;
	private float timeInterval;
	private bool isCoroutine;
	private int finalAngle;

	public TextMeshProUGUI winText;
	public int section;
	float totalAngle;
	public string[] PrizeName;

	public AudioSource audioSource;

	private static Dice dice;

	public Animator animator;

	// Use this for initialization
	private void Start () {
		isCoroutine = false;
		totalAngle = 360 / section;
		dice =  GameObject.Find("Dice").GetComponent<Dice>();
		winText.enabled = false;
	}

	public void OnPointerClick(PointerEventData eventData)
    {
		if(isCoroutine){
			StartCoroutine (Spin ());
		} 
    }

	private IEnumerator Spin(){
		animator.SetBool("canPlay",false);
		audioSource.Play();
		isCoroutine = false;
		randVal = Random.Range (150, 250);

		timeInterval = 0.0001f*Time.deltaTime*2;

		for (int i = 0; i < randVal; i++) {

			transform.Rotate (0, 0, (totalAngle/2)); //Start Rotate 


			//To slow Down Wheel
			if (i > Mathf.RoundToInt (randVal * 0.2f))
				timeInterval = 0.5f*Time.deltaTime;
			if (i > Mathf.RoundToInt (randVal * 0.5f))
				timeInterval = 1f*Time.deltaTime;
			if (i > Mathf.RoundToInt (randVal * 0.7f))
				timeInterval = 1.5f*Time.deltaTime;
			if (i > Mathf.RoundToInt (randVal * 0.8f))
				timeInterval = 2f*Time.deltaTime;
			if (i > Mathf.RoundToInt (randVal * 0.9f))
				timeInterval = 2.5f*Time.deltaTime;

			yield return new WaitForSeconds (timeInterval);

		}

		if (Mathf.RoundToInt (transform.eulerAngles.z) % totalAngle != 0) //when the indicator stop between 2 numbers,it will add aditional step 
			transform.Rotate (0, 0, totalAngle/2);
		
		finalAngle = Mathf.RoundToInt (transform.eulerAngles.z);//round off euler angle of wheel value

		print (finalAngle);

		//Prize check
		int selectedNumber = 0;
		for (int i = 0; i < section; i++) {

			if (finalAngle == i * totalAngle){
				winText.enabled = true;
				winText.text = PrizeName [i];
				selectedNumber = i;
			}
		}
		SendSelectedNumber(selectedNumber);
	}

	private void SendSelectedNumber(int number){
		SpinActions.VerifyNumber(number);
		Invoke("disableMessageText",4);
	}
	private void disableMessageText(){
		winText.enabled = false;
	}

	//Getters and Setters
	public bool GetIsCoroutine(){
		return isCoroutine;
	}
	public void setIsCoroutine(bool coroutine){
		isCoroutine = coroutine;
		animator.SetBool("canPlay",true);
		if(dice.whosTurn > 1){
			StartCoroutine (Spin ());
		}
	}
}
