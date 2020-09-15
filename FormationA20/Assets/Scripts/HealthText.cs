using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    public Text healthText;
    GameRules rules;
    void Start()
    {
        rules = GameObject.FindGameObjectWithTag("Rules").GetComponent<GameRules>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Score: " + rules.Score;
    }
}
