using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Efect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.z <= 4.1f) {
			transform.position += new Vector3 (0, 0, 0.1f);
		}
	}
}
