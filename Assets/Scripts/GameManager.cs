using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int money = 0, upgradeParts = 0;
    public float gas = 1f;
    [Range(0,0.1f)]public float gasDepletionRate;
    public GameObject canvas;
    TextMeshProUGUI moneyText, upgradePartsText;
    Slider gasSlider;

    void Start()
    {
        moneyText = canvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        gasSlider = canvas.transform.GetChild(1).GetComponent<Slider>();
        upgradePartsText = canvas.transform.GetChild(3).GetComponent<TextMeshProUGUI>();

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
    public void AddUpgradePart()
    {
        upgradeParts++;
        UpdateUpgradePartsText();
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
    void UpdateUpgradePartsText()
    {
        upgradePartsText.text = "Upgrade Parts: "+upgradeParts.ToString();
    }
    void UpdateGasMeter()
    {
        gasSlider.value = gas;
    }
}
