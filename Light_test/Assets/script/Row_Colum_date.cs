﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row_Colum_date : MonoBehaviour {

	public int Row;
	public int Colum;

	public int Masu_manager=0;//どちらのマスに属しているか

	public int Masu_set = 0;//ライトが置かれたマスか判定

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
		}else{
			Masu_manager = -1;
		}
	}
}
