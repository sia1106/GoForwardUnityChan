using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {

    Animator animator;
    Rigidbody2D rigid2D;

    //着地判定に使う、初期値より少し上に設定
    private float groundLevel = -3.0f;
    private float dump = 0.8f;
    float jumpVelocity = 20;

    //ゲームオーバーになるラインのX座標
    private float deadLine = -9;


	void Start () {
        //コンポーネント取得
        this.animator = GetComponent<Animator>();
        this.rigid2D = GetComponent<Rigidbody2D>();	
	}


	void Update () {
        //常に走りモーション
        this.animator.SetFloat("Horizontal", 1);
        //自身のY座標(初期値ｰ3.4)がgroundLevel(-3.0)より高いならば、isGroundはfalse(滞空中)
        //ジャンプモーションに遷移
        bool isGround = (transform.position.y > this.groundLevel) ? false:true;
        this.animator.SetBool("isGround", isGround);
        
        //足音設定
        //三項演算子、isGroundがfaleseならvoluem=0
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;

        //着地状態でクリックされている場合
        if (Input.GetMouseButtonDown(0) && isGround)
        {
            //上方向に加速
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }
        //クリックされていない場合
        if (Input.GetMouseButton(0) ==false)
        {
            //速度が0より高いなら減速
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
            }
        }

        //ラインより左に入った場合
        if (transform.position.x < this.deadLine)
        {
            //Canvasに親子付けされているUIcontrollerを取得し関数を参照(ゲームオーバー表示の関数)
            //自身をdestroy
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
            Destroy(gameObject);
        }
    }
}
