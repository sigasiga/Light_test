﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_light : MonoBehaviour {
	//ユニットの配置位置
	int Row=4;//行
	int Colum=3;//列
	int MyPosition;//現在地
	Vector3 direction;//方向

	int lightDir_x=-1;//x方向の取得ー＞行と対応
	int lightDir_z=0;//z方向の取得ー＞列と対応

	bool isCorner = true;//一回だけ実行したいため用意

	Get_masu Get_masu;

	//direction = new Vector3 (x, 0, z);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void Light(){
		//マスデータ及び方向の取得
		Get_masu = this.GetComponent<Get_masu> ();
		Row = Get_masu.Row;
		Colum = Get_masu.Colum;
		lightDir_x = Get_masu.lightDir_x;
		lightDir_z = Get_masu.lightDir_z;

		//直線に光を飛ばす場合
		if(lightDir_x==0 || lightDir_z == 0){
			MyPosition = (Row*5) + Colum;
			Debug.Log(MyPosition);
			for(int i=0; i<4; i++){
				MyPosition += (lightDir_x*5)+ lightDir_z;
				Debug.Log(MyPosition);
			}
		}
		//斜めに移動する場合
		else{
			MyPosition = (Row * 5) + Colum;//現在位置の取得，獲得できる5マスのうちの1マス
			Debug.Log (MyPosition);
			//光の軌跡を取得,獲得できる5マスのうちの4マス
			for (int i = 0; i < 4; i++) {
				//一周目で端の場合処理がおかしくなるのでi !=0 を適応している
				//行が上まできたら
				if (Row == 0 && i != 0) {
					//向きを変える
					if (isCorner) {
						lightDir_x = -1;
						MyPosition += (lightDir_x * 5) + lightDir_z;//移動方向の取得
						Debug.Log (MyPosition);
						isCorner = false;
					} else {
						MyPosition += (lightDir_x * 5) + lightDir_z;
						Debug.Log (MyPosition);
					}
				}
				//列が右端になったら
				else if (Colum == 4 && i != 0) {
					if (isCorner) {
						lightDir_z = -1;
						MyPosition += (lightDir_x * 5) + lightDir_z;
						Debug.Log (MyPosition);
						isCorner = false;
					} else {
						MyPosition += (lightDir_x * 5) + lightDir_z;
						Debug.Log (MyPosition);
					}
				}
				//列が下になったら
				else if (Row == 4 && i != 0) {
					if (isCorner) {
						lightDir_x = 1;
						MyPosition += (lightDir_x * 5) + lightDir_z;
						Debug.Log (MyPosition);
						isCorner = false;
					} else {
						MyPosition += (lightDir_x * 5) + lightDir_z;
						Debug.Log (MyPosition);
					}
				}
				//列が左端になったら
				else if (Colum == 0 && i != 0) {
					if (isCorner) {
						lightDir_z = 1;
						MyPosition += (lightDir_x * 5) + lightDir_z;
						Debug.Log (MyPosition);
						isCorner = false;
					} else {
						MyPosition += (lightDir_x * 5) + lightDir_z;
						Debug.Log (MyPosition);
					}
				}
				//端に行くまで
				else {
					MyPosition += (lightDir_x * 5) + lightDir_z;
					Debug.Log (MyPosition);
					//端についたか確認するために取得している
					//右下に進んでいる場合
					if (lightDir_x > 0 && lightDir_z > 0) {
						Row++;
						Colum++;
					} 
					//左下に進んでいる場合
					else if (lightDir_x > 0 && lightDir_z < 0) {
						Row++;
						Colum--;
					} 
					//右上に進んでいる場合
					else if (lightDir_x < 0 && lightDir_z > 0) {
						Row--;
						Colum++;
					} 
					//左上に進んでいる場合
					else if (lightDir_x < 0 && lightDir_z < 0) {
						Row--;
						Colum--;
					}
				}

			}
			isCorner = true;//コーナーフラグの初期化
		}
	}
}
