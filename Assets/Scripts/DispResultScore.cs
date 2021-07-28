using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DispResultScore : MonoBehaviour{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start(){
        int score = PlayerPrefs.GetInt("SCORE", 0);
        scoreText.text = score.ToString("D");
    }

    // Update is called once per frame
    void Update(){
        
    }
}
