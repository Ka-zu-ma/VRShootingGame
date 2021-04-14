using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour {
    //// Start is called before the first frame update
    //void Start() {

    //}

    //// Update is called once per frame
    //void Update() {

    //}

    //当たり判定メソッド
    private void OnCollisionEnter(Collision collision) {
        Debug.Log("OnCollisionEnter入った");
        //衝突したオブジェクトがBulletのとき
        if (collision.gameObject.CompareTag("Bullet")) {
            Debug.Log("Targetと弾が衝突しました");
            //Targetを削除
            Destroy(gameObject);
            //弾を削除
            Destroy(collision.gameObject);
        }
    }
}
