using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour {

    public GameObject cubePrefab;
    //時間計測用
    private float delta = 0;
    //生成間隔
    private float span = 1.0f;

    private float genPosX = 12;

    private float offsetY = 0.3f;
    private float spaceY = 6.9f;

    private float offsetX = 0.5f;
    private float spaceX = 0.4f;

    private int maxBlockNum = 4;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            int n = Random.Range(1, maxBlockNum);

            //生成数の上限まで(4回)
            for (int i = 0; i < n; i++)
            {
                GameObject go = Instantiate(cubePrefab) as GameObject;
                //Yの取る値は(0.3,0.3*6.9,0.3*13.8…)となる
                go.transform.position = new Vector2(this.genPosX, this.offsetY + i * this.spaceY);

            }
            this.span = this.offsetX + this.spaceX * n;

        }
		
	}
}
