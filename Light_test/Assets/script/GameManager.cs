using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public bool tern=true;//ターン管理

	public GameObject[] Masu;
	public Material[] Material;
	int[] Masu_save= new int[25];

	bool resultFlag=false;

	int Mypoint,YourPoint;

	public Text MyScore;
	public Text YourScore;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	//途中経過、結果用関数
	void result(){
		Mypoint = 0;
		YourPoint = 0;
		for(int i=0; i<Masu.Length; i++){
			if(Masu [i].GetComponent<Row_Colum_date> ().Masu_manager==1){
				Mypoint++;
			}else if(Masu [i].GetComponent<Row_Colum_date> ().Masu_manager==-1){
				YourPoint++;
			}
		}
		MyScore.text = Mypoint.ToString();
		YourScore.text = YourPoint.ToString();
		Debug.Log ("My:  " + Mypoint + "  Your: " + YourPoint);

		resultFlag = true;
		for (int i=0; i<Masu.Length;i++){
			if (Masu [i].GetComponent<Row_Colum_date> ().Masu_manager != 0) {
			} else {
				resultFlag = false;
				break;
			}
		}
		if(resultFlag){
			if(Mypoint>YourPoint){
				Debug.Log ("自分の勝ち");
			}else if(Mypoint<YourPoint){
				Debug.Log ("相手の勝ち");
			}else{
				Debug.Log ("引き分け");
			}
		}
	}

	void Save_masu(){
		for(int i=0; i<Masu.Length; i++){
			Masu_save [i] = Masu [i].GetComponent<Row_Colum_date> ().Masu_manager;
		}
	}

	//一時保存してあるマスデータの読み込み
	public void Load_masu(){
		for(int i=0; i<Masu.Length; i++){
			Masu [i].GetComponent<Row_Colum_date> ().Masu_manager = Masu_save [i];

			if(Masu [i].GetComponent<Row_Colum_date> ().Masu_manager==1){
				Masu [i].GetComponent<Renderer> ().material = Material[0];
			}else if(Masu [i].GetComponent<Row_Colum_date> ().Masu_manager==-1){
				Masu [i].GetComponent<Renderer> ().material = Material[1];
			}else{
				Masu [i].GetComponent<Renderer> ().material = Material[2];
			}
		}
	}

	//ターン管理関数
	public void Tern(){
		if(tern){
			tern = false;
			Save_masu ();
			result ();
		}else{
			tern = true;
			Save_masu ();
			result();
		}
	}
}
