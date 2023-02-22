using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController Instance;
    [SerializeField] private TMP_Text scoreTxt;

    [SerializeField] PlayerBoom pb;

    int score = 0;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            scoreTxt.text = score.ToString();
        }
    }

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Score = 0;
    }

    public void OnFireBoom()
    {
        Instantiate(pb);
    }
}
