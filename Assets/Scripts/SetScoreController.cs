using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScoreController : MonoBehaviour {
    int score = 0;
    GameObject scoreText;
    // Start is called before the first frame update
    void Start() {
        this.scoreText = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update() {
        scoreText.GetComponent<Text>().text = "スコア:" + score.ToString("D");
        // スコアを保存
        PlayerPrefs.SetInt("SCORE", score);
        PlayerPrefs.Save();
    }

    public void AddScore() {
        score++;
    }
}
