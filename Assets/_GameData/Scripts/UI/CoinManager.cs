using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance {get; private set;}
    [HideInInspector] public TextMeshProUGUI m_CoinText;
    [SerializeField] public UpgradeAble speed,income;
    public UnityEvent coinEvent;
    public int yourMoney;
    private void Awake()
    {
        Instance = this;
        m_CoinText = GetComponent<TextMeshProUGUI>();
        m_CoinText.text = PlayerPrefs.GetInt("topmoney").ToString();
        yourMoney = PlayerPrefs.GetInt("topmoney");
    }
    public void Income(int reward)
    {
        yourMoney += reward;
        PlayerPrefs.SetInt("topmoney",yourMoney);
        m_CoinText.text = PlayerPrefs.GetInt("topmoney").ToString();
        coinEvent.Invoke();
    }
}
