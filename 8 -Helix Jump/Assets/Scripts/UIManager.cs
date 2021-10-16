using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]private Text textScore;
    [SerializeField] private Text textBestScore;

    // Update is called once per frame
    void Update()
    {
        textBestScore.text = "Best: " + GameManager.singleton.bestScore;
        textScore.text = "" + GameManager.singleton.score;
    }
}
