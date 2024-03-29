using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGenerator : MonoBehaviour {
    [Header("Set Enemy Prefab")]
    //敵プレハブ
    [SerializeField]private GameObject enemyPrefab;
    [Header("Set Interval Min and Max")]
    //時間間隔の最小値
    [Range(1f, 3f)]
    [SerializeField] private float minTime = 2f;
    //時間間隔の最大値
    [Range(3f, 5f)]
    [SerializeField] private float maxTime = 5f;
    [Header("Set X Position Min and Max")]
    //X座標の最小値
    [Range(-10f, 0f)]
    [SerializeField] private float xMinPosition = -10f;
    //X座標の最大値
    [Range(0f, 10f)]
    [SerializeField] private float xMaxPosition = 10f;
    [Header("Set Y Position Min and Max")]
    //Y座標の最小値
    [Range(1f, 5f)]
    [SerializeField] private float yMinPosition = 1f;
    //Y座標の最大値
    [Range(0f, 20f)]
    [SerializeField] private float yMaxPosition = 10f;
    [Header("Set Z Position Min and Max")]
    //Z座標の最小値
    [Range(10f, 20f)]
    [SerializeField] private float zMinPosition = 10f;
    //Z座標の最大値
    [Range(20f, 30f)]
    [SerializeField] private float zMaxPosition = 20f;
    //敵生成時間間隔
    private float interval;
    //経過時間
    private float time = 0f;

    // Start is called before the first frame update
    void Start() {
        //時間間隔を決定する
        interval = GetRandomTime();
    }

    // Update is called once per frame
    void Update() {
        //時間計測
        time += Time.deltaTime;

        //経過時間が生成時間になったとき(生成時間より大きくなったとき)
        if (time > interval) {
            //enemyをインスタンス化する(生成する)
            GameObject enemy = Instantiate(enemyPrefab);
            //生成した敵の位置をランダムに設定する
            enemy.transform.position = GetRandomPosition();
            //経過時間を初期化して再度時間計測を始める
            time = 0f;
            //次に発生する時間間隔を決定する
            interval = GetRandomTime();
        }
    }

    //ランダムな時間を生成する関数
    private float GetRandomTime() {
        return Random.Range(minTime, maxTime);
    }

    //ランダムな位置を生成する関数
    private Vector3 GetRandomPosition() {
        //それぞれの座標をランダムに生成する
        float x = Random.Range(xMinPosition, xMaxPosition);
        float y = Random.Range(yMinPosition, yMaxPosition);
        float z = Random.Range(zMinPosition, zMaxPosition);

        //Vector3型のPositionを返す
        return new Vector3(x, y, z);
    }
}
