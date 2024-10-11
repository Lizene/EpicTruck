using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int money = 0;
    public float gas = 1f;
    public GameObject canvas;
    TextMeshProUGUI moneyText;
    void Start()
    {
        moneyText = canvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        
    }
    public void AddMoney(int amount)
    {
        money += amount;
        UpdateMoneyText();
    }
    void UpdateMoneyText()
    {
        moneyText.text = "Money: "+money.ToString()+" €";
    }
}
