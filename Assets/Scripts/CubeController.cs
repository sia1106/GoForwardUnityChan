using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    //cubeの移動スクリプト

    private float speed = -0.2f;
    private float deadLine = -20;
    
	void Start () {
	 
	}
	
	void Update () {

        transform.Translate(this.speed, 0, 0);
        //ラインを越えたらdestroyする
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
		
	}
}
