using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    [SerializeField]
    GameObject rightController;
    [SerializeField]
    LineRenderer rayObject;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //レイを出す処理
        rayObject.SetVertexCount(2); //頂点数を2個に設定（始点と終点）
        rayObject.SetPosition(0, rightController.transform.position); // 0番目の頂点を右手コントローラの位置に設定
        rayObject.SetPosition(1, rightController.transform.position + rightController.transform.forward * 100.0f); // 1番目の頂点を右手コントローラの位置から100m先に設定

        rayObject.SetWidth(0.01f, 0.01f); //線の太さを0.01mに設定
    }
}
