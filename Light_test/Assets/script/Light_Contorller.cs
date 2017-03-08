using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Contorller : MonoBehaviour {

	TrailRenderer Light_Efect;
	public GameObject Light;

	Transform Light_positon;
	// Use this for initialization
	void Start () {
		Light_positon = this.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.z <=4.1f){
			transform.position += new Vector3(0,0,0.1f);
		}else{
			Destroy(this.gameObject);
			Instantiate (Light,new Vector3(0,0,0),transform.rotation);
		}
	}
}
