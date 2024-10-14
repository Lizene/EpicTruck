using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int money = 0, upgradeParts = 0;
    public float gas = 1f;
    [Range(0,0.1f)]public float gasDepletionRate;
    public GameObject canvas;
    TextMeshProUGUI moneyText, upgradePartsText;
    Slider gasSlider;
    GameObject gameOverPanel;
    bool gameOver;

    void Start()
    {
        Time.timeScale = 1f;
        moneyText = canvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        gasSlider = canvas.transform.GetChild(1).GetComponent<Slider>();
        upgradePartsText = canvas.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        gameOverPanel = canvas.transform.GetChild(4).gameObject;
    }

    void Update()
    {
        if (gameOver) return;
        if (gas <= 0)
        {
            gas = 0;
            UpdateGasMeter();
            GameOver();
        }
        gas -= gasDepletionRate * Time.deltaTime;
        UpdateGasMeter();
    }
    public void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
    public void RetryGame()
    {
        
        money = 0;
        gas = 1;
        upgradeParts = 0;
        SceneManager.LoadScene(0);
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
