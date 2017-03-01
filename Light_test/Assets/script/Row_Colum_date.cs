using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row_Colum_date : MonoBehaviour {

	public int Row;
	public int Colum;

	public int Masu_manager=0;

	GameManager GameManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Masu_management(){
		GameObject GameManagiment = GameObject.Find ("GameManager");
		GameManager = GameManagiment.GetComponent<GameManager>();
		if(GameManager.tern){
			Masu_manager = 1;
			for(int i=0;i<25;i++){
				if(GameManager.Masu [i].GetComponent<Row_Colum_date> ().Masu_manager==1){
					GameManager.Masu [i].GetComponent<Renderer> ().material = GameManager.Material[0];
				}else if(GameManager.Masu [i].GetComponent<Row_Colum_date> ().Masu_manager==-1){
					GameManager.Masu [i].GetComponent<Renderer> ().material = GameManager.Material[1];
				}else{

				}
			}
		}else{
			Masu_manager = -1;
			for(int i=0;i<25;i++){
				if(GameManager.Masu [i].GetComponent<Row_Colum_date> ().Masu_manager==1){
					GameManager.Masu [i].GetComponent<Renderer> ().material = GameManager.Material[0];
				}else if(GameManager.Masu [i].GetComponent<Row_Colum_date> ().Masu_manager==-1){
					GameManager.Masu [i].GetComponent<Renderer> ().material = GameManager.Material[1];
				}else{

				}
			}
		}
	}
}
