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
        scoreText.text = "������" + _score.ToString();
        stepText.text = "�ѵ��������" + _step.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "������" + _score.ToString();
        stepText.text = "�ѵ��������" + _step.ToString();
    }
}
