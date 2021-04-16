using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour {
    //当たり判定メソッド
    private void OnCollisionEnter(Collision collision) {
        Debug.Log("OnCollisionEnter入った");
        //衝突したオブジェクトがBulletのとき
        if (collision.gameObject.CompareTag("Bullet")) {
            Debug.Log("Targetと弾が衝突しました");
            // 衝突したときにスコアを更新する
            GameObject.Find("Canvas").GetComponent<SetScoreController>().AddScore();
            //Targetを削除
            Destroy(gameObject);
            //弾を削除
            Destroy(collision.gameObject);
        }
    }
}
