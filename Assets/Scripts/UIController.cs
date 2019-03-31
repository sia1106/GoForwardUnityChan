using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //SceneManagerに必要

public class UIController : MonoBehaviour {

    private GameObject gameOverText;
    private GameObject runLengthText;
    //距離
    private float len = 0;
    //移動速度
    private float speed = 0.03f;
    private bool isGameOver = false;
    

	void Start () {
        //オブジェクトを取得しておく
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
	}	

	void Update () {
        if (this.isGameOver == false)
        {
            //距離に移動した分を加算
            this.len += this.speed;
            //lenがfloatなので文字列に変換、F2は小数点以下２位まで
            this.runLengthText.GetComponent<Text>().text = "Distance: " + len.ToString("F2") + "m";
        }
        if (this.isGameOver == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("GameScene");
            }
        }
	}

    //ゲームオーバー時の関数、Unitychanの方で呼び出す
    public void GameOver()
    {
        //UIに表示してフラグを立てる
        this.gameOverText.GetComponent<Text>().text = "GameOver";
        this.isGameOver = true;
    }
}
