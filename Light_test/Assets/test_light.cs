using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_light : MonoBehaviour {
	//ユニットの配置位置
	int Row=4;//行
	int Colum=3;//列
	int MyPosition;//現在地
	Vector3 direction;//方向

	int x=-1;//x方向の取得ー＞行と対応
	int z=0;//z方向の取得ー＞列と対応

	bool flag = true;//一回だけ実行したいため用意
	//direction = new Vector3 (x, 0, z);

	// Use this for initialization
	void Start () {
		//直線に光を飛ばす場合
		if(x==0 || z == 0){
			MyPosition = (Row*5) + Colum;
			Debug.Log(MyPosition);
			for(int i=0; i<4; i++){
				MyPosition += (x*5)+ z;
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
					if (flag) {
						x = -1;
						MyPosition += (x * 5) + z;//移動方向の取得
						Debug.Log (MyPosition);
						flag = false;
					} else {
						MyPosition += (x * 5) + z;
						Debug.Log (MyPosition);
					}
				}
				//列が右端になったら
				else if (Colum == 4 && i != 0) {
					if (flag) {
						z = -1;
						MyPosition += (x * 5) + z;
						Debug.Log (MyPosition);
						flag = false;
					} else {
						MyPosition += (x * 5) + z;
						Debug.Log (MyPosition);
					}
				}
				//列が下になったら
				else if (Row == 4 && i != 0) {
					if (flag) {
						x = 1;
						MyPosition += (x * 5) + z;
						Debug.Log (MyPosition);
						flag = false;
					} else {
						MyPosition += (x * 5) + z;
						Debug.Log (MyPosition);
					}
				}
				//列が左端になったら
				else if (Colum == 0 && i != 0) {
					if (flag) {
						z = 1;
						MyPosition += (x * 5) + z;
						Debug.Log (MyPosition);
						flag = false;
					} else {
						MyPosition += (x * 5) + z;
						Debug.Log (MyPosition);
					}
				}
				//端に行くまで
				else {
					MyPosition += (x * 5) + z;
					Debug.Log (MyPosition);
					//端についたか確認するために取得している
					if (x > 0 && z > 0) {
						Row++;
						Colum++;
					} else if (x > 0 && z < 0) {
						Row++;
						Colum--;
					} else if (x < 0 && z > 0) {
						Row--;
						Colum++;
					} else if (x < 0 && z < 0) {
						Row--;
						Colum--;
					}
				}

			}		
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
