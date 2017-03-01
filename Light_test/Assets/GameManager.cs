using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public bool tern=true;//ターン管理

	public GameObject[] Masu;
	int[] Masu_save;

	// Use this for initialization
	void Start () {
		for(int i=0; i<25; i++){
			Debug.Log (Masu [i].GetComponent<Row_Colum_date> ().Masu_manager);
			Debug.Log (Masu.Length);
			Masu [i].GetComponent<Row_Colum_date> ().Masu_manager = Masu_save [i];
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Save_masu(){
		for(int i=0; i<Masu.Length; i++){
			Masu_save [i] = Masu [i].GetComponent<Row_Colum_date> ().Masu_manager;
		}
	}

	public void Load_masu(){
		for(int i=0; i<25; i++){
			Debug.Log (Masu [i].GetComponent<Row_Colum_date> ().Masu_manager);
			Masu [i].GetComponent<Row_Colum_date> ().Masu_manager = Masu_save [i];
		}
	}

	//ターン管理関すう
	public void Tern(){
		if(tern){
			tern = false;
			Save_masu ();
			Debug.Log ("Your_tern");
		}else{
			tern = true;
			Save_masu ();
			Debug.Log ("My_tern");
		}
	}
}
