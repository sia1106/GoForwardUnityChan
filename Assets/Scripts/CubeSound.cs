using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSound : MonoBehaviour {
   
    //課題：キューブが地面に接触する時とキューブ同士が積み重なるときに効果音をつけてください
    //条件：ユニティちゃんと衝突した時には効果音が鳴らないようにしてください

    //CubePrefabにアタッチし衝突時に効果音を鳴らすスクリプト
    //対象がCubeまたはGroundの時に音が鳴る
    
    AudioSource audioSource;

    void Start () {
        //アタッチされているAudioSourceを取得
        audioSource = GetComponent<AudioSource>();
    }
	
    //2D用の衝突判定、triggerと異なり物理挙動はそのまま
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "CubeTag" || other.gameObject.tag == "GroundTag")
        {
            audioSource.Play();
        }
    }
}