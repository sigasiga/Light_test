using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public bool tern=true;//ターン管理

	public GameObject[] Masu;
	public Material[] Material;
	int[] Masu_save= new int[25];

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void result(){
		for (int i=0; i<Masu.Length;i++){
			if (Masu [i].GetComponent<Row_Colum_date> ().Masu_manager == 0) {
				break;
			} else {
				Debug.Log ("終わり");
			}
		}
	}

	void Save_masu(){
		for(int i=0; i<Masu.Length; i++){
			Masu_save [i] = Masu [i].GetComponent<Row_Colum_date> ().Masu_manager;
		}
	}

	public void Load_masu(){
		for(int i=0; i<Masu.Length; i++){
			Masu [i].GetComponent<Row_Colum_date> ().Masu_manager = Masu_save [i];
			for(int j=0; j<Masu.Length; j++){
				Debug.Log (Masu [i].GetComponent<Row_Colum_date> ().Masu_manager);
			}

			if(Masu [i].GetComponent<Row_Colum_date> ().Masu_manager==1){
				Masu [i].GetComponent<Renderer> ().material = Material[0];
			}else if(Masu [i].GetComponent<Row_Colum_date> ().Masu_manager==-1){
				Masu [i].GetComponent<Renderer> ().material = Material[1];
			}else{
				
			}
		}
	}

	//ターン管理関数
	public void Tern(){
		if(tern){
			tern = false;
			for(int i=0; i<Masu.Length; i++){
				Debug.Log (Masu [i].GetComponent<Row_Colum_date> ().Masu_manager);
			}
			Save_masu ();
			result ();
			Debug.Log ("Your_tern");
		}else{
			tern = true;
			for(int i=0; i<Masu.Length; i++){
				Debug.Log (Masu [i].GetComponent<Row_Colum_date> ().Masu_manager);
			}
			Save_masu ();
			result();
			Debug.Log ("My_tern");
		}
	}
}
