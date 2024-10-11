using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int money = 0;
    public float gas = 1f;
    [Range(0,0.1f)]public float gasDepletionRate;
    public GameObject canvas;
    TextMeshProUGUI moneyText;
    Slider gasSlider;

    void Start()
    {
        moneyText = canvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        gasSlider = canvas.transform.GetChild(1).GetComponent<Slider>();
    }

    void Update()
    {
        gas -= gasDepletionRate * Time.deltaTime;
        UpdateGasMeter();
        if (gas <= 0)
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;
        }
    }
    public void AddMoney(int amount)
    {
        money += amount;
        UpdateMoneyText();
    }
    public void FillTank()
    {
        gas = 1f;
        UpdateGasMeter();
    }
    void UpdateMoneyText()
    {
        moneyText.text = "Money: "+money.ToString()+" €";
    }
    void UpdateGasMeter()
    {
        gasSlider.value = gas;
    }
}
