using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static int _score = 0;
    public static int _step = 0;

    public Text scoreText;
    public Text stepText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "分数：" + _score.ToString();
        stepText.text = "已点击次数：" + _step.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "分数：" + _score.ToString();
        stepText.text = "已点击次数：" + _step.ToString();
    }
}
