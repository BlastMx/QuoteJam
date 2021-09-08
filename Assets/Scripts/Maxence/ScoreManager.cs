using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [HideInInspector]
    public float score, combo;

    [SerializeField]
    private Text scoreText, comboText;

    public static ScoreManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        combo = 1f;
    }

    private void Update()
    {
        scoreText.text = "SCORE : " + score;
        comboText.text = "COMBO : x" + combo;
    }
}