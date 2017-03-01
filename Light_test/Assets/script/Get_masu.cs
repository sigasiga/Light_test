using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_masu : MonoBehaviour {

	public Camera camera;
	Row_Colum_date Row_Colum_data;//マスの行列情報取得

	public int lightDir_x;//x方向の取得ー＞行と対応
	public int lightDir_z;//z方向の取得ー＞列と対応

	GameObject repeatGameObject;
	int ClickCountFlag = 0;//クリックした回数によって方向の変更をするために用意
	bool repeatChackFlag = true;//同じマスを連続で選択しているか判別

	int position;

	public int Row,Colum;//test_lightで取得させるために用意

	GameManager GameManager;

	// Use this for initialization
	void Start () {
		//Screen.lockCursor = true;
	}

	public void Change(){
		GameObject GameManagiment = GameObject.Find ("GameManager");
		GameManager = GameManagiment.GetComponent<GameManager>();
		GameManager.Load_masu();
		GetVector3 (Row_Colum_data,repeatChackFlag);
		this.gameObject.SendMessage("Light");//光の進行方向を取得
		//マスの陣地色の変更
		for(int i=0;i<25;i++){
			if(GameManager.Masu [i].GetComponent<Row_Colum_date> ().Masu_manager==1){
				GameManager.Masu [i].GetComponent<Renderer> ().material = GameManager.Material[0];
			}else if(GameManager.Masu [i].GetComponent<Row_Colum_date> ().Masu_manager==-1){
				GameManager.Masu [i].GetComponent<Renderer> ().material = GameManager.Material[1];
			}else{

			}
		}
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0)){
			Get_Row_Colum ();//マス情報の取得
		}
	}

	//行列の取得
	void Get_Row_Colum(){
		int distance = 30;
		Ray ray = camera.ScreenPointToRay (Input.mousePosition);//マウスの位置にRayを飛ばす
		RaycastHit hit;
		//マスの取得
		if (Physics.Raycast (ray, out hit, distance)) {
			if (hit.collider.tag == "Masu") {//masuタグが付いたオブジェクトに当たった時
				//当たったオブジェクトの行列の取得
				GameObject selectedGameObject = hit.collider.gameObject;
				Row_Colum_data = selectedGameObject.GetComponent<Row_Colum_date> ();
				//test_lightに変数に保存
				Row = Row_Colum_data.Row;
				Colum = Row_Colum_data.Colum;

				position = (Row * 5) + Colum;
				GameObject GameManagiment = GameObject.Find ("GameManager");
				GameManager = GameManagiment.GetComponent<GameManager>();
				GameManager.Load_masu();
				GameManager.Masu [position].GetComponent<Renderer> ().material = GameManager.Material[3];

//				//同じマスを連続で指定しているか判断
//				if(repeatGameObject == selectedGameObject || repeatGameObject == null){
//					repeatChackFlag = true;
//					GetVector3 (Row_Colum_data,repeatChackFlag);
//				}else {
//					repeatChackFlag = false;
//					GetVector3 (Row_Colum_data,repeatChackFlag);
//				}

				repeatGameObject = selectedGameObject;//選択オブジェクトの一時保存

//				Debug.Log ("行"+Row_Colum_data.Row);
//				Debug.Log ("列"+Row_Colum_data.Colum);
			}
//			Debug.DrawLine (ray.origin, hit.point, Color.red);
		}else{
		}
	}


	//光の進行方向の決定する関数
	void GetVector3(Row_Colum_date Row_Colum_data, bool repeatChackFlag){
		//前回と違うマスを選択した時
		if(repeatChackFlag == false){
			ClickCountFlag = 0;
		}

		//左上角　下ー＞右下ー＞右
		if(Row_Colum_data.Row == 0 && Row_Colum_data.Colum == 0){

			if(ClickCountFlag == 0){
				lightDir_x = 1;
				lightDir_z = 0;
				ClickCountFlag++;
			}else if(ClickCountFlag == 1){
				lightDir_x = 1;
				lightDir_z = 1;
				ClickCountFlag++;
			}else if(ClickCountFlag == 2){
				lightDir_x = 0;
				lightDir_z = 1;
				ClickCountFlag = 0;
			}
//			Debug.Log ("方向 X: " + lightDir_x);
//			Debug.Log ("方向 Z: " + lightDir_z);
		}
		//右上角　下ー＞左下ー＞左
		else if(Row_Colum_data.Row == 0 && Row_Colum_data.Colum == 4){

			if(ClickCountFlag == 0){
				lightDir_x = 1;
				lightDir_z = 0;
				ClickCountFlag++;
			}else if(ClickCountFlag == 1){
				lightDir_x = 1;
				lightDir_z = -1;
				ClickCountFlag++;
			}else if(ClickCountFlag == 2){
				lightDir_x = 0;
				lightDir_z = -1;
				ClickCountFlag = 0;
			}
//			Debug.Log ("方向 X: " + lightDir_x);
//			Debug.Log ("方向 Z: " + lightDir_z);
		}
		//左下角　上ー＞右上ー＞右
		else if(Row_Colum_data.Row == 4 && Row_Colum_data.Colum == 0){

			if(ClickCountFlag == 0){
				lightDir_x = -1;
				lightDir_z = 0;
				ClickCountFlag++;
			}else if(ClickCountFlag == 1){
				lightDir_x = -1;
				lightDir_z = 1;
				ClickCountFlag++;
			}else if(ClickCountFlag == 2){
				lightDir_x = 0;
				lightDir_z = 1;
				ClickCountFlag = 0;
			}
//			Debug.Log ("方向 X: " + lightDir_x);
//			Debug.Log ("方向 Z: " + lightDir_z);
		}
		//右下角　上ー＞左上ー＞左
		else if(Row_Colum_data.Row == 4 && Row_Colum_data.Colum == 4){

			if(ClickCountFlag == 0){
				lightDir_x = -1;
				lightDir_z = 0;
				ClickCountFlag++;
			}else if(ClickCountFlag == 1){
				lightDir_x = -1;
				lightDir_z = -1;
				ClickCountFlag++;
			}else if(ClickCountFlag == 2){
				lightDir_x = 0;
				lightDir_z = -1;
				ClickCountFlag = 0;
			}
//			Debug.Log ("方向 X: " + lightDir_x);
//			Debug.Log ("方向 Z: " + lightDir_z);
		}
		//0行目　下ー＞左下ー＞右下
		else if(Row_Colum_data.Row == 0){
			
			lightDir_x = 1;
			if(ClickCountFlag == 0){
				lightDir_z = 0;
				ClickCountFlag++;
			}else if(ClickCountFlag == 1){
				lightDir_z = -1;
				ClickCountFlag++;
			}else if(ClickCountFlag == 2){
				lightDir_z = 1;
				ClickCountFlag = 0;
			}
//			Debug.Log ("方向 X: " + lightDir_x);
//			Debug.Log ("方向 Z: " + lightDir_z);
		}
		//4行目　上ー＞左上ー＞右上
		else if(Row_Colum_data.Row == 4){
			lightDir_x = -1;
			if(ClickCountFlag == 0){
				lightDir_z = 0;
				ClickCountFlag++;
			}else if(ClickCountFlag == 1){
				lightDir_z = -1;
				ClickCountFlag++;
			}else if(ClickCountFlag == 2){
				lightDir_z = 1;
				ClickCountFlag = 0;
			}
//			Debug.Log ("方向 X: " + lightDir_x);
//			Debug.Log ("方向 Z: " + lightDir_z);
		}
		//0列目 左ー＞左上ー＞左下
		else if(Row_Colum_data.Colum == 0){
			lightDir_z = 1;
			if(ClickCountFlag == 0){
				lightDir_x = 0;
				ClickCountFlag++;
			}else if(ClickCountFlag == 1){
				lightDir_x = -1;
				ClickCountFlag++;
			}else if(ClickCountFlag == 2){
				lightDir_x = 1;
				ClickCountFlag = 0;
			}
//			Debug.Log ("方向 X: " + lightDir_x);
//			Debug.Log ("方向 Z: " + lightDir_z);
		}
		//4列目　右ー＞右上ー＞右下
		else if(Row_Colum_data.Colum == 4){
			lightDir_z = -1;
			if(ClickCountFlag == 0){
				lightDir_x = 0;
				ClickCountFlag++;
			}else if(ClickCountFlag == 1){
				lightDir_x = -1;
				ClickCountFlag++;
			}else if(ClickCountFlag == 2){
				lightDir_x = 1;
				ClickCountFlag = 0;
			}
//			Debug.Log ("方向 X: " + lightDir_x);
//			Debug.Log ("方向 Z: " + lightDir_z);
		}
	}
}
